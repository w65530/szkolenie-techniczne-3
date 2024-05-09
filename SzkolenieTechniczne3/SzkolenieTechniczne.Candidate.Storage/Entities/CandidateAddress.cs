using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Candidate.Storage.Entities
{
    [Table("CandidateAddresses", Schema = "Candidate")]
    public class CandidateAddress : BaseEntity
    {
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string FlatNr { get; set; }
        public string PostCode { get; set; }

        
    }
}
