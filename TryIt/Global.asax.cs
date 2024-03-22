﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TryIt
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["TotalUserSessions"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Application.Lock();
            
            //Application.Unlock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Application.Lock();
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
            //Application.Unlock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application["LastOpened"] = DateTime.Now.ToString();
        }

    }
}