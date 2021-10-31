using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Interface
{
    public interface IRepositoryObject<TEntity>
    {
        IEnumerable<TEntity> GetAll(EFDATAContext _EFDATAContext, JsonElement data);
    }
}
