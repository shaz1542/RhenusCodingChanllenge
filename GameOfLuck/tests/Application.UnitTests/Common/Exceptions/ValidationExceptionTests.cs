using FluentAssertions;
using FluentValidation.Results;
using GameOfLuck.Application.Common.Exceptions;
using NUnit.Framework;

namespace GameOfLuck.Application.UnitTests.Common.Exceptions;
public class ValidationExceptionTests
{
    [Test]
    public void DefaultConstructorCreatesAnEmptyErrorDictionary()
    {
        var actual = new ValidationException().Errors;

        actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
    }

    [Test]
    public void SingleValidationFailureCreatesASingleElementErrorDictionary()
    {
        var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Number", "must be less then 9"),
            };

        var actual = new ValidationException(failures).Errors;

        actual.Keys.Should().BeEquivalentTo(new string[] { "Number" });
        actual["Number"].Should().BeEquivalentTo(new string[] { "must be less then 9" });
    }

    [Test]
    public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
    {
        var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Number", "must be greater then 0"),
                new ValidationFailure("Number", "must be less then 9"),
                new ValidationFailure("Name", "must contain at least 4 characters"),
                new ValidationFailure("Name", "must is only string"),

            };

        var actual = new ValidationException(failures).Errors;

        actual.Keys.Should().BeEquivalentTo(new string[] { "Number", "Name" });

        actual["Number"].Should().BeEquivalentTo(new string[]
        {
                "must be greater then 0",
                "must be less then 9",
        });

        actual["Name"].Should().BeEquivalentTo(new string[]
        {
                "must contain at least 4 characters",
                "must is only string",

        });
    }
}
