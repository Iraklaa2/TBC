using System;
using System.Collections.Generic;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Data.Mappings.SeedData
{
    internal static class PhoneNumbersSeedData
    {
        private static Random _random = new Random();

        public static readonly List<PhoneNumberEntity> Data = new List<PhoneNumberEntity>();

        static PhoneNumbersSeedData()
        {
            var id = 1;
            foreach (var person in PersonsSeedData.Data)
            {
                var numbers = GetPhoneNumbers(person.Id, id);
                foreach (var number in numbers)
                {
                    number.Id = id;
                    Data.Add(number);
                    id++;
                }
                
            }
        }

        private static List<PhoneNumberEntity> GetPhoneNumbers(int personId, int id)
        {
            var typesAmount = Enum.GetNames(typeof(PhoneNumberType)).Length;
            var random = _random.Next(0, typesAmount)+1;

            var numbers = new List<PhoneNumberEntity>();

            for (var i = 0; i < random; i++)
            {
                numbers.Add(new PhoneNumberEntity
                {
                    Number = PersonsSeedData.GetRandomDigitString(_random.Next(4, 50)),
                    PersonId = personId,
                    Type = (PhoneNumberType)i
                });
            }

            return numbers;
        }
    }
}
