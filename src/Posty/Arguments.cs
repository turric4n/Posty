using CommandLine;

namespace Posty
{
    public class Arguments
    {

        [Option('l', "location", Required = false, HelpText = "Host location")]
        public string Location { get; set; }

        [Option('h', "header", Required = false, HelpText = "Custom header")]
        public IEnumerable<string> Header { get; set; }

        [Option('d', "data", Required = false, HelpText = "Data to send")]
        public string Data { get; set; }

        [Option('w', "write-out", Required = false, HelpText = "Write out information")]
        public string WriteOut { get; set; }

        [Option('m', "method", Required = false, HelpText = "HTTP method (get, post, etc.)")]
        public string Method { get; set; }
    }
}
