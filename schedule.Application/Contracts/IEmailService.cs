using schedule.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.Application.Contracts
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
