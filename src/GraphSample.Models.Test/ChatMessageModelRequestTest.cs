namespace GraphSample.Models.Test
{
    public class ChatMessageModelRequestTest
    {
        [Fact]
        public void ValidateChatMessageModelRequest_Message_Empty()
        {
            var actualMessage = "Message field is empty.";
            var sut = new ChatMessageModelRequest();

            sut.Message = string.Empty;
            sut.TeamId = "Test TeamId";
            sut.ChannelId = "Test ChannelId";

            var expectedResult = sut.Validate();


            Assert.False(expectedResult.IsValid);
            Assert.True(expectedResult.ErrorMessages.Any());
            Assert.Equal(expectedResult.ErrorMessages.First(), actualMessage);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_Message_Null()
        {
            var actualMessage = "Message field is empty.";
            var sut = new ChatMessageModelRequest();

            sut.Message = null;
            sut.TeamId = "Test TeamId";
            sut.ChannelId = "Test ChannelId";

            var expectedResult = sut.Validate();


            Assert.False(expectedResult.IsValid);
            Assert.True(expectedResult.ErrorMessages.Any());
            Assert.Equal(expectedResult.ErrorMessages.First(), actualMessage);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_Message_Valid()
        {
            var actualMessage = "Message field is empty.";
            var actual = "Test Message";
            var sut = new ChatMessageModelRequest();

            sut.Message = actual;
            sut.TeamId = "Test TeamId";
            sut.ChannelId = "Test ChannelId";

            var expectedResult = sut.Validate();


            Assert.True(expectedResult.IsValid);
            Assert.False(expectedResult.ErrorMessages.Any());
            Assert.Equal(sut.Message, actual);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_TeamId_Empty()
        {
            var actualMessage = "TeamId field is empty.";
            var sut = new ChatMessageModelRequest();

            sut.Message = "Test Message";
            sut.TeamId = string.Empty;
            sut.ChannelId = "Test ChannelId";

            var expectedResult = sut.Validate();


            Assert.False(expectedResult.IsValid);
            Assert.True(expectedResult.ErrorMessages.Any());
            Assert.Equal(expectedResult.ErrorMessages.First(), actualMessage);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_TeamId_Null()
        {
            var actualMessage = "TeamId field is empty.";
            var sut = new ChatMessageModelRequest();

            sut.Message = "Test Message";
            sut.TeamId = null;
            sut.ChannelId = "Test ChannelId";

            var expectedResult = sut.Validate();


            Assert.False(expectedResult.IsValid);
            Assert.True(expectedResult.ErrorMessages.Any());
            Assert.Equal(expectedResult.ErrorMessages.First(), actualMessage);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_TeamId_Valid()
        {
            var actualMessage = "TeamId field is empty.";
            var actual = "Test TeamId";
            var sut = new ChatMessageModelRequest();

            sut.Message = "Test Message";
            sut.TeamId = actual;
            sut.ChannelId = "Test ChannelId";

            var expectedResult = sut.Validate();


            Assert.True(expectedResult.IsValid);
            Assert.False(expectedResult.ErrorMessages.Any());
            Assert.Equal(sut.TeamId, actual);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_ChannelId_Empty()
        {
            var actualMessage = "ChannelId field is empty.";
            var sut = new ChatMessageModelRequest();

            sut.Message = "Test Message";
            sut.TeamId = "Test TeamId";
            sut.ChannelId = string.Empty;

            var expectedResult = sut.Validate();


            Assert.False(expectedResult.IsValid);
            Assert.True(expectedResult.ErrorMessages.Any());
            Assert.Equal(expectedResult.ErrorMessages.First(), actualMessage);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_ChannelId_Null()
        {
            var actualMessage = "ChannelId field is empty.";
            var sut = new ChatMessageModelRequest();

            sut.Message = "Test Message";
            sut.TeamId = "Test TeamId";
            sut.ChannelId = null;

            var expectedResult = sut.Validate();


            Assert.False(expectedResult.IsValid);
            Assert.True(expectedResult.ErrorMessages.Any());
            Assert.Equal(expectedResult.ErrorMessages.First(), actualMessage);
        }

        [Fact]
        public void ValidateChatMessageModelRequest_ChannelId_Valid()
        {
            var actualMessage = "ChannelId field is empty.";
            var actual = "Test ChannelId";
            var sut = new ChatMessageModelRequest();

            sut.Message = "Test Message";
            sut.TeamId = "Test TeamId";
            sut.ChannelId = actual;

            var expectedResult = sut.Validate();


            Assert.True(expectedResult.IsValid);
            Assert.False(expectedResult.ErrorMessages.Any());
            Assert.Equal(sut.ChannelId, actual);
        }
    }
}

