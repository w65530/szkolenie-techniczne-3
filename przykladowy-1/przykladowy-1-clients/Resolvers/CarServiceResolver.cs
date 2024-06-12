using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;
using przykladowy_1_client.Extensions;

namespace przykladowy_1_client.Resolvers;

public class CarServiceResolver
{
    private readonly ClientServiceDbContext _context;
    private readonly HttpClient _client;
    
    private readonly string _url = "http://localhost:5141/api/CarService";
    
    public CarServiceResolver(ClientServiceDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }
    
    public async Task<CarService> GetCarService(int id)
    {
        var response = await _client.GetAsync($"{_url}/{id}");
        
        System.Console.WriteLine(response);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Cannot retrieve car service");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        
        var externalCarServiceDto = DeserializeCarService(content);
        
        return externalCarServiceDto!.ToEntity();
    }
    
    private ExternalCarServiceDto? DeserializeCarService(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<ExternalCarServiceDto>(json, options) ?? null;
    }
}