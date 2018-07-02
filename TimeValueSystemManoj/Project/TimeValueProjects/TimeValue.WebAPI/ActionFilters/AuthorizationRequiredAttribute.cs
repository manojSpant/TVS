﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.BusinessServices.Services;


namespace TimeValue.WebAPI.ActionFilters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {

        private const string Token = "Token";

        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //  Get API key provider
            //var provider = filterContext.ControllerContext.Configuration
            //.DependencyResolver.GetService(typeof(ITokenServices)) as ITokenServices;
            var provider = new TokenService();

            if (filterContext.Request.Headers.Contains(Token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                // Validate Token
                if (provider != null && !provider.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);

        }



    }
}