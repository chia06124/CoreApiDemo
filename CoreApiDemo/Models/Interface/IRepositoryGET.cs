using AutoMapper;
using CoreApiDemo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Interface
{
    public interface IRepositoryGET<TEntity>
    {
        IEnumerable<TEntity> GetData(EFDATAContext context, IMapper _mapper, string data);
    }
}
