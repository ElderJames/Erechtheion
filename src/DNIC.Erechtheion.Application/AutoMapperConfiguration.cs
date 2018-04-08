using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Application
{
    public class AutoMapperConfiguration
    {
        public static void CreateMap()
        {
            Mapper.Initialize();
        }
    }
}