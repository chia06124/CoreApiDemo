﻿using AutoMapper;
using CoreApiDemo.DTO;
using CoreApiDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Repository
{
    public class SalesDataRepository: ISalesDataRepository
    {
        public IEnumerable<ViewHsoasalesDTO> GetData(EFDATAContext _EFDATAContext, IMapper _mapper, string comp_code)
        {
            var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => a).ToList();
            var map = _mapper.Map<IEnumerable<ViewHsoasalesDTO>>(result);
            return map;
        }
    }
}