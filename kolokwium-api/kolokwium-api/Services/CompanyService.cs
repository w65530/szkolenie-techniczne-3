using kolokwium_api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_api.Services;

public class CompanyService
{
    private readonly CompanyDbContext _context;
    
    public CompanyService(CompanyDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CompanyDto>> Get()
    {
        return await _context.Companies
            .Include(x => x.Address)
            .Select(x => new CompanyDto
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                NIP = x.NIP,
                REGON = x.REGON,
                City = x.Address.City,
                Street = x.Address.Street,
                FlatNumber = x.Address.FlatNumber,
                HouseNumber = x.Address.HouseNumber
            })
            .ToListAsync();
    }
}