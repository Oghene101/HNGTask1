using Carter;
using Task1.Extensions;
using Task1.Services.Abstractions;

namespace Task1.Presentation;

public class GetModule() : CarterModule("get")
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/{number}", async (string number,
                IHttpClientService httpClientService,
                IConfiguration configuration) =>
            {
                var canConvertToInt = int.TryParse(number, out int newNumber);

                if (!canConvertToInt) return Results.BadRequest(new { number = "alphabet", error = true });

                var numbersApiBaseUrl = configuration["NumbersApiBaseUrl"];
                var requestUri = numbersApiBaseUrl + $"{newNumber}/math";

                var (httpRequestMessage, _) =
                    httpClientService.CreateHttpRequestMessage(requestUri, HttpMethod.Get);
                var response = await httpClientService.SendAsync(httpRequestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                List<string> properties =
                    [newNumber.IsArmstrongNumber() ? "armstrong" : "", newNumber.IsEven() ? "even" : "odd"];
                properties.RemoveAll(property => property == "");

                return Results.Ok(new
                {
                    number,
                    is_prime = newNumber.IsPrime(),
                    is_perfect = newNumber.IsPerfect(),
                    properties,
                    digit_sum = newNumber.SumOfDigits(),
                    fun_fact = responseContent,
                });
            })
            .WithName("GetNumberInfo");
    }
}