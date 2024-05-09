using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Candidate.CrossCutting.Dtos
{
    public class CandidateAddressDto
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string FlatNr { get; set; }
        public string PostCode { get; set; }
    }
}
