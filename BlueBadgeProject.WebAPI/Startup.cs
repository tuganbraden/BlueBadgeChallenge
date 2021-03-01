using System;
using System.Collections.Generic;
using System.Linq;
using BlueBadgeProject.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BlueBadgeProject.WebAPI.Startup))]

namespace BlueBadgeProject.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
        
    }
}
