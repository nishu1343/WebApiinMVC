//using MVC.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;

//namespace MVC.Controllers
//{
//    public class EmployeeController : Controller
//    {   
//        [HttpPost]
//        public ActionResult Create([Bind(Include = "Employeeid,First_name,Last_name")] MvcEmployeeModel model)
//        {
//            model.EmployeeId = Guid.NewGuid();
//            var errors = ModelState
//    .Where(x => x.Value.Errors.Count > 0)
//    .Select(x => new { x.Key, x.Value.Errors })
//    .ToArray();
//            if (ModelState.IsValid) 
//            {
//                db.MvcEmployeeModel.Add(model);

//                db.SaveChanges();
//            }
//            return View(model);
//        }

//        //Inorder to call web api message inside, we need to   to create an object of http client class.but its good to instantiate one and 
//        //use the object throughout the life of an app. if we create the http client object for each call.request will excess the no.of sockets available in heavy loads
//        //so,to avoid this socket exception errors, lets create a public static class,inside that will create a static httpclient object
//        //create a class "GlobalVariables.cs".
//        // GET: Employee
//        public ActionResult Index()
//        {
//            //Create mvcemployee model.name it "empList". 
//            IEnumerable<MvcEmployeeModel> empList;
//            //Call the "GetEmployees" method from EmployeeController.cs of WebApiinMVC inside Webapi project.for that .
//            //Now call GetEmployees using this 'GlobalVariables' WebApiClient .We have a http method,so we have to call 'GetAsync' and pass the remaining
//            //url from the base url("Employee").Inside thus response object,we have to result the webapiclient and 
//            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
//            //we have to convert that users into ienumerable collection.type is iemnumerable of mvc employee model.
//            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result;
//            //we have passed the employee view here
//            return View();
//            //Now we have to run both the projects.right click on solution,properties,go to startup  project,select Multiple startup projects,
//            //and select start for both the projects.
//        }

//        //this httpget method has the parameter id with default value '0' 
//        public ActionResult AddOrEdit(int id = 0)

//        {
//            //When user clicks on Edit icon, user needs to fill the details of the selected employee to edit
//            if(id==0)
//            //return a view from the action.pass the object of employeemodel class to this view. now add view
//            return View(new MvcEmployeeModel());//return empty form
//            else //for this call http method(GetEmployee(int id) of webapi project from this controller and pass the url and id
//            {
//                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/"+id.ToString()).Result;
//                //We have to convert the above into mvcEmployee model
//                return View(response.Content.ReadAsAsync<MvcEmployeeModel>().Result);
//            }
//        }

//        ////add an object of mvcEmployeeModel emp
//        //public ActionResult AddOrEdit(MvcEmployeeModel emp)
//        //{
//        //    //Inside the post operation, lets do the insert or update operation based on the Employeeid
//        //   // if (emp.EmployeeId == 0)
//        //        if ()
//        //        { //then do create operation

//        //        //To implement insert method,lets first call Http method from web Api project.go to webapi project,controller.go to EmployeeController.cs
//        //        //in http post method .We will be calling this(PostEmploye) http method from post action to insert.Pass the base address "Employee"
//        //        //and the model object 'emp'.This(GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp) Web api call will insert new records into our Employee
//        //        //table and will store the core results inside this response object
//        //        HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp).Result;

//        //        //Now Pass the success message inside Temp data.To show this message ,add script file inside index view in views folder<Employee<Index.cshtml in the end
//        //        TempData["SuccessMessage"] = "Saved Successfully";
//        //    }
//        //    else //do the update operation
//        //    { //call the http method PutEmployee
//        //        HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/"+emp.EmployeeId, emp).Result;
//        //        TempData["SuccessMessage"] = "Updated Successfully";
//        //    }

//        //    //after insert operation redirect to index action methods.
//        //    return RedirectToAction("Index");
//        //    //return a view from the action
//        //    //return View();
//        //}

//        //inside it call the webapi method deleteEmployee
//        public ActionResult Delete(int id)
//        {
//            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/"+id.ToString()).Result;

//            TempData["SuccessMessage"] = "Deleted Successfully";
//            return RedirectToAction("Index");

//        }
//    }
//    // To show some notification messages to show a message that records have been updated successfully.Add a new plugin "AlertifyJS".
//}//click on mvc project,Manage nuget packages.After installation,add a reference of it in the layout page.It will be in the content folder of mvc.
////Also add the refernce of themes in the css inside layout page and in the bottom add the script refernce of alertify

