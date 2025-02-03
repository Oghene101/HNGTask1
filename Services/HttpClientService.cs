using System.Text;
using System.Text.Json;
using Task1.Services.Abstractions;

namespace Task1.Services;

public class HttpClientService(IHttpClientFactory httpClientFactory) : IHttpClientService
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public (HttpRequestMessage, string) CreateHttpRequestMessage(
        string requestUri, HttpMethod method, object? requestBody = null, string? token = null)
    {
        var serializedRequest = "";
        var httpRequestMessage = new HttpRequestMessage(method, requestUri);
        httpRequestMessage.Headers.Add("accept", "application/json");

        if (requestBody != null)
        {
            serializedRequest = JsonSerializer.Serialize(requestBody, jsonSerializerOptions);
            var stringContent = new StringContent(
                serializedRequest,
                Encoding.UTF8,
                "application/json");

            httpRequestMessage.Content = stringContent;
        }

        if (token != null)
            httpRequestMessage.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        return (httpRequestMessage, serializedRequest);
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
    {
        using var httpClient = httpClientFactory.CreateClient();
        return await httpClient.SendAsync(httpRequestMessage);
    }
}