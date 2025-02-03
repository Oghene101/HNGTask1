namespace Task1.Services.Abstractions;

public interface IHttpClientService
{
    public (HttpRequestMessage, string) CreateHttpRequestMessage(
        string requestUri, HttpMethod method, object? requestBody = null, string? token = null);
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
}