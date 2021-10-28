using CoreApiDemo.DTO;
using CoreApiDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Repository
{
    public class CountryDataRepository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetById(EFDATAContext _EFDATAContext, string item_code)
        {
            var result = _EFDATAContext.ViwHsoabirthCountries.Where(a => a.ItemCode.Contains(item_code)).Select(a => new ViwHsoabirthCountryDTO {
                NationCode = a.Memo,
                NationName = a.ItemName,
                Seq = a.Seq
            });
            return (IEnumerable<TEntity>)result;
        }
        public IEnumerable<TEntity> GetAll(EFDATAContext _EFDATAContext)
        {
            //var data = _EFDATAContext.ViwHsoabirthCountries.AsEnumerable();
            var result = from a in _EFDATAContext.ViwHsoabirthCountries
                         where DateTime.Now >= (DateTime)(object)a.Sdate && DateTime.Now <= (DateTime)(object)a.Edate
                         select new ViwHsoabirthCountryDTO
                         {
                             NationCode = a.Memo,
                             NationName = a.ItemName,
                             Seq = a.Seq
                         }; 
            return (IEnumerable<TEntity>)result;

        }
    }
}
