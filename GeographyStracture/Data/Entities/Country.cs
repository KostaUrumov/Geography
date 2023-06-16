﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeographyStracture.Data.Entities
{
    public  class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstraints.Country.MaxCountryNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int ContinentId { get; set; }

        [ForeignKey(nameof(ContinentId))]
        public Continent Continent { get; set; } = null!;

        [Required]
        public double Area { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        public double RoadsKm { get; set; }

        [Required]
        [StringLength(DataConstraints.Country.MaxUrlLength)]
        public string FlagUrl { get; set; } = null!;
        public int CapitalCityId { get; set; }
        
        public List<City> Cities { get; set; } = new List<City>();
    }
}
