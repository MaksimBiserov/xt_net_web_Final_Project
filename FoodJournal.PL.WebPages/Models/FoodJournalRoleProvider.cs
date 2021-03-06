﻿using System;
using System.Web.Security;

namespace FoodJournal.PL.WebPages.Models
{
    public class FoodJournalRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            if (username == "admin") return new string[] { "admin" };
            else return new string[] { };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin" && roleName == "admin") return true;
            return false;
        }

        #region Not implemented

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}