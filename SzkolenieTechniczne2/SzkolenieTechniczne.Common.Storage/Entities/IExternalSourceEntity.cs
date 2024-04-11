using System;
using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne.Common.Storage.Entities
{
    public interface IExternalSourceEntity
    {
        [MaxLength(5)]
        string? ExternalSourceName { get; set; }

        [MaxLength(38)]
        string? ExternalId { get; set; }

        public DateTime? LastSynchronizedOn { get; set; }
    }
}
