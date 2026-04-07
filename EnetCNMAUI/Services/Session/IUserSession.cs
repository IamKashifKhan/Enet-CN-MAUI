using EnetCNMAUI.Domain.Models.MVC;

namespace EnetCNMAUI.Services.Session
{
    public interface IUserSession
    {
        AALUser CurrentUser { get; set; }
        PlanDetails PlanDetails { get; set; }
        string DiscountCode { get; set; }
        bool IsLoggedIn { get; }
    }
}
