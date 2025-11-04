using System;
namespace EnetCNMAUI.LocalCache
{
    public class LocalCacheKeys
    {
   
        public static string PlanDetails = "PlanDetails";

        public static string BusinessItem(int businessKey)
        {
            return string.Format("LeadDetail_{0}", businessKey);
        }
        
    }

}

