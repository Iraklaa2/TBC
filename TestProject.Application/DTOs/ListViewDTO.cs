using System.Collections.Generic;

namespace TestProject.Application.DTO.Responses
{
    public class ListViewDTO<T>
    {
        public int TotalRecords { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
