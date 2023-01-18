using GreenLeaves.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLeaves.Domain.Services.Contracts
{
    public interface IContactService
    {
        Task<List<CityAndState>> GetCityAndState();
        Task<string> SendMessage(ContactViewModel contact);
    }
}
