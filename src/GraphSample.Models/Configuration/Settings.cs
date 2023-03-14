using System;
using Microsoft.Extensions.Configuration;

namespace GraphSample.Models
{
    public class Settings
    {        
        public string? ClientId { get; set; }     

        public (bool IsValid,string message) Validate()
        {
            if (string.IsNullOrWhiteSpace(ClientId))
            {
                return (false, "ClientId is empty, please enter a valid ClientID.");
            }

            return (true,string.Empty);
        }
    }       
}

