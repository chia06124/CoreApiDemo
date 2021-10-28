using AutoMapper;
using CoreApiDemo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Interface
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetById(EFDATAContext _EFDATAContext,  string data);
        IEnumerable<TEntity> GetAll(EFDATAContext _EFDATAContext);
    }
}
