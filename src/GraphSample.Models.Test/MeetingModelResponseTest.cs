namespace GraphSample.Models.Test
{
    public class MeetingModelResponseTest
    {
        [Fact]
        public void ValidateMeetingModelResponse_MeetingURL_Empty()
        {
            var actual = string.Empty;

            var sut = new MeetingModelResponse();
            sut.MeetingURL = actual;

            Assert.Equal(sut.MeetingURL, actual);
        }

        [Fact]
        public void ValidateMeetingModelResponse_MeetingURL_Null()
        {
            string actual = null;

            var sut = new MeetingModelResponse();
            sut.MeetingURL = actual;

            Assert.Equal(sut.MeetingURL, actual);
        }

        [Fact]
        public void ValidateMeetingModelResponse_MeetingURL_Valid()
        {
            string actual = "Test Meeting URL";

            var sut = new MeetingModelResponse();
            sut.MeetingURL = actual;

            Assert.Equal(sut.MeetingURL, actual);
        }
    }
}

