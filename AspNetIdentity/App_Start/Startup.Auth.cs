using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AspNetIdentity.Models.IdentityModels;

namespace AspNetIdentity
{

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        }
    }
}