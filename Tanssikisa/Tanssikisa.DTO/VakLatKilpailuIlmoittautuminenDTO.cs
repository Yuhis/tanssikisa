using System;
using System.Collections.Generic;
using System.Text;

namespace Tanssikisa.DTO
{
    public class VakLatKilpailuIlmoittautuminenDTO
    {
        public VakLatPariDTO VakLatPari { get; set; } = new VakLatPariDTO();
        public VakLatKilpailuDTO VakLatKilpailu { get; set; } = new VakLatKilpailuDTO();
    }
}
