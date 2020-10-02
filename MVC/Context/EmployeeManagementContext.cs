using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC.Context
{
    public class EmployeeManagementContext : DbContext
    {
        /*name of connection string  is passed into the constructor.
         * This name will be used in web.config file */
        public EmployeeManagementContext() : base("EmployeeManagementContextDB")
        { }

        public DbSet<MvcEmployeeModel> EmployeeModels  { get; set; }

        /*This code removes the pluralizing convention that is the default behavior for all model builders.then we will be able to 
         * create tables with singular names*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
