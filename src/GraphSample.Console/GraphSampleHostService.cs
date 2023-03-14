using System;
using GraphSample.Services;
using GraphSample.Models;
using Microsoft.Extensions.Hosting;
using System.Dynamic;
using Azure;

namespace MsIntuneGraphSample
{
    public class GraphSampleHostService: IHostedService
    {
        private readonly IHostApplicationLifetime _appLifeTime;
        private readonly IGraphUserService _graphUserService;
        private readonly Settings _config;

        private Random _random = new Random();


        public GraphSampleHostService(Settings config, IGraphUserService graphUserService, IHostApplicationLifetime appLifeTime)
        => (_config, _graphUserService, _appLifeTime) = (config, graphUserService, appLifeTime);
        /*
        private async Task BookMeeting()
        {
            MeetingModelRequest requestMettingModel = new MeetingModelRequest();
            Console.WriteLine("Enter StartDate (dd/mm/yyyy) [ex: 15/11/2023]:");
            requestMettingModel.MeetingStartDate = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter StartTime (hh:mm) [ex: 13:30]:");
            requestMettingModel.MeetingStartTime = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter EndDate (dd/mm/yyyy): [ex: 15/11/2023]");
            requestMettingModel.MeetingEndDate = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter EndTime (hh:mm): [ex: 14:00]");
            requestMettingModel.MeetingEndTime = Console.ReadLine() ?? string.Empty;
            var result = await _graphUserService.BookMeetingAsync(requestMettingModel);
            if (result.IsSuccess)
            {
                Console.WriteLine(result.MeetingURL);
            }
            else
            {
                foreach (var msg in result?.ResponseMessage)
                {
                    Console.WriteLine(msg);
                }
            }
        }*/

        private async Task BookMeetingEvent()
        {
            var settingsValidation = _config.Validate();
            if (!settingsValidation.IsValid)
            {
                Console.WriteLine(settingsValidation.message);
                _config.ClientId = Console.ReadLine();
            }

            MeetingModelRequest request = new ();
            Console.WriteLine("Enter Event Subject:");
            request.Subject = Console.ReadLine().Trim() ?? string.Empty;
            Console.WriteLine("Enter Event Content:");
            request.BodyContent = Console.ReadLine().Trim() ?? string.Empty;
            Console.WriteLine("Enter StartDate (mm/dd/yyyy) [ex: 11/15/2023]:");
            request.MeetingStartDate = Console.ReadLine().Trim() ?? string.Empty;
            Console.WriteLine("Enter StartTime (hh:mm) [ex: 13:30]:");
            request.MeetingStartTime = Console.ReadLine().Trim() ?? string.Empty;
            Console.WriteLine("Enter EndDate (mm/dd/yyyy): [ex: 11/15/2023]");
            request.MeetingEndDate = Console.ReadLine().Trim() ?? string.Empty;
            Console.WriteLine("Enter EndTime (hh:mm): [ex: 14:00]");
            request.MeetingEndTime = Console.ReadLine().Trim() ?? string.Empty;
            Console.WriteLine("Enter Event Location:");
            request.Location = Console.ReadLine().Trim() ?? string.Empty;
            while (true)
            {
                Console.WriteLine("Enter Require Attendee(s) Emailaddress [ex: abc@xyz.com]:");
                request.Attendees.Add(Console.ReadLine().Trim());
                Console.WriteLine("Press c to exit or any key to proceed to next attendee");
                if (Console.ReadLine().Trim().ToLower() == "c")
                    break;
            }
            while (true)
            {
                Console.WriteLine("Enter Optional Attendee(s) Emailaddress [ex:abc@xyz.com]");
                request.OptionalAttendees.Add(Console.ReadLine().Trim());
                Console.WriteLine("Press c to exit or any key to proceed next attendee");
                if (Console.ReadLine().Trim().ToLower() == "c")
                    break;
            }
            var response = await _graphUserService.BookMeetingEventAsync(request);
            if (response.IsSuccess == false ||
                string.IsNullOrWhiteSpace(response.MeetingURL))
            {
                Console.WriteLine("Something went wrong. For more details please refer below:");
                Console.WriteLine("********************************************************************************");
                foreach(var msg in response.ResponseMessage){
                    Console.WriteLine(msg);
                    Console.WriteLine("============================================================================");
                }
            }
            else
            {
                Console.WriteLine("***OUTPUT***");
                Console.WriteLine("===============================================================================");
                Console.WriteLine(response.MeetingURL);
            }
        }

