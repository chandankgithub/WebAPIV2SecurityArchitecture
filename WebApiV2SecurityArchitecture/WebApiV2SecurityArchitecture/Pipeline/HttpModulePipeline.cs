using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiV2SecurityArchitecture.Pipeline
{
    public class HttpModulePipeline : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            //context.Request.RequestContext.HttpContext.User;
            context.BeginRequest += Context_BeginRequest;
            //context.BeginRequest += WriteLine(context);
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;
            Helper.Write("HttpModule", context.Request.RequestContext.HttpContext.User);
        }
        
    }
}