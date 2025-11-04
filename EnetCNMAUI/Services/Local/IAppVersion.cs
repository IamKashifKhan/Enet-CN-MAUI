using System;
namespace EnetCNMAUI.Services.Local
{
    public interface IAppVersion
    {
        string GetIdentifier();
        string GetVersion();
        string GetBuild();
    }
}

