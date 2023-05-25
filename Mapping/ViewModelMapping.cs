using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ders2.Models;
using ders2.ViewModels;

namespace ders2.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product,ProductViewModel>().ReverseMap();
        }
    }
}