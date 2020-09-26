using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {

        //Inorder to call web api message inside, we need to   to create an object of http client class.but its good to instantiate one and 
        //use the object throughout the life of an app. if we create the http client object for each call.request will excess the no.of sockets available in heavy loads
        //so,to avoid this socket exception errors, lets create a public static class,inside that will create a static httpclient object
        //create a class "GlobalVariables.cs".
        // GET: Employee
        public ActionResult Index()
        {
            //Create mvcemployee model.name it "empList". 
            IEnumerable<mvcEmployeeModel> empList;
            //Call the "GetEmployees" method from EmployeeController.cs of WebApiinMVC inside Webapi project.for that .
            //Now call GetEmployees using this 'GlobalVariables' WebApiClient .We have a http method,so we have to call 'GetAsync' and pass the remaining
            //url from the base url("Employee").Inside thus response object,we have to result the webapiclient and 
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            //we have to convert that users into ienumerable collection.type is iemnumerable of mvc employee model.
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            //we have passed the employee view here
            return View();
            //Now we have to run both the projects.right click on solution,properties,go to startup  project,select Multiple startup projects,
            //and select start for both the projects.
        }

        //this httpget method has the parameter id with default value '0' 
        public ActionResult AddOrEdit(int id = 0)
        {//return a view from the action.pass the object of employeemodel class to this view. now add view
            return View(new mvcEmployeeModel());
        }

        public ActionResult AddOrEdit()
        {//return a view from the action
            return View();
        }
    }
}

