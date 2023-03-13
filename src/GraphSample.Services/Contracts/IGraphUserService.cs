using System;
using GraphSample.Models;

namespace GraphSample.Services
{
    public interface IGraphUserService
    {
        Task<MeetingModelResponse> BookMeetingEventAsync(MeetingModelRequest request);

        Task<ChatMessageModelResponse>  PostAMessageAsync(ChatMessageModelRequest request);

        Task<ChatMessageModelResponse> GetChannelDetails();
    }
}