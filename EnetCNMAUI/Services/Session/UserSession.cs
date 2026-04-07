using EnetCNMAUI.Domain.Models.MVC;

namespace EnetCNMAUI.Services.Session
{
    public class UserSession : IUserSession
    {
        public AALUser CurrentUser { get; set; } = new();
        public PlanDetails PlanDetails { get; set; } = new();
        public string DiscountCode { get; set; } = "";
        public bool IsLoggedIn => CurrentUser?.UserKey > 0;
    }
}
