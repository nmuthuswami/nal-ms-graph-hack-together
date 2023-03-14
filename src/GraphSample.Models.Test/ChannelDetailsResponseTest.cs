namespace GraphSample.Models.Test
{
    public class ChannelDetailsResponseTest
    {
        [Fact]
        public void ValidateChannelDetailsResponse_ChannelId_Empty()
        {
            var actual = string.Empty;

            var sut = new ChannelDetailResponse();
            sut.ChannelId = actual;

            Assert.Equal(sut.ChannelId, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_ChannelId_Null()
        {
            string actual = null;

            var sut = new ChannelDetailResponse();
            sut.ChannelId = actual;

            Assert.Equal(sut.ChannelId, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_ChannelId_Valid()
        {
            string actual = "Test ChannelId";

            var sut = new ChannelDetailResponse();
            sut.ChannelId = actual;

            Assert.Equal(sut.ChannelId, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_ChannelName_Empty()
        {
            var actual = string.Empty;

            var sut = new ChannelDetailResponse();
            sut.ChannelName = actual;

            Assert.Equal(sut.ChannelName, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_ChannelName_Null()
        {
            string actual = null;

            var sut = new ChannelDetailResponse();
            sut.ChannelName = actual;

            Assert.Equal(sut.ChannelName, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_ChannelName_Valid()
        {
            string actual = "Test ChannelName";

            var sut = new ChannelDetailResponse();
            sut.ChannelName = actual;

            Assert.Equal(sut.ChannelName, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_TeamId_Empty()
        {
            var actual = string.Empty;

            var sut = new ChannelDetailResponse();
            sut.TeamId = actual;

            Assert.Equal(sut.TeamId, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_TeamId_Null()
        {
            string actual = null;

            var sut = new ChannelDetailResponse();
            sut.TeamId = actual;

            Assert.Equal(sut.TeamId, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_TeamId_Valid()
        {
            string actual = "Test TeamId";

            var sut = new ChannelDetailResponse();
            sut.TeamId = actual;

            Assert.Equal(sut.TeamId, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_TeamName_Empty()
        {
            var actual = string.Empty;

            var sut = new ChannelDetailResponse();
            sut.TeamName = actual;

            Assert.Equal(sut.TeamName, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_TeamName_Null()
        {
            string actual = null;

            var sut = new ChannelDetailResponse();
            sut.TeamName = actual;

            Assert.Equal(sut.TeamName, actual);
        }

        [Fact]
        public void ValidateChannelDetailsResponse_TeamName_Valid()
        {
            string actual = "Test TeamName";

            var sut = new ChannelDetailResponse();
            sut.TeamName = actual;

            Assert.Equal(sut.TeamName, actual);
        }
    }
}

