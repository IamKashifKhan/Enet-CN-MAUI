using System;
namespace ConnectNow.Services.Session
{
    public class SessionManager
    {
        public SessionManager()
        {
        }
        // Static property to hold the single instance of the class
        private static readonly Lazy<SessionManager> _instance = new Lazy<SessionManager>(() => new SessionManager());

        // Public static method to provide access to the instance
        public static SessionManager Instance => _instance.Value;

        public List<string> NavigationStack { get; set; }

    }
}

