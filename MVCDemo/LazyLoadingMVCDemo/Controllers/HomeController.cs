using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LazyLoadingMVCDemo.Models;

namespace LazyLoadingMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public const int RecordsPerPage = 20;
        List<Project> projectData;

        public HomeController()
        {
            ViewBag.RecordsPerPage = RecordsPerPage;
        }
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("GetProjects");
        }

        public ActionResult GetProjects(int? PageNum)
        {
            PageNum = PageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if(Request.IsAjaxRequest())
            {
                var projects = GetRecordsPerPage(PageNum.Value);
                ViewBag.IsEndOfRecords = (projects.Any());
                return PartialView("_ProjectData", projects);
            }
            else
            {
                var projectRep = new ProjectRepository();
                projectData = projectRep.GetProjectList();
                ViewBag.TotalNumberProjects = projectData.Count;
                ViewBag.Projects = GetRecordsPerPage(PageNum.Value);
                return View("Index");
            }
        }

        public List<Project> GetRecordsPerPage(int pageNum)
        {
            var projectRep = new ProjectRepository();
            projectData = projectRep.GetProjectList();
            int from = (RecordsPerPage * pageNum);
            var tempList = (from rec in projectData
                            select rec).Skip(from).Take(20).ToList<Project>();
            return tempList;
        }
    }
}