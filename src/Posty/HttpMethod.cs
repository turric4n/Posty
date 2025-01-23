namespace Posty
{
    public enum HttpMethodType
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH,
        HEAD,
        OPTIONS
    }

    public static class StringExtensions
    {
        public static HttpMethodType ParseHttpMethods(this string method)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(method);
            if (isNullOrEmpty)
            {
                return HttpMethodType.POST;
            }
            return method.ToUpperInvariant() switch
            {
                "GET" => HttpMethodType.GET,
                "POST" => HttpMethodType.POST,
                "PUT" => HttpMethodType.PUT,
                "DELETE" => HttpMethodType.DELETE,
                "PATCH" => HttpMethodType.PATCH,
                "HEAD" => HttpMethodType.HEAD,
                "OPTIONS" => HttpMethodType.OPTIONS,
                _ => HttpMethodType.POST
            };
        }
    }
}