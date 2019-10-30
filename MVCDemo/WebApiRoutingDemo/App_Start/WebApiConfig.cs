﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Dispatcher;
using WebApiRoutingDemo.Custom;

namespace WebApiRoutingDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //config.Routes.MapHttpRoute(
            //    name: "Version1",
            //    routeTemplate: "api/v1/students/{id}",
            //    defaults: new { id = RouteParameter.Optional, Controller = "StudentsV1" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Version2",
            //    routeTemplate: "api/v2/students/{id}",
            //    defaults: new { id = RouteParameter.Optional, Controller = "StudentsV2" }
            //    );



            //Replace the default controller selector with the Custom controller selector.
            //here default controller selector is IHttpControllerSelector.
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));
        }
    }
}