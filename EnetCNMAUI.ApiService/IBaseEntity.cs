using System;
namespace EnetCNMAUI.Services
{
    public interface IBaseEntity
    {
        int ID { get; set; }
        string UserID { get; set; }
    }
}
