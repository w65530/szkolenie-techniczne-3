using System;
using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneDirectional { get; set; }
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string Address { get; set; }
        public string Post { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Community { get; set; }
        public string FlatNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Guid CountryId { get; set; }
    }
}
