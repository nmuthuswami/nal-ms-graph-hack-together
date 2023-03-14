namespace GraphSample.Models.Test;

public class MeetingModelRequestTest
{
    [Fact]
    public void ValidateMeetingModel_Subject_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "Subject field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.Subject = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Subject, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.First(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_Subject_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "Subject field is empty.";

        var sut = new MeetingModelRequest();

        sut.Subject = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Subject, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.First(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_Subject_ValidValue()
    {
        string actual = "Test Subject";
        int actualErrorCount = 7;
        string actualErrorMessage = "Subject field is empty.";

        var sut = new MeetingModelRequest();
        sut.Subject = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Subject, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_BodyContent_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "Body Content field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.BodyContent = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.BodyContent, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(2).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_BodyContent_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "Body Content field is empty.";

        var sut = new MeetingModelRequest();

        sut.BodyContent = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.BodyContent, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(2).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_BodyContent_ValidValue()
    {
        string actual = "Test BodyContent";
        int actualErrorCount = 7;
        string actualErrorMessage = "Body Content field is empty.";

        var sut = new MeetingModelRequest();
        sut.BodyContent = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.BodyContent, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingStartDate_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "MeetingStartDate field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.MeetingStartDate = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingStartDate, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(3).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingStartDate_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "MeetingStartDate field is empty.";

        var sut = new MeetingModelRequest();

        sut.MeetingStartDate = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingStartDate, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(3).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingStartDate_ValidValue()
    {
        string actual = "03/11/2023";
        int actualErrorCount = 7;
        string actualErrorMessage = "MeetingStartDate field is empty.";

        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingStartDate, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingStartTime_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "MeetingStartTime field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.MeetingStartTime = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingStartTime, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(4).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingStartTime_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "MeetingStartTime field is empty.";

        var sut = new MeetingModelRequest();

        sut.MeetingStartTime = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingStartTime, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(4).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingStartTime_ValidValue()
    {
        string actual = "23:11";
        int actualErrorCount = 7;
        string actualErrorMessage = "MeetingStartTime field is empty.";

        var sut = new MeetingModelRequest();
        sut.MeetingStartTime = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingStartTime, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingEndDate_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "MeetingEndDate field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.MeetingEndDate = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingEndDate, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(5).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingEndDate_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "MeetingEndDate field is empty.";

        var sut = new MeetingModelRequest();

        sut.MeetingEndDate = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingEndDate, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(5).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingEndDate_ValidValue()
    {
        string actual = "03/11/2023";
        int actualErrorCount = 7;
        string actualErrorMessage = "MeetingEndDate field is empty.";

        var sut = new MeetingModelRequest();
        sut.MeetingEndDate = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingEndDate, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingEndTime_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "MeetingEndTime field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.MeetingEndTime = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingEndTime, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(6).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingEndTime_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "MeetingEndTime field is empty.";

        var sut = new MeetingModelRequest();

        sut.MeetingEndTime = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingEndTime, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(6).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_MeetingEndTime_ValidValue()
    {
        string actual = "23:11";
        int actualErrorCount = 7;
        string actualErrorMessage = "MeetingEndTime field is empty.";

        var sut = new MeetingModelRequest();
        sut.MeetingEndTime = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.MeetingEndTime, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_Location_Empty()
    {
        string actual = string.Empty;
        string actualErrorMessage = "Location field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.Location = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Location, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(7).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_Location_Null()
    {
        string? actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "Location field is empty.";

        var sut = new MeetingModelRequest();

        sut.Location = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Location, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Take(7).Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_Location_ValidValue()
    {
        string actual = "Test Location";
        int actualErrorCount = 7;
        string actualErrorMessage = "Location field is empty.";

        var sut = new MeetingModelRequest();
        sut.Location = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Location, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_Attendees_Empty()
    {
        List<string> actual = new List<string>();
        string actualErrorMessage = "Attendees field is empty.";
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.Attendees = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Attendees, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_Attendees_Null()
    {
        List<string> actual = null;
        int actualErrorCount = 8;
        string actualErrorMessage = "Attendees field is empty.";

        var sut = new MeetingModelRequest();

        sut.Attendees = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Attendees, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.Equal(actualResult.Messages.Last(), actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_Attendees_ValidValue()
    {
        List<string> actual = new() { "test.user@contonso.com" };
        int actualErrorCount = 7;
        string actualErrorMessage = "Attendees field is empty.";

        var sut = new MeetingModelRequest();
        sut.Attendees = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Attendees, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
        Assert.NotEqual(actualResult.Messages.Last(),actualErrorMessage);
    }

    [Fact]
    public void ValidateMeetingModel_OptionalAttendees_Empty()
    {
        List<string> actual = new List<string>();
        int actualErrorCount = 8;
        var sut = new MeetingModelRequest();

        sut.OptionalAttendees = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.Attendees, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_OptionalAttendees_Null()
    {
        List<string> actual = null;
        int actualErrorCount = 8;

        var sut = new MeetingModelRequest();

        sut.OptionalAttendees = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.OptionalAttendees, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }

    [Fact]
    public void ValidateMeetingModel_OptionalAttendees_ValidValue()
    {
        List<string> actual = new() { "test.user@xyz.com" };
        int actualErrorCount = 8;

        var sut = new MeetingModelRequest();
        sut.OptionalAttendees = actual;

        var actualResult = sut.Validate();

        Assert.Equal(sut.OptionalAttendees, actual);
        Assert.False(actualResult.IsValid);
        Assert.Equal(actualResult.Messages.Count, actualErrorCount);
    }
    
    [Theory]
    [InlineData("13/12/2023")]
    [InlineData("01/01/0001")]
    [InlineData("99/99/9999")]
    public void ValidateMeetingModel_MeetingStartDate_InValid(string actual)
    {
        //string actual = "12/13/2023";
        string actualErrorMessage = $"MeetingStartDate is not in a valid format. (mm/dd/yyyy): {actual}";
        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = actual;

        var actualResult = sut.CalculateMeetingDateTime();

        Assert.True(actualResult.ErrorMessages.Any());
        Assert.Equal(actualErrorMessage, actualResult.ErrorMessages.First());
    }

    
    [Theory]
    [InlineData("11:00:00")]    
    [InlineData("11 00 AM")]
    [InlineData("11-00")]
    public void ValidateMeetingModel_MeetingStartTime_InValid(string actual)
    {
        //string actual = "11:00:00";
        string actualErrorMessage = $"MeetingStartTime is not in a valid format. (hh:mm): {actual}";
        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        sut.MeetingStartTime = actual;

        var actualResult = sut.CalculateMeetingDateTime();

        Assert.True(actualResult.ErrorMessages.Any());
        Assert.Equal(actualErrorMessage, actualResult.ErrorMessages.First());
    }

    [Theory]
    [InlineData("13/12/2023")]  
    [InlineData("01/01/0001")]
    [InlineData("99/99/9999")]
    public void ValidateMeetingModel_MeetingEndDate_InValid(string actual)
    {
        //string actual = "12/13/2023";
        string actualErrorMessage = $"MeetingEndDate is not in a valid format. (mm/dd/yyyy): {actual}";
        var sut = new MeetingModelRequest();
        sut.MeetingEndDate = actual;

        var actualResult = sut.CalculateMeetingDateTime();

        Assert.True(actualResult.ErrorMessages.Any());
        Assert.Equal(actualErrorMessage, actualResult.ErrorMessages.Last());
    }

    [Theory]
    [InlineData("11:00:00")]
    [InlineData("11 00 AM")]
    [InlineData("11-00")]
    public void ValidateMeetingModel_MeetingEndTime_InValid(string actual)
    {
        //string actual = "11:00:00";
        string actualErrorMessage = $"MeetingEndTime is not in a valid format. (hh:mm): {actual}";
        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        sut.MeetingStartTime = "11:00";
        sut.MeetingEndDate = DateTime.Now.AddDays(2).ToString("MM/dd/yyyy");
        sut.MeetingEndTime = actual;
            
        var actualResult = sut.CalculateMeetingDateTime();

        Assert.True(actualResult.ErrorMessages.Any());
        Assert.Equal(actualErrorMessage, actualResult.ErrorMessages.First());
    }


    [Fact]
    public void ValidateMeetingModel_MeetingDate_InValid()
    {
        var startDate = DateTime.Now.AddDays(2).ToString("MM/dd/yyyy");
        var startTime = "11:00";
        var endDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        var endTime = "11:30";

        string actualErrorMessage = $"MeetingStartDate/Time is earlier than MeetingEndDate/Time: " +
            $"{startDate}{startTime} - {endDate}{endTime}";

        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = startDate;
        sut.MeetingStartTime = startTime;
        sut.MeetingEndDate = endDate;
        sut.MeetingEndTime = endTime;

        var actualResult = sut.CalculateMeetingDateTime();

        Assert.True(actualResult.ErrorMessages.Any());
        Assert.Equal(actualErrorMessage, actualResult.ErrorMessages.First());
    }

    [Theory]
    [InlineData("11:30","11:00")]
    [InlineData("11:01", "11:00")]
    [InlineData("13:30", "13:00")]
    [InlineData("00:30", "00:01")]
    [InlineData("23:59", "00:00")]
    public void ValidateMeetingModel_MeetingDate_InValidTime(string startTime, string endTime)
    {
        var startDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        //var startTime = "11:30";
        var endDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        //var endTime = "11:00";

        string actualErrorMessage = $"MeetingStartDate/Time is earlier than MeetingEndDate/Time: " +
            $"{startDate}{startTime} - {endDate}{endTime}";

        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = startDate;
        sut.MeetingStartTime = startTime;
        sut.MeetingEndDate = endDate;
        sut.MeetingEndTime = endTime;

        var actualResult = sut.CalculateMeetingDateTime();

        Assert.True(actualResult.ErrorMessages.Any());
        Assert.Equal(actualErrorMessage, actualResult.ErrorMessages.First());
    }

    [Theory]
    [InlineData("11:00","11:30")]
    [InlineData("11:00", "11:01")]
    [InlineData("13:00", "13:30")]
    [InlineData("00:01", "00:30")]
    [InlineData("00:00", "23:59")]
    public void ValidateMeetingModel_MeetingDate_Valid(string startTime, string endTime)
    {
        var startDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        //var startTime = "11:00";
        var endDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        //var endTime = "11:30";

        string actualErrorMessage = $"MeetingStartDate/Time is earlier than MeetingEndDate/Time: " +
            $"{startDate}{startTime} - {endDate}{endTime}";

        var sut = new MeetingModelRequest();
        sut.MeetingStartDate = startDate;
        sut.MeetingStartTime = startTime;
        sut.MeetingEndDate = endDate;
        sut.MeetingEndTime = endTime;

        var actualResult = sut.CalculateMeetingDateTime();

        Assert.False(actualResult.ErrorMessages.Any());
    }
}
