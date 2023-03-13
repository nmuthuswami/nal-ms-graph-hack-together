using System;
namespace GraphSample.Models
{
    public class ChatMessageModelResponse : BaseResponse
    {
        public List<ChannelDetailResponse> ChannelDetails { get; set; }
            = new List<ChannelDetailResponse>();
    }
}

