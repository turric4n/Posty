# Posty

Posty is a simple command-line tool for making HTTP requests. It supports various HTTP methods and allows you to specify headers and data for the requests.

## Features

- Supports multiple HTTP methods: GET, POST, PUT, DELETE, PATCH, HEAD, OPTIONS
- Allows specifying headers and data for the requests
- Outputs the response content to the console

## Requirements

- .NET 9.0

### Arguments

- `--method`: The HTTP method to use (GET, POST, PUT, DELETE, PATCH, HEAD, OPTIONS)
- `--location`: The URL to send the request to
- `--header`: The headers to include in the request (can be specified multiple times)
- `--data`: The data to include in the request body (for methods like POST and PUT)
- `--writeout`: If specified, the response content will be written to the console

### Examples

#### POST Request with JSON Data

dotnet run --method POST --location "http://example.com" --header "content-type: application/json" --data "{"key":"value"}" --writeout

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.