using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using AspNetIdentity.Controllers;
using static AspNetIdentity.Models.IdentityModels;

namespace AspNetIdentity.Models
{
    public class IdentityModels
    {
        public class ApplicationUser:IdentityUser
        {
            public DateTime? DateOfBirth { get; set; }
        }

        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext():base("AspNetIdentityCS")
            {
            }
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var store = new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>());
                var manager = new ApplicationUserManager(store);
                return manager;
            }

        }

    }
}