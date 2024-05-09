using System.Linq;
using SzkolenieTechniczne.Candidate.CrossCutting.Dtos;
using Entities = SzkolenieTechniczne.Candidate.Storage.Entities;
namespace SzkolenieTechniczne.Candidate.Api.Extensions
{
    public static class CandidateDtoExtension
    {
        public static Entities.Candidate ToEntity(this CandidateDto dto)
        {
            return new Entities.Candidate
            {
                Id = dto.Id,
                CellPhone = dto.CellPhone,
                Email = dto.Email,
                Names = dto.Names,
                Pesel = dto.Pesel,
                Surname = dto.Surname,
                CandidateAddresses = dto.Addresses.Select(x =>
                 new Entities.CandidateAddress
                 {
                     City = x.City,
                     CandidateId = dto.Id,
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