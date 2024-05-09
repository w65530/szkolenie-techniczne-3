using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Candidate.Storage.Entities
{
    [Table("Candidates", Schema = "Candidate")]
    public class Candidate : BaseEntity
    {
        [MaxLength(256)]
        public string Names { get; set; }

        [MaxLength(256)]
        public string Surname { get; set; }

        [MaxLength(22)]
        public string CellPhone { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(11)]
        public string Pesel { get; set; }

        public ICollection<CandidateAddress> CandidateAddresses { get; set; } = new List<CandidateAddress>();
    }
}
