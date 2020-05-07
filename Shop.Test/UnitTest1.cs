using System;
using Xunit;
using Shop;

namespace Shop.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("98 20")]
        [InlineData("04 23")]
        [InlineData("56 09")]
        public void IsValidThru_Result_True(string value)
        {
            bool actual = InputVerifications.IsValidThruDate(value);
            Assert.True(actual);
        }

        [Theory]
        [InlineData("98320")]
        [InlineData("0a 23")]
        [InlineData("5 409")]
        [InlineData("540 9")]
        [InlineData("5409 ")]
        [InlineData(" 5409")]
        [InlineData("  409")]
        [InlineData("356 09")]
        [InlineData("56 309")]
        [InlineData("5 0")]
        [InlineData("")]
        [InlineData(" ")]
        public void IsValidThru_Result_False(string value)
        {
            bool actual = InputVerifications.IsValidThruDate(value);
            Assert.False(actual);
        }

        // [Fact]
        // public void TBD() {
        // }
    }
}
