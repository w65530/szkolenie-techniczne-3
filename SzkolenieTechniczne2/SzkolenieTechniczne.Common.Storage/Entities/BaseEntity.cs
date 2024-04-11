using System;
using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne.Common.Storage.Entities
{
    public abstract class  BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
