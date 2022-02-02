using api.common.Model;
using api.Common.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using technical_test_api.Models;

namespace api.dataccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly employeetestingdbContext _employeeDbContext;
        private readonly IMapper _mapper;

        public CustomerDataAccess(employeetestingdbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = await _employeeDbContext.Talktoguests.AsNoTracking().ToListAsync();

            return _mapper.Map<IEnumerable<CustomerModel>>(customers);

        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersByParkCodeAndArriving(string parkCode, string arriving)
        {
            var customers = await _employeeDbContext.Talktoguests
                            .Where(x => x.ParkCode == parkCode && x.Arrived == arriving)
                            .AsNoTracking()
                            .ToListAsync();

            return _mapper.Map<IEnumerable<CustomerModel>>(customers);

        }

        public async Task SaveCustomerResponse(SpokenToGuestModel model)
        {
            var saveResponse = _employeeDbContext.SpokenToGuests.AddAsync(_mapper.Map<SpokenToGuests>(model));
            await _employeeDbContext.SaveChangesAsync();

        }
    }
}
