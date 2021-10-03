using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Data;
using DataLayer.Models;
using System.Threading.Tasks;

namespace BussinessLayer.Helper
{
    class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
