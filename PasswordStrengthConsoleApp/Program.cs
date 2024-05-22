using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

using HttpClient client = new();
client.BaseAddress = new Uri("http://localhost:5207/");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

await GetPasswordStrength(client);

static async Task GetPasswordStrength(HttpClient client)
{
    Console.WriteLine("Enter a password: ");
    string? password = Console.ReadLine();

    var content = new StringContent(JsonSerializer.Serialize(new {password}), Encoding.UTF8, MediaTypeNames.Application.Json);
    var response = await client.PostAsync("passwordstrength", content);
    
    if(response.IsSuccessStatusCode){
        var responseBody = await response.Content.ReadAsStringAsync();
        PasswordStrength? result = JsonSerializer.Deserialize<PasswordStrength>(responseBody);
        if(result == null){
            Console.WriteLine("Cannot parse the response.");
        }
        else {
            Console.WriteLine($"Password strength: {result.Strength}");
        }
    }
    else{
        Console.WriteLine("Error: " + response.ReasonPhrase);
    }
}

