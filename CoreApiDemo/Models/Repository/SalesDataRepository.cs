using AutoMapper;
using CoreApiDemo.DTO;
using CoreApiDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Repository
{

    public class SalesDataRepository<TEntity> : IRepository<TEntity>
    {
        public IEnumerable<TEntity> GetById(EFDATAContext _EFDATAContext, string comp_code)
        {
            var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => new ViewHsoasalesDTO
            {
                Com = a.Com,
                ComName = a.ComName,
                Sales = a.Sales,
                SalesName = a.SalesName
            });

            return (IEnumerable<TEntity>)result;
        }

        public IEnumerable<TEntity> GetAll(EFDATAContext _EFDATAContext)
        {
            var result = from a in _EFDATAContext.ViwHsoasales
                         select a;
            return (IEnumerable<TEntity>)result;
        }
    }
}
