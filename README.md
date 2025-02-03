# Sum of Digits - ASP.NET Core Web API

This project is a simple ASP.NET Core Web API that provides an endpoint to analyze numbers, including summing their digits while handling negative values correctly.

## Prerequisites

- .NET 6.0 SDK or later ([Download .NET](https://dotnet.microsoft.com/download))
- Any IDE supporting .NET development (e.g., JetBrains Rider, Visual Studio, or VS Code)

## Setup Instructions

### 1. Clone the Repository

```sh
git clone <repository-url>
cd <repository-folder>
```

### 2. Restore Dependencies

```sh
dotnet restore
```

### 3. Run the Project

```sh
dotnet run
```

The API will start and be accessible at `https://localhost:7121` (or another port if configured).

---

## API Documentation

### **Endpoint: Get Number Information**

**URL:**

```http
GET /api/classify-number?number={value}
```

**Request Parameters:**
- `number` (int) - The number to analyze.

**Response Format:**

```json
{
    "number": 123,
    "is_prime": false,
    "is_perfect": false,
    "properties": ["armstrong", "odd"],
    "digit_sum": 6,
    "fun_fact": "Interesting fact about 123..."
}
```

### **Example Usage**

#### Using cURL
```sh
curl -X GET "http://localhost:7121/api/classify-number?number=456"
```

#### Using Postman
1. Open Postman.
2. Create a new GET request.
3. Enter the URL: `http://localhost:7121/api/classify-number?number=456`.
4. Click **Send**.

#### Using C# HttpClient
```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        var response = await client.GetStringAsync("http://localhost:7121/api/classify-number?number=456");
        Console.WriteLine(response);
    }
}
```

---

## Handling Negative Numbers
This project ensures negative numbers are processed correctly by removing the negative sign before summing the digits.

### **Implementation in C#**
```csharp
public static int SumOfDigits(this int number)
{
    return Math.Abs(number)
        .ToString()
        .ToCharArray()
        .Sum(c => int.Parse(c.ToString()));
}
```

This method avoids issues caused by parsing a negative sign (`-`).

---

## License
This project is open-source and available under the MIT License.

---

### Contributors
- [Ogheneruemu Karieren](https://github.com/Oghene101)

Feel free to contribute and submit a PR!

[HNG](https://hng.tech/hire/csharp-developers)

