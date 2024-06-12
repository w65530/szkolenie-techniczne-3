using Microsoft.AspNetCore.Mvc;
using przykladowy_1_client.Dtos;
using przykladowy_1_client.Services;

namespace przykladowy_1_client.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;
    
    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        var clients = await _clientService.GetClients();
        
        return Ok(clients);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetClientById(int id)
    {
        var client = await _clientService.GetClientById(id);
        
        if (client == null)
        {
            return NotFound();
        }
        
        return Ok(client);
    }
    
    [HttpPost]
    public async Task<ActionResult<ClientDto>> CreateClient(CreateClientDto dto)
    {
        var client = await _clientService.CreateClient(dto);

        return Ok(client);
    }
}