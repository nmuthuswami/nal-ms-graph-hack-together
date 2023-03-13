using System;
using System.Globalization;
namespace GraphSample.Models
{
    public class MeetingModelRequest
    {
        public string Subject { get; set; } = string.Empty;
        public string BodyContent { get; set; } = string.Empty;

        public string MeetingStartDate { get; set; } = string.Empty;
        public string? MeetingStartTime { get; set; } = string.Empty;
        public string? MeetingEndDate { get; set; } = string.Empty;
        public string? MeetingEndTime { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<string> Attendees { get; set; } = new List<string>();
        public List<string> OptionalAttendees { get; set; } = new List<string>();

        private const string DATE_FORMAT = "dd/MM/yyyy";

        public (bool IsValid,List<string> Messages) Validate()
        {
            List<string> messages = new List<string>();

            if (string.IsNullOrWhiteSpace(Subject))
            {
                messages.Add("Subject field is empty.");
            }

            if (string.IsNullOrWhiteSpace(BodyContent))
            {
                messages.Add("Body Content field is empty.");
            }
                
            if (string.IsNullOrWhiteSpace(MeetingStartDate))
            {
                messages.Add("MeetingStartDate field is empty.");                
            }

            if (string.IsNullOrWhiteSpace(MeetingStartTime))
            {
                messages.Add("MeetingStartTime field is empty.");
            }

            if (string.IsNullOrWhiteSpace(MeetingEndDate))
            {
                messages.Add("MeetingEndDate field is empty.");                
            }

            if (string.IsNullOrWhiteSpace(MeetingEndTime))
            {
                messages.Add("MeetingEndTime field is empty.");                
            }

            if (string.IsNullOrWhiteSpace(Location))
            {
                messages.Add("Location field is empty.");
            }

            if (!Attendees?.Any() ?? true)
            {
                messages.Add("Attendees field is empty.");
            }

            return (!messages.Any(), messages);
        }

        
        public (DateTimeOffset StartDateTime, DateTimeOffset EndDateTime, List<string> ErrorMessages) CalculateMeetingDateTime()
        {
            DateTimeOffset startDtOffset = new DateTimeOffset();
            DateTimeOffset endDtOffset = new DateTimeOffset();
            List<string> messages = new List<string>();
            DateTime startDt, endDt;
            if(DateTime.TryParseExact(MeetingStartDate, DATE_FORMAT,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDt))
            {
                if (startDt == DateTime.MinValue || startDt == DateTime.MaxValue)
                {
                    messages.Add($"MeetingStartDate is not in a valid format. (dd/MM/yyyy): {MeetingStartDate}");
                }

                else if (startDt < DateTime.Today)
                {
                    messages.Add($"MeetingStartDate is less than current date: {MeetingStartDate}");
                }
                else
                {
                    if (!MeetingStartTime.Contains(':'))
                    {
                        messages.Add($"MeetingStartTime is not in a valid format. (hh:mm): {MeetingStartTime}");
                    }
                    else
                    {
                        string[] splitTime = MeetingStartTime?.Split(':') ?? new string[1];
                        if (splitTime?.Length == 2)
                        {
                            startDt = startDt.Add(new TimeSpan(Convert.ToInt32(splitTime[0]), Convert.ToInt32(splitTime[1]), 0));
                        }
                        else
                        {
                            messages.Add($"MeetingStartTime is not in a valid format. (hh:mm): {MeetingStartTime}");
                        }

                        var utcTime = DateTime.SpecifyKind(startDt, DateTimeKind.Utc);
                        startDtOffset = new DateTimeOffset(utcTime);
                    }
                }
            }
            else
            {
                messages.Add($"MeetingStartDate is not in a valid format. (dd/MM/yyyy): {MeetingStartDate}");
            }

            if(DateTime.TryParseExact(MeetingEndDate,DATE_FORMAT,
                CultureInfo.InvariantCulture, DateTimeStyles.None,out endDt))
            {
                if (endDt == DateTime.MinValue || endDt == DateTime.MaxValue)
                {
                    messages.Add($"MeetingEndDate is not in a valid format. (dd/MM/yyyy): {MeetingEndDate}");
                }
                else if(endDt < DateTime.Today)
                {
                    messages.Add($"MeetingEndDate is less than current date: {MeetingEndDate}");
                }
                else
                {
                    if (!MeetingEndTime.Contains(':'))
                    {
                        messages.Add($"MeetingEndTime is not in a valid format. (hh:mm): {MeetingEndTime}");
                    }
                    else
                    {
                        string[] splitEndTime = MeetingEndTime?.Split(':') ?? new string[1];
                        if (splitEndTime?.Length == 2)
                        {
                            endDt = endDt.Add(new TimeSpan(Convert.ToInt32(splitEndTime[0]), Convert.ToInt32(splitEndTime[1]), 0));
                        }
                        else
                        {
                            messages.Add($"MeetingEndTime is not in a valid format. (hh:mm): {MeetingEndTime}");
                        }

                        var endUtcTime = DateTime.SpecifyKind(endDt, DateTimeKind.Utc);
                        endDtOffset = new DateTimeOffset(endUtcTime);
                    }
                }
            }
            else
            {
                messages.Add($"MeetingEndDate is not in a valid format. (dd/MM/yyyy): {MeetingEndDate }");
            }

            if(DateTimeOffset.Compare(endDtOffset, startDtOffset) < 0)
            {
                messages.Add($"MeetingStartDate/Time is earlier than MeetingEndDate/Time: " +
                    $"{MeetingStartDate}{MeetingStartTime} - {MeetingEndDate}{MeetingEndTime}");
            }

            return (startDtOffset, endDtOffset, messages);
        }
    }
}

