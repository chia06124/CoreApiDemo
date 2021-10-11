using AutoMapper;
using CoreApiDemo.DTO;
using CoreApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.Profiles
{
    public class HsoasalesProfile:Profile
    {
        public HsoasalesProfile()
        {
            CreateMap<ViwHsoasale, ViewHsoasalesDTO>();
        }
    }
}
