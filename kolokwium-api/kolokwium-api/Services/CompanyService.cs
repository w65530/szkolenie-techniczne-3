using kolokwium_api.Dtos;
using kolokwium_api.Entities;
using kolokwium_api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_api.Services;

public class CompanyService
{
    private readonly CompanyDbContext _context;
    
    public CompanyService(CompanyDbContext context)
    {
        _context = context;
    }
    
    public async Task<CompanyDto> GetById(int id)
    {
        var company = await _context.Companies
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        return company == null ? new CompanyDto() : company.ToDto();
    }
    
    public async Task<IEnumerable<CompanyDto>> Get()
    {
        var companies = await _context.Companies
            .Include(x => x.Address)
            .ToListAsync();
        
        return companies.Select(x => x.ToDto());
    }
    
    public async Task<CompanyDto> Add(CompanyDto companyDto)
    {
        var company = new Company
        {
            Name = companyDto.Name,
            PhoneNumber = companyDto.PhoneNumber,
            NIP = companyDto.NIP,
            REGON = companyDto.REGON,
            Address = new CompanyAddress
            {
                City = companyDto.City,
                Street = companyDto.Street,
                FlatNumber = companyDto.FlatNumber,
                HouseNumber = companyDto.HouseNumber
            }
        };
        
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
        
        return company.ToDto();
    }
    
    public async Task<CompanyDto> Update(int id, CompanyDto companyDto)
    {
        var company = await _context.Companies
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (company == null)
        {
            return new CompanyDto();
        }

        company.Name = companyDto.Name;
        company.PhoneNumber = companyDto.PhoneNumber;
        company.NIP = companyDto.NIP;
        company.REGON = companyDto.REGON;
        company.Address.City = companyDto.City;
        company.Address.Street = companyDto.Street;
        company.Address.FlatNumber = companyDto.FlatNumber ?? company.Address.FlatNumber;
        company.Address.HouseNumber = companyDto.HouseNumber ?? company.Address.HouseNumber;
        
        await _context.SaveChangesAsync();
        
        return company.ToDto();
    }
    
    public async Task<CompanyDto> Delete(int id)
    {
        var company = await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (company == null)
        {
            return new CompanyDto();
        }
        
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        
        return company.ToDto();
    }
}