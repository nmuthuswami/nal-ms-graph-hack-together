using System;
namespace GraphSample.Models
{
    public class ChatMessageModelRequest
    {
        public string Message { get; set; } = string.Empty;
        public string TeamId { get; set; } = string.Empty;
        public string ChannelId { get; set; } = string.Empty;

        public (bool IsValid,List<string> ErrorMessages) Validate()
        {
            List<string> errorMessages = new List<string>();
            if (string.IsNullOrWhiteSpace(Message))
            {
                errorMessages.Add("Message field is empty.");
            }

            if (string.IsNullOrWhiteSpace(TeamId))
            {
                errorMessages.Add("TeamId field is empty.");
            }

            if (string.IsNullOrWhiteSpace(ChannelId))
            {
                errorMessages.Add("ChannelId field is empty.");
            }

            return (!errorMessages.Any(), errorMessages);
        }
    }
}

