using System;
using System.Collections.Generic;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Data.Mappings.SeedData
{
    internal static class PersonsSeedData
    {
        private static readonly Random _random = new Random();

        public static readonly List<PersonEntity> Data = new List<PersonEntity>
        {
                new PersonEntity
                {
                    Id = 1,
                    LastName = "Zarandia",
                    FirstName = "Irakli",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 1,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 2,
                    LastName = "Gamsaxurdia",
                    FirstName = "Zviadi",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 5,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 3,
                    LastName = "Shevardnaze",
                    FirstName = "Eduardi",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 3,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 4,
                    LastName = "Saakashvili",
                    FirstName = "Mikheili",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 4,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 5,
                    LastName = "Margvelashvili",
                    FirstName = "Giorgi",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 5,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 6,
                    LastName = "Zurabishvili",
                    FirstName = "Salome",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 5,
                    Gender = GenderType.Female,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 7,
                    LastName = "Nidzaradze",
                    FirstName = "Leqo",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 6,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 8,
                    LastName = "Tabagari",
                    FirstName = "Bidzina",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 6,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 9,
                    LastName = "Shavdia",
                    FirstName = "Geno",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 8,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 10,
                    LastName = "Khatamadze",
                    FirstName = "Rezo",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 8,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 11,
                    LastName = "ჯონირია",
                    FirstName = "გურამი",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 11,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 12,
                    LastName = "კაკაურიძე",
                    FirstName = "ომგერი",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 11,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 13,
                    LastName = "ზერაგია",
                    FirstName = "უჩა",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 11,
                    Gender = GenderType.Male,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 14,
                    LastName = "Chkadua",
                    FirstName = "Dinara",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 11,
                    Gender = GenderType.Female,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 15,
                    LastName = "Tsurtsumia",
                    FirstName = "Lela",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 2,
                    Gender = GenderType.Female,
                    DateOfBirth = GetRandomDate()
                },
                new PersonEntity
                {
                    Id = 16,
                    LastName = "Grigolia",
                    FirstName = "Inga",
                    PersonalNumber = GetRandomDigitString(),
                    CityId = 2,
                    Gender = GenderType.Female,
                    DateOfBirth = GetRandomDate()
                }
        };

        public static string GetRandomDigitString(int amount = 11)
        {
            return _random.Next(0, 999999).ToString("D11");
        }

        private static DateTime GetRandomDate()
        {
            var randomYear = _random.Next(18, 100);
            var randomDays = _random.Next(0, 100);
            var randomMonth = _random.Next(0, 100);

            return DateTime.Now
                .AddYears(randomYear * -1)
                .AddDays(randomDays)
                .AddMonths(randomMonth);
        }
    }
}