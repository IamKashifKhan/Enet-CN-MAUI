using EnetCNMAUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Authorization
{
    public interface ILoginService
    {
        Task Login();
        Task Logout();
    }
}
