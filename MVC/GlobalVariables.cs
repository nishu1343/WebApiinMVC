using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {
        //create a http client.name it WebApiClient 
        public static HttpClient WebApiClient = new HttpClient();
        //instantiate the Httpclient object inside the constructor

        static GlobalVariables()
        {
            //set the base address.INorder to find the baseurl for this application.right click on WebApiinMVC and go to properties
            //go to websection and copy the project url and paste it here
            WebApiClient.BaseAddress = new Uri("https://localhost:44343/api");
            //clear the default request headers
            WebApiClient.DefaultRequestHeaders.Clear();
            //set the media type as json,so 
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}