using SummitGroup.Geodata.Application.Entities.Address.Dto;
using SummitGroup.Geodata.Application.Entities.Location.Domain;
using System;
using System.Collections.Generic;

namespace SummitGroup.Geodata.Application.Entities.Location.Services
{
    public static class LocationToAddressConverter
    {
        private static readonly Random random = new Random();

        public static List<AddressDto> ConvertToAddressDtoList(List<Suggestion> suggestions)
        {
            var addressDtos = new List<AddressDto>();

            foreach (var suggestion in suggestions)
            {
                var addressDto = new AddressDto
                {
                    Country = suggestion.Data.Country,
                    Region = suggestion.Data.Region,
                    City = suggestion.Data.City,
                    Street = suggestion.Data.Street,
                    House = suggestion.Data.House,
                    Apartment = GenerateRandomApartmentNumber()
                };

                addressDtos.Add(addressDto);
            }

            return addressDtos;
        }

        private static string GenerateRandomApartmentNumber()
        {
            // Генерация случайного числа от 1 до 30
            return random.Next(1, 31).ToString();
        }
    }
}