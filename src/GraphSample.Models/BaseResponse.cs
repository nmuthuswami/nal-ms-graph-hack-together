using System;
namespace GraphSample.Models
{
    public abstract class BaseResponse
    {
        public List<string>? ResponseMessage { get; set; } = new List<string>();
        public bool IsSuccess => !ResponseMessage?.Any() ?? true;
    }
}

