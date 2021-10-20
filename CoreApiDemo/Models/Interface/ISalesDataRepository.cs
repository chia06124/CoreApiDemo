using AutoMapper;
using CoreApiDemo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Interface
{
    interface ISalesDataRepository
    {
        IEnumerable<ViewHsoasalesDTO> GetData(EFDATAContext context, IMapper mapper, string data);
    }
}
