using api.common.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using technical_test_api.Models;

namespace api.dataccess.EntityFramework.ProfileMapping
{
   public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Talktoguests, CustomerModel>().ReverseMap();
            CreateMap<SpokenToGuests, SpokenToGuestModel>().ReverseMap();

        }
    }
}
