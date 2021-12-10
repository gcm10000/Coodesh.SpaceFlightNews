using System;
using System.Collections.Generic;
using System.Text;

namespace Coodesh.SpaceFlightNews.DTO
{
    public class ResponseHttp<T>
    {
        public T Item { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
