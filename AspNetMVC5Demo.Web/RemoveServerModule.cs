using System;
using System.Web;

namespace AspNetMVC5Demo.Web
{
    public class RemoveServerModule : System.Web.IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += Context_PreSendRequestHeaders;
        }

        private void Context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication context = sender as HttpApplication;
            context?.Response.Headers.Remove("Server");
        }
    }
}