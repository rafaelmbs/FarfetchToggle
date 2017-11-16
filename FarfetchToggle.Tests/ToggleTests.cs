using FarfetchToggle.Contracts.Toggle;
using FarfetchToggle.Services;
using Xunit;

namespace FarfetchToggle.Tests
{
    public class ToggleTests
    {
        private readonly ToggleService _service;

        public ToggleTests(ToggleService service)
        {
            _service = service;
        }

        [Fact]
        public void IsAValidToggleGetResponse()
        {
            //Arrange
            ToggleGetResponse response = new ToggleGetResponse();

            //Act
            var result = _service.GetToggles();

            //Assert
            Assert.Same(result, response);
        }
    }
}
