using System.Text;
using CommandLine;

namespace Posty;

public class Program
{
    static async Task Main(string[] args)
    {
        var parser = new Parser(conf =>
        {
            conf.AllowMultiInstance = true;
        });

        await parser.ParseArguments<Arguments>(args)
            .WithParsedAsync(async arguments =>
            {
                using var client = new HttpClient();

                var method = arguments.Method.ParseHttpMethods();
                var request = HttpRequestHelper.CreateHttpRequestMessage(method, arguments.Location, arguments.Header, arguments.Data);

                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(arguments.WriteOut))
                {
                    Console.WriteLine(responseContent);
                }
            });
    }

    public static class HttpRequestHelper
    {
        public static HttpRequestMessage CreateHttpRequestMessage(HttpMethodType method, string location, IEnumerable<string> headers, string data)
        {
            var request = new HttpRequestMessage(new HttpMethod(method.ToString()), location);
            var contentType = ExtractHeaders(request, headers);

            if (!string.IsNullOrEmpty(data))
            {
                var content = string.IsNullOrEmpty(contentType) ? 
                    new StringContent(data, Encoding.UTF8) 
                    : new StringContent(data, Encoding.UTF8, contentType);
            
                request.Content = content;
            }

            return request;
        }

        public static string ExtractHeaders(HttpRequestMessage request, IEnumerable<string> headers)
        {
            var contentType = string.Empty;

            foreach (var header in headers)
            {
                var key = header.Split(":")[0].Trim();
                var value = header.Split(":")[1].Trim();

                if (key.Equals("content-type", StringComparison.OrdinalIgnoreCase))
                {
                    contentType = value;
                }
                else
                {
                    request.Headers.Add(key, value);
                }
            }

            return contentType;
        }
    }
}
