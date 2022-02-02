using api.common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api.Common.Interfaces
{
    public interface ICustomerDataAccess
    {
        Task<IEnumerable<CustomerModel>> GetAll();
        Task<IEnumerable<CustomerModel>> GetCustomersByParkCodeAndArriving(string parkCode, string arriving);
        Task SaveCustomerResponse(SpokenToGuestModel model);
    }
}
