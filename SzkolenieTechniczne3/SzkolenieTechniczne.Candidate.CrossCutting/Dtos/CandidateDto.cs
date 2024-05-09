using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Candidate.CrossCutting.Dtos
{
    public class CandidateDto
    {
        public Guid Id { get; set; } 
        public string Names { get; set; }
        public string Surname { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }

        public List<CandidateAddressDto> Addresses { get; set; }
    }
}
