﻿using System.Web.Mvc;

namespace Northwind.Web.Controllers.Organization
{
    public class OrganizationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Organization";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Organization_default",
                "Organization/{controller}/{action}/{id}",
                new { action = "Index", id = "" }
                );
        }
    }
}


