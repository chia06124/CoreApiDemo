using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO
{
    public class ViewHsoasalesDTO
    {
        //= null!;可為null
        public string? Com { get; set; }
        public string? ComName { get; set; }
        public int Sales { get; set; } 
        public string? SalesName { get; set; } 
    }
}
