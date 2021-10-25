using AutoMapper;
using CoreApiDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Repository
{
    
    public class GenericRepository<TEntity> : IRepositoryGET<TEntity>
    {
        public IEnumerable<TEntity> GetData(EFDATAContext _EFDATAContext, IMapper _mapper,string comp_code)
        {
            var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => a).ToList();
            var map = _mapper.Map<IEnumerable<TEntity>>(result);
            return map;
        }
    }
}
