using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Contracts
{
    public interface ISmsSevice<T>
    {
        Task<T> SendSms(string from, string to, string text);
    }
}
