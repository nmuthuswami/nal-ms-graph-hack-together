using GraphSample.Models;

using Microsoft.Graph;
using Microsoft.Graph.Models; 
using Azure.Identity;
using Azure;

namespace GraphSample.Services;
public class GraphUserService : IGraphUserService
{
    private readonly Settings _appConfigSettings;
    private readonly GraphServiceClient _graphServiceClient;

    private const string GREENWICH_MEAN_TIME = "Greenwich Mean Time";
    
    public GraphUserService(Settings settings)
    {
        _appConfigSettings = settings;
    }

    public async Task<MeetingModelResponse> BookMeetingEventAsync(MeetingModelRequest request)
    {        
        MeetingModelResponse response = new MeetingModelResponse();

        //validate settings configuration.
        var settingsValidation = _appConfigSettings.Validate();
        if (!settingsValidation.IsValid) {            
            response?.ResponseMessage?.Add(settingsValidation.message);
        }

        //validate RequestModel.
        var responseModelValidation = request.Validate();
        if (!responseModelValidation.IsValid)
        {
            response?.ResponseMessage?.AddRange(responseModelValidation.Messages);
        }

        var calculatedDT = request.CalculateMeetingDateTime();
        if (calculatedDT.ErrorMessages.Any())
        {
            response?.ResponseMessage?.AddRange(calculatedDT.ErrorMessages);
        }

        if (response?.IsSuccess ?? true)
        {
            try
            {
                var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
                {
                    ClientId = _appConfigSettings.ClientId
                };
                var graphServiceClient = new GraphServiceClient(
                new InteractiveBrowserCredential(interactiveBrowserCredentialOptions),
                new string[] { "calendars.readwrite" });

                var requestBody = new Event
                {
                    Subject = request.Subject,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Html,
                        Content = request.BodyContent
                    },
                    Start = new DateTimeTimeZone
                    {
                        DateTime = calculatedDT.StartDateTime.ToString(),
                        TimeZone = GREENWICH_MEAN_TIME
                    },
                    End = new DateTimeTimeZone
                    {
                        DateTime = calculatedDT.EndDateTime.ToString(),
                        TimeZone = GREENWICH_MEAN_TIME
                    },
                    Location = new Location
                    {
                        DisplayName = request.Location
                    },
                    Attendees = GetAttendessList(request.Attendees,request.OptionalAttendees),
                    AllowNewTimeProposals = true,
                    IsOnlineMeeting = true,
                    OnlineMeetingProvider = OnlineMeetingProviderType.TeamsForBusiness
                };

                var result = await graphServiceClient.Me.Events.PostAsync(requestBody, (config) =>
                {
                    config.Headers.Add("Prefer", $"outlook.timezone=\"{GREENWICH_MEAN_TIME}\"");
                });

                string meetingURL = result?.OnlineMeeting?.JoinUrl ?? string.Empty;

                if (string.IsNullOrWhiteSpace(meetingURL))
                {
                    response.ResponseMessage.Add("Received an empty onlinemeeting URL.");
                }
                else
                {
                    response.MeetingURL = meetingURL;
                }
            }
            catch(Exception ex)
            {
                response.ResponseMessage.Add($"Error Message: {ex.Message} " +
                    $"|| Inner Exception: {ex.InnerException}" +
                    $"|| StackTrace Info: {ex.StackTrace}");
            }
        }
        return response;        
    }

    public async Task<ChatMessageModelResponse> PostAMessageAsync(ChatMessageModelRequest request)
    {
        ChatMessageModelResponse response = new();

        try
        {
            var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
            {
                ClientId = _appConfigSettings.ClientId
            };
            var graphServiceClient = new GraphServiceClient(
            new InteractiveBrowserCredential(interactiveBrowserCredentialOptions),
            new string[] { "channelmessage.send", "group.readwrite.all" });

            var requestBody = new ChatMessage
            {
                Body = new ItemBody
                {
                    Content = request.Message
                }
            };

            var postMessageResponse = await graphServiceClient
                                            .Teams[request.TeamId]
                                            .Channels[request.ChannelId]
                                            .Messages
                                            .PostAsync(requestBody);

            string verificationResponse = Convert.ToString(postMessageResponse?.CreatedDateTime)
                                                     ?? string.Empty;

            if ((string.IsNullOrWhiteSpace(verificationResponse)) ||
                (!postMessageResponse.ChannelIdentity.ChannelId.Equals(request.ChannelId)) ||
                (!postMessageResponse.ChannelIdentity.TeamId.Equals(request.TeamId)))
            {
                response.ResponseMessage.Add($"Message : '{request.Message}' posted " +
                    $"to Team: {request.TeamId} - Channel: {request.ChannelId} failed.");

                //can extend the method to check against the messages from channel. Not covering at the moment.
            }
            else
            {
                response.ResponseMessage.Clear();
            }
        }
        catch (Exception ex)
        {
            response.ResponseMessage.Add($"Error Message: {ex.Message} " +
                    $"|| Inner Exception: {ex.InnerException}" +
                    $"|| StackTrace Info: {ex.StackTrace}");
        }

        return response;
    }

    public async Task<ChatMessageModelResponse> GetChannelDetails()
    {
        ChatMessageModelResponse response = new();
        try
        {
            var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
            {
                ClientId = _appConfigSettings.ClientId
            };
            var graphServiceClient = new GraphServiceClient(
            new InteractiveBrowserCredential(interactiveBrowserCredentialOptions),
            new string[] { "Team.ReadBasic.All", "Channel.ReadBasic.All" });

            var result = await graphServiceClient.Me.JoinedTeams.GetAsync();

            ChannelDetailResponse channelDetails;
            response.ChannelDetails = new List<ChannelDetailResponse>();
            foreach (var team in result.Value)
            {
                var channels = await graphServiceClient.Teams[team.Id].Channels.GetAsync();

                foreach (var channel in channels.Value)
                {
                    channelDetails = new ChannelDetailResponse();
                    channelDetails.TeamId = team.Id;
                    channelDetails.TeamName = team.DisplayName;
                    channelDetails.ChannelId = channel.Id;
                    channelDetails.ChannelName = channel.DisplayName;
                    response.ChannelDetails.Add(channelDetails);
                }
                
            }
            response.ResponseMessage.Clear();
        } catch(Exception ex)
        {
            response.ResponseMessage.Add($"Error Message: {ex.Message} || " +
                    $"Inner Exception: {ex.InnerException}" +
                    $"|| StackTrace Info: {ex.StackTrace}");
        }

        return response;
    }

    private List<Attendee> GetAttendessList(List<string> attendees, List<string> optionalAttendess)
    {
        List<Attendee> attendeesList = new List<Attendee>();

        foreach(var attendee in attendees)
        {
            if (!string.IsNullOrEmpty(attendee))
            {
                attendeesList.Add(
                    new Attendee
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = attendee,
                            Name = attendee
                        },
                        Type = AttendeeType.Required
                    });
            }
        }

        foreach (var optionalAttendee in optionalAttendess)
        {
            if (!string.IsNullOrEmpty(optionalAttendee))
            {
                attendeesList.Add(
                    new Attendee
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = optionalAttendee,
                            Name = optionalAttendee
                        },
                        Type = AttendeeType.Optional
                    });
            }
        }

        return attendeesList;
    }    
}

