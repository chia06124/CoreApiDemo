using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO
{
    public class ViwHsoabirthCountryDTO
    {
        //= null!;可為null
        public string NationCode { get; set; } = null!;
        public string NationName { get; set; } = null!;
        public int Seq { get; set; }
    }
}
