using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_App_BioWell.Models;
using System.Security.Claims;

namespace Web_App_BioWell.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext DataBase = new ApplicationDbContext();

        private string CurrentUserEmail = ClaimsPrincipal.Current.Identity.Name;
        
        public BaseController()
        {
            this.DataBase = new ApplicationDbContext();
            //this.CurrentUser = db.UserProfiles.Include(d => d.Departments).AsNoTracking().FirstOrDefault(x => x.Email == CurrentUserEmail);
        }
    }
}