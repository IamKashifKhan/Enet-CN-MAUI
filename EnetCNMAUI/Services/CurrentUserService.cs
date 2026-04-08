using EnetCNMAUI.Domain.Models.MVC;

namespace EnetCNMAUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public AALUser CurrentUser { get; set; } = new AALUser();
    }
}
