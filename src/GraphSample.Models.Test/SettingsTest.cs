namespace GraphSample.Models.Test
{
    public class SettingsTest
    {
        [Fact]
        public void ValidateSettingsModel_ClientId_Empty()
        {
            var actual = "ClientId is empty, please enter a valid ClientID.";

            var sut = new Settings();
            sut.ClientId = string.Empty;

            var expected = sut.Validate();

            Assert.False(expected.IsValid);
            Assert.NotEqual(expected.message, string.Empty);
            Assert.Equal(expected.message, actual);
        }

        [Fact]
        public void ValidateSettingsModel_ClientId_Null()
        {
            var actual = "ClientId is empty, please enter a valid ClientID.";

            var sut = new Settings();
            sut.ClientId = null;

            var expected = sut.Validate();

            Assert.False(expected.IsValid);
            Assert.NotEqual(expected.message, string.Empty);
            Assert.Equal(expected.message, actual);
        }

        [Fact]
        public void ValidateSettingsModel_ClientId_Valid()
        {
            var actual = "ClientId is empty, please enter a valid ClientID.";
            var actualClientId = Guid.NewGuid().ToString();

            var sut = new Settings();
            sut.ClientId = actualClientId;

            var expected = sut.Validate();

            Assert.True(expected.IsValid);
            Assert.NotEqual(expected.message, actual);
            Assert.Equal(sut.ClientId, actualClientId);
        }
    }
}

