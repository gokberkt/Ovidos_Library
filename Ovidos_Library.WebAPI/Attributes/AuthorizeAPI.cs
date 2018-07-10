using Ovidos_Library.EntityLayer;
using Ovidos_Library.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ovidos_Library.WebAPI.Attributes
{
    internal class AuthorizeAPIAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                IEnumerable<string> listUsername;
                IEnumerable<string> listPassword;


                bool result = false;
                actionContext.Request.Headers.TryGetValues("Username", out listUsername);
                actionContext.Request.Headers.TryGetValues("Password", out listPassword);

                if (listUsername != null && listPassword != null)
                {
                    string Username = listUsername.ToList()[0];
                    string Password = listPassword.ToList()[0];

                    User user = UserRepository.GetCacheUsers().FirstOrDefault(x => x.Username == Username && x.Password == Password);
                    if (user != null)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                if (!result) actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or Password Error");
            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Connection Error API");
            }

        }
    }
}