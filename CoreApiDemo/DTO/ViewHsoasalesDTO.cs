using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO
{
    public class ViewHsoasalesDTO
    {
        //= null!;可為null
        public string? Com { get; set; } = null;
        public string? ComName { get; set; } = null;
        public int Sales { get; set; } 
        public string? SalesName { get; set; } = null;
    }
}
