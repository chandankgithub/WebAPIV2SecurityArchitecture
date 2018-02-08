using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiV2SecurityArchitecture
{
    public class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            //use test middleware
            app.Use(typeof(TestMiddleware));

            //add routes
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute("default", "api/{controller}");

            //add filters
            configuration.Filters.Add( new TestAuthenticationFilterAttribute());

            //use api with all configuration
            app.UseWebApi(configuration);
        }


    }
}