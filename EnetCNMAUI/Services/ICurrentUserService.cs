using EnetCNMAUI.Domain.Models.MVC;

namespace EnetCNMAUI.Services
{
    public interface ICurrentUserService
    {
        AALUser CurrentUser { get; set; }
    }
}
