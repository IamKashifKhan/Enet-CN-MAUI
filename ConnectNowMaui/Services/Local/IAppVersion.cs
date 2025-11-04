using System;
namespace ConnectNow.Services.Local
{
    public interface IAppVersion
    {
        string GetIdentifier();
        string GetVersion();
        string GetBuild();
    }
}

