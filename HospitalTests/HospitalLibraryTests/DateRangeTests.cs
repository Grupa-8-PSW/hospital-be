using HospitalLibrary.Core.Model.ValueObjects;
using Shouldly;

namespace HospitalTests.HospitalLibraryTests;

public class DateRangeTests
{
    [Fact]
    public void DateRangesOverlaps()
    {
        // Arrange
        var from1 = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to1 = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
        var dateRange1 = new DateRange(from1, to1);
        var from2 = new DateTime(2022, 12, 5, 16, 30, 0, DateTimeKind.Utc);
        var to2 = new DateTime(2022, 12, 15, 20, 15, 0, DateTimeKind.Utc);
        var dateRange2 = new DateRange(from2, to2);

        // Act
        var overlaps = dateRange1.OverlapsWith(dateRange2);

        // Assert
        overlaps.ShouldBeTrue();
    }

    [Fact]
    public void DateRangesDoesNotOverlap()
    {
        // Arrange
        var from1 = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to1 = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
        var dateRange1 = new DateRange(from1, to1);
        var from2 = new DateTime(2022, 12, 5, 16, 30, 0, DateTimeKind.Utc);
        var to2 = new DateTime(2022, 12, 9, 20, 15, 0, DateTimeKind.Utc);
        var dateRange2 = new DateRange(from2, to2);

        // Act
        var overlaps = dateRange1.OverlapsWith(dateRange2);

        // Assert
        overlaps.ShouldBeFalse();
    }

    [Fact]
    public void DateRangeIncludesDateTime()
    {
        // Arrange
        var from = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
        var dateRange = new DateRange(from, to);
        var dateTime = new DateTime(2022, 12, 14, 16, 30, 0, DateTimeKind.Utc);

        // Act
        var includes = dateRange.Includes(dateTime);

        // Assert
        includes.ShouldBeTrue();
    }

    [Fact]
    public void DateRangeDoesNotIncludeDateTime()
    {
        // Arrange
        var from = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
        var dateRange = new DateRange(from, to);
        var dateTime = new DateTime(2022, 11, 14, 16, 30, 0, DateTimeKind.Utc);

        // Act
        var includes = dateRange.Includes(dateTime);

        // Assert
        includes.ShouldBeFalse();
    }

    [Fact]
    public void DateRangeIncludesDateRange()
    {
        // Arrange
        var from1 = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to1 = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
        var dateRange1 = new DateRange(from1, to1);
        var from2 = new DateTime(2022, 12, 11, 16, 30, 0, DateTimeKind.Utc);
        var to2 = new DateTime(2022, 12, 17, 20, 15, 0, DateTimeKind.Utc);
        var dateRange2 = new DateRange(from2, to2);

        // Act
        var includesRange = dateRange1.IncludesRange(dateRange2);

        // Assert
        includesRange.ShouldBeTrue();
    }

    [Fact]
    public void DateRangeDoesNotIncludeDateRange()
    {
        // Arrange
        var from1 = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to1 = new DateTime(2022, 12, 20, 20, 15, 0, DateTimeKind.Utc);
        var dateRange1 = new DateRange(from1, to1);
        var from2 = new DateTime(2022, 12, 8, 16, 30, 0, DateTimeKind.Utc);
        var to2 = new DateTime(2022, 12, 17, 20, 15, 0, DateTimeKind.Utc);
        var dateRange2 = new DateRange(from2, to2);

        // Act
        var includesRange = dateRange1.IncludesRange(dateRange2);

        // Assert
        includesRange.ShouldBeFalse();
    }

    [Fact]
    public void DateRangeThrowsErrorWithInvalidArguments()
    {
        // Arrange
        var from = new DateTime(2022, 12, 10, 16, 30, 0, DateTimeKind.Utc);
        var to = new DateTime(2022, 11, 20, 20, 15, 0, DateTimeKind.Utc);

        // Act
        Action action = () => new DateRange(from, to);

        // Assert
        action.ShouldThrow<ArgumentException>("Invalid arguments, from must be before to");
    }
}