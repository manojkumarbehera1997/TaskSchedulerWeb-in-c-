﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TaskScheduler;

namespace TaskSchedulerWeb
{
    /// <summary>
    /// Summary description for TaskService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TaskService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            TaskSchedulerClass objScheduler;
            objScheduler = new TaskSchedulerClass();
            objScheduler.Connect();
            ITaskFolder root = objScheduler.GetFolder("\\MDM");
            return "Hello World";
        }
    }
}
