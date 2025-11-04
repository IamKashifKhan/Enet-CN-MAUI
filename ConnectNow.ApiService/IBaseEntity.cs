using System;
namespace ConnectNow.Services
{
    public interface IBaseEntity
    {
        int ID { get; set; }
        string UserID { get; set; }
    }
}
