using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntitiesCL;
using ServicesCL;

namespace MVCUsingUnityContainer.Controllers
{
    public class InstitutionController : Controller
    {
        private IInstitutionServices institutionServices;
        public InstitutionController(IInstitutionServices institutionServices)
        {
            this.institutionServices = institutionServices;
        }
        // GET: Institution
        public ActionResult Index()
        {
            return View(this.institutionServices.GetInstitutionByID(1));
        }
    }
}