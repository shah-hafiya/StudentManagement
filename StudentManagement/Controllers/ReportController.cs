using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using StudentManagement.DataAccess.Context;
using System.Configuration;
using StudentManagement.Api.Entities;
using StudentManagement.Shared.Services;

namespace StudentManagement.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportManagementService reportManagementService;

        public ActionResult ShowReport()
        {
            return View();
        }

        
        public ReportController(IReportManagementService reportManagementService) 
            => this.reportManagementService = reportManagementService;
        
        // GET: Report
        public ActionResult CoursesWithSpace() 
            => View(reportManagementService.FetchCoursesWithSpace());

        public ActionResult RegisteredCourseForStudent()
            => View(reportManagementService.FetchRegisteredCourseForStudent());

        public ActionResult StudentListForCourse()
            => View(reportManagementService.FetchStudentListForCourse());

        public ActionResult StudentNotRegisteredForMaxCourse()
            => View(reportManagementService.FetchStudentNotRegisteredForMaxCourse());






    }



}
