﻿using Northwind.Core;
using SharpArch.Core;
using Northwind.Core.DataInterfaces;
using System.Collections.Generic;

namespace Northwind.ApplicationServices
{
    public interface IDashboardService
    {
        DashboardService.DashboardSummaryDto GetDashboardSummary();
    }

    /// <summary>
    /// This is an "application service" for coordinating the activities required by the view.
    /// Arguably, this service is so simplistic that I would lean towards putting this "logic"
    /// in the controller itself...but others would argue that ALL coordination with other services,
    /// such as repositories should be done within an application service, such as this.  The 
    /// nice thing about this service is that it encapsulates a bit of logic that is agnostic of
    /// the technology context; e.g., web services, ASP.NET MVC, WCF, console app, etc.  Consequently,
    /// it's easy to reuse without having any duplicated code amongst the various project types.
    /// </summary>
    public class DashboardService : IDashboardService
    {
        /// <summary>
        /// Since DashboardService is registered as a component within __NAME__.Web.CastleWindsor.ComponentRegistrar,
        /// its dependencies (e.g. supplierRepository) will automatically be injected when this service is
        /// injected into the constructor of another object (e.g., __NAME__.Web.Controllers.DashboardController).
        /// 
        /// Note that the constructor isn't limited to a single dependency.  You can pass in multiple repositories,
        /// WCF services (e.g., as in __NAME__.Web.Controllers.TerritoriesController), or even other application
        /// services if you wanted to make it really ugly.
        /// </summary>
        public DashboardService(ISupplierRepository supplierRepository) {
            Check.Require(supplierRepository != null, "supplierRepository may not be null");

            this.supplierRepository = supplierRepository;
        }

        /// <summary>
        /// Uses the repository and domain layer to gather a few summary items for a dashboard view.
        /// </summary>
        public DashboardSummaryDto GetDashboardSummary() {
            DashboardSummaryDto dashboardSummaryDto = new DashboardSummaryDto();

            IList<Supplier> allSuppliers = supplierRepository.GetAll();

            // Arguably, the following two collection extension methods could be moved to 
            // ISupplierRepository, but since there's only 29 suppliers in the __NAME__ database, 
            // pushing this to the data layer isn't going to buy us any performance improvement.  
            // Consequently, IMO, I lean towards keeping such logic on the application side.
            // Furthermore, you should let a profiler inform you if have a bottle neck and then decide 
            // to optimize on the application or by pushing the logic and/or filtering to the database.
            dashboardSummaryDto.SuppliersCarryingMostProducts = allSuppliers.FindSuppliersCarryingMostProducts();
            dashboardSummaryDto.SuppliersCarryingFewestProducts = allSuppliers.FindSuppliersCarryingFewestProducts();

            return dashboardSummaryDto;
        }

        /// <summary>
        /// Arguably, this could go into a dedicated DTO layer.
        /// </summary>
        public class DashboardSummaryDto
        {
            public IList<Supplier> SuppliersCarryingMostProducts { get; set; }
            public IList<Supplier> SuppliersCarryingFewestProducts { get; set; }
        }

        private readonly ISupplierRepository supplierRepository;
    }
}
