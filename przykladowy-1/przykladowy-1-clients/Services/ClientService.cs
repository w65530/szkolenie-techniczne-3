using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using przykladowy_1_client.Dtos;
using przykladowy_1_client.Extensions;
using przykladowy_1_client.Resolvers;

namespace przykladowy_1_client.Services;

public class ClientService
{
    private readonly ClientServiceDbContext _context;
    private readonly CarServiceResolver _carServiceResolver;
    
    public ClientService(ClientServiceDbContext context, CarServiceResolver carServiceResolver)
    {
        _context = context;
        _carServiceResolver = carServiceResolver;
    }
    
    public async Task<IEnumerable<ClientDto>> GetClients()
    {
        var clients = await _context.Clients
            .Include(c => c.CarService)
            .ToListAsync();
        
        return clients.Select(c => c.ToDto());
    }
    
    public async Task<ClientDto?> GetClientById(int id)
    {
        var client = await _context.Clients
            .Include(c => c.CarService)
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return client?.ToDto();
    }
    
    public async Task<ClientDto?> CreateClient(CreateClientDto createDto)
    {
        var client = createDto.ToEntity();
        
        client.CarService = await _carServiceResolver.GetCarService(createDto.CarServiceId);
        
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

        return client.ToDto();
    }
}