using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ProdHouse.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public int Budget { get; set; }
        public string Type { get; set; }
        public string MovieLength { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public List<string> Genre { get; set; }
        public string Status { get; set; }
    }
}
