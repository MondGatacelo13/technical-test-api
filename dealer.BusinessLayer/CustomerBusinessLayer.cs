using api.common.Model;
using api.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dealer.BusinessLayer
{
    public class CustomerBusinessLayer : ICustomerBusinessLayer
    {
        private readonly ICustomerDataAccess _customerDataAccess;

        public CustomerBusinessLayer(ICustomerDataAccess tempCustomerEntityDataAccess)
        {
            _customerDataAccess = tempCustomerEntityDataAccess;
        }


        public async Task<IEnumerable<CustomerModel>> GetAll()
        {   
            return await _customerDataAccess.GetAll();
        }


        public async Task<IEnumerable<CustomerModel>> GetCustomersByParkCodeAndArriving(string parkCode, string arriving)
        {
           return await _customerDataAccess.GetCustomersByParkCodeAndArriving(parkCode, arriving);
        }

        public async Task SaveCustomerResponse(SpokenToGuestModel model)
        {
             await _customerDataAccess.SaveCustomerResponse(model);
        }
    }
}
