using SocialNetwork.Core.Application.DTOS.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interface.Services
{
    public interface IEmailServices
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
