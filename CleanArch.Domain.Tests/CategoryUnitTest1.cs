using CleanArch.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.Tests; 
public class CategoryUnitTest1 {

    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");

        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");

        action
            .Should()
            .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateCategory_ShortName_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "Ca");

        action
            .Should()
            .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }
}