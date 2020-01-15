using System;
using Xunit;
using ReenWise.Api;

namespace ReenWise.Api.UnitTests
{
    public class ApiTest
    {
        [Fact]
        public void GetToken_CanGetToken_ReturnString()
        {
            string clientId = "YourClientID";
            string clientSecret = "YourClientSecret";
            // Arrange
            string expected;
            // Act
            string actual = AccessToken.GetToken(clientId, clientSecret);
            // Assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void GetApi_CanCallApi_ReturnObj()
        {
            string test = "123";
            string test1 = "345";
            // Arrange
            Object expected;
            // Act
            Object actual = AbaxApi.GetApi(test, test1);
            // Assert
            Assert.NotNull(actual);
        }
    }
}
