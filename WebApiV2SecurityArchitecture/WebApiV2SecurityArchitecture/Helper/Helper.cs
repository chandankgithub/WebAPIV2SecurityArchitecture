using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApiV2SecurityArchitecture
{
    public static class Helper
    {
        public static void Write(string stage, IPrincipal principal)
        {
            Debug.WriteLine($"--------- {stage} ---------");
            if(principal != null 
                && principal.Identity != null
                && !string.IsNullOrEmpty(principal.Identity.Name))
            {
                Debug.WriteLine($"User: {principal.Identity.Name}");
            }
            else
            {
                Debug.WriteLine($"User: Unknown User");
            }

            Debug.WriteLine("\n");
        }
    }
}