using CleanArch.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Domain.Tests;

public class ProductUnitTest1 {

    [Fact(DisplayName = "Create Product With Valid State")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 2.2m, 2, "Image");

        action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 2.2m, 2, "Image");

        action
            .Should()
            .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_ShortName_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, "Ca", "Product Description", 2.2m, 2, "Image");

        action
            .Should()
            .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
    }

    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(1, "pro", "Product Description", 9.99m, value, null);
        action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}
