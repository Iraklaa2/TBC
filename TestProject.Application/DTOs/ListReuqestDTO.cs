using System;
using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;

namespace TestProject.Application.DTO.Requests
{
    public class ListReuqestDTO<T> where T : new()
    {
        private int _start;

        [Range(10, 100, ErrorMessage = ValidationErrorCodes.NotValidRange)]
        public int Limit { get; set; } = 10;

        [Range(0, int.MaxValue, ErrorMessage = ValidationErrorCodes.NotValidRange)]
        public int Page
        {
            get => _start;
            set => _start = (value - 1) * Limit;
        }

        public T Filter { get; set; } = new T();
    }
}
