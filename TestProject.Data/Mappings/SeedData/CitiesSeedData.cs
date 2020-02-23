using System.Collections.Generic;
using TestProject.Domain.Entities;

namespace TestProject.Data.Mappings.SeedData
{
    internal static class CitiesSeedData
    {
        public static readonly List<CityEntity> Data = new List<CityEntity>
        {
            new CityEntity
            {
                Id = 1,
                Name = "Tbilisi"
            },
            new CityEntity
            {
                Id = 2,
                Name = "Kutaisi"
            },
            new CityEntity
            {
                Id = 3,
                Name = "Rustavi"
            },
            new CityEntity
            {
                Id = 4,
                Name = "Telavi"
            },
            new CityEntity
            {
                Id = 5,
                Name = "Zugdidi"
            },
            new CityEntity
            {
                Id = 6,
                Name = "Khashuri"
            },
            new CityEntity
            {
                Id = 7,
                Name = "Zestafoni"
            },
            new CityEntity
            {
                Id = 8,
                Name = "Marneuli"
            },
            new CityEntity
            {
                Id = 9,
                Name = "Batumi"
            },
            new CityEntity
            {
                Id = 10,
                Name = "Tsiatura"
            },
            new CityEntity
            {
                Id = 11,
                Name = "Borjomi"
            },
            new CityEntity
            {
                Id = 12,
                Name = "Kaspi"
            }
        };
    }
}
