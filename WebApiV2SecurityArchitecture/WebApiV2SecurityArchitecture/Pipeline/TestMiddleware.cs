using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace WebApiV2SecurityArchitecture
{
    public class TestMiddleware
    {
        public AppFunc _next { get; }
        public TestMiddleware(AppFunc next)
        {
            this._next = next;
        }

        public async Task Invoke(IDictionary<string,object> env)
        {
            var owinContext = new OwinContext(env);
            //authenticate user
            // bunch of code for authentication
            
            
            //setup principal. we should always consider setting up principal at middleware rather than authentication filter, authorization filer or elsewhere
            owinContext.Request.User = new GenericPrincipal(new GenericIdentity("Chandan"), new string[] { });
            Helper.Write("Middleware", owinContext.Request.User);
            await this._next(env);
        }
    }
}