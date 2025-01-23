using FluentAssertions;
using static Posty.Program;

namespace Posty.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void CreateHttpRequestMessage_ShouldCreateCorrectRequest()
        {
            // Arrange
            var method = HttpMethodType.POST;
            var location = "http://example.com/";
            var headers = new List<string> { "content-type: application/json", "custom-header: custom-value" };
            var data = "{\"key\":\"value\"}";

            // Act
            var request = HttpRequestHelper.CreateHttpRequestMessage(method, location, headers, data);

            // Assert
            request.Method.Should().Be(HttpMethod.Post);
            request.RequestUri.ToString().Should().Be(location);
            request.Content.Headers.ContentType.MediaType.Should().Be("application/json");
            request.Headers.GetValues("custom-header").Should().ContainSingle().Which.Should().Be("custom-value");
            request.Content.ReadAsStringAsync().Result.Should().Be(data);
        }

        [Test]
        public void ExtractHeaders_ShouldExtractContentType()
        {
            // Arrange
            var request = new HttpRequestMessage();
            var headers = new List<string> { "content-type: application/json", "custom-header: custom-value" };

            // Act
            var contentType = HttpRequestHelper.ExtractHeaders(request, headers);

            // Assert
            contentType.Should().Be("application/json");
            request.Headers.GetValues("custom-header").Should().ContainSingle().Which.Should().Be("custom-value");
        }

        [Test]
        public void ExtractHeaders_ShouldHandleEmptyHeaders()
        {
            // Arrange
            var request = new HttpRequestMessage();
            var headers = new List<string>();

            // Act
            var contentType = HttpRequestHelper.ExtractHeaders(request, headers);

            // Assert
            contentType.Should().BeEmpty();
        }
    }
}
