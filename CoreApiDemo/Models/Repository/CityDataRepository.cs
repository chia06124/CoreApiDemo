using CoreApiDemo.DTO;
using CoreApiDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Repository
{
    public class CityDataRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetById(EFDATAContext _EFDATAContext, string item_code)
        {
            var result = _EFDATAContext.ViwHsoabirthCities.Where(a => a.ItemCode.Contains(item_code)).Select(a => new
            {
                CityName = a.ItemName,
                Seq = a.Seq
            });
            return (IEnumerable<TEntity>)result;
        }

        public IEnumerable<TEntity> GetAll(EFDATAContext _EFDATAContext)
        {
            var result = from a in _EFDATAContext.ViwHsoabirthCities
                         where DateTime.Now >= (DateTime)(object)a.Sdate && DateTime.Now <= (DateTime)(object)a.Edate
                         select new ViwHsoabirthCityDTO { CityName = a.ItemName, Seq = a.Seq };
            return (IEnumerable<TEntity>)result;
        }
    }
}