        private async Task SendAMessageToChannel()
        {
            var settingsValidation = _config.Validate();
            if (!settingsValidation.IsValid)
            {
                Console.WriteLine(settingsValidation.message);
                _config.ClientId = Console.ReadLine();
            }
            Console.WriteLine("Pulling your Team/Channel Details......");
            var channelDetails = await _graphUserService.GetChannelDetails();

            if (channelDetails.IsSuccess)
            {
                Console.WriteLine("Team Name || Channel Name");
                Console.WriteLine("=========    ============");
                Console.WriteLine("");
                int count = 1;
                foreach(var channelInfo in channelDetails.ChannelDetails)
                {
                    Console.WriteLine($"{count++}. {channelInfo.TeamName} || {channelInfo.ChannelName}");
                }
                Console.WriteLine("Please select the team/channel, you wish to send a message");
                int userSelection = -1;
                string strUserSelection = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(strUserSelection, out userSelection))
                {
                    if (userSelection <= channelDetails.ChannelDetails.Count && userSelection > 0)
                    {
                        var userSelectedDetails = channelDetails.ChannelDetails[userSelection - 1];
                        Console.WriteLine($"Selected Details: TeamName - {userSelectedDetails.TeamName} " +
                            $"ChannelName - {userSelectedDetails.ChannelName}");
                        Console.WriteLine($"Please write a message, you wish to post in the channel: ");
                        string postMessage = Console.ReadLine() ?? string.Empty;

                        ChatMessageModelRequest request = new()
                        {
                            TeamId = userSelectedDetails.TeamId,
                            ChannelId = userSelectedDetails.ChannelId,
                            Message = postMessage
                        };

                        var postMessageResponse = await _graphUserService.PostAMessageAsync(request);

                        if (postMessageResponse.IsSuccess)
                        {
                            Console.WriteLine("Message posted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong. For more details please refer below:");
                            Console.WriteLine("********************************************************************************");
                            foreach (var msg in postMessageResponse.ResponseMessage)
                            {
                                Console.WriteLine(msg);
                                Console.WriteLine("============================================================================");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Invalid user input: '{userSelection}', application exiting.");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid user input: '{strUserSelection}', application exiting.");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong. For more details please refer below error:");
                Console.WriteLine("********************************************************************************");
                foreach (var msg in channelDetails.ResponseMessage)
                {
                    Console.WriteLine(msg);
                    Console.WriteLine("============================================================================");
                }
            }

        }
       
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifeTime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        Console.WriteLine("Please select any of the following Graph Scenarios:");
                        Console.WriteLine("1. Setup a Teams meeting and return the URL");
                        Console.WriteLine("2. Send a message to a Teams channel or chat");

                        int userOption = -1;

                        if (int.TryParse(Console.ReadLine(), out userOption))
                        {
                            switch (userOption)
                            {
                                case 1:
                                    await BookMeetingEvent();
                                    break;
                                case 2:
                                    await SendAMessageToChannel();
                                    break;
                                case 3:
                                    Console.WriteLine("Not Implemented");
                                    break;
                                case 4:
                                    Console.WriteLine("Not Implemented");
                                    break;
                                case 5:
                                    Console.WriteLine("Not Implemented");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Selection, application exiting. Please restart the program and select any one of the displayed number.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Selection, application exiting. Please restart the program and select any one of the displayed number.");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.ReadLine();
                        _appLifeTime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}