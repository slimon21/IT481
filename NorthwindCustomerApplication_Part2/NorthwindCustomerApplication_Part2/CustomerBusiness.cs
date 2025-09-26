using System;
using System.Collections.Generic;
using NorthwindCustomerApp.Models;

namespace NorthwindCustomerApp
{
    public class CustomerBusiness
    {
        private readonly CustomerDataAccess _dataAccess;
        private readonly UserContext _user;

        public CustomerBusiness(
            string server,
            string database,
            string username,
            string password,
            UserContext userContext)
        {
            _dataAccess = new CustomerDataAccess(server, database, username, password);
            _user = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        private void DemandRole(params AppRole[] allowed)
        {
            foreach (var role in allowed)
            {
                if (_user.Role == role) return;
            }
            throw new UnauthorizedAccessException("Current user is not authorized for this action.");
        }


        public int GetCustomerCount()
        {
            DemandRole(AppRole.Viewer, AppRole.Manager, AppRole.Admin);
            return _dataAccess.GetCustomerCount();
        }

        public List<string> GetCustomerLastNames()
        {
            DemandRole(AppRole.Manager, AppRole.Admin);
            return _dataAccess.GetCustomerLastNames();
        }

        public int GetEmployeeCount()
        {
            DemandRole(AppRole.Manager, AppRole.Admin);
            return _dataAccess.GetEmployeeCount();
        }

        public List<string> GetEmployeeNames()
        {
            DemandRole(AppRole.Admin);
            return _dataAccess.GetEmployeeNames();
        }

        public int GetOrderCount()
        {
            DemandRole(AppRole.Viewer, AppRole.Manager, AppRole.Admin);
            return _dataAccess.GetOrderCount();
        }

        public List<string> GetOrderSummaries()
        {
            DemandRole(AppRole.Viewer, AppRole.Manager, AppRole.Admin);
            return _dataAccess.GetOrderSummaries();
        }
    }
}
