using System.Linq;
using SzkolenieTechniczne.Candidate.CrossCutting.Dtos;
using Entities = SzkolenieTechniczne.Candidate.Storage.Entities;
namespace SzkolenieTechniczne.Candidate.Api.Extensions
{
    public static class CandidateExtension
    {
        public static CandidateDto ToDto(this Entities.Candidate entity)
        {
            return new CandidateDto
            {
                Id = entity.Id,
               CellPhone = entity.CellPhone,
               Email = entity.Email,
               Names = entity.Names,
               Pesel = entity.Pesel,
               Surname = entity.Surname,
               Addresses = entity.CandidateAddresses.Select(x=>
                   new CandidateAddressDto
                   { 
                       City = x.City,
                       FlatNr = x.FlatNr,
                       HouseNr = x.HouseNr,
                       Id = x.Id,
                       PostCode = x.PostCode,
                       Street = x.Street,
                   }
               ).ToList()
               
            };
        }
    }
}
