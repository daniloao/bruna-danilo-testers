using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class UserRoleDao
    {
		private TestersContext _testersContext;

		public UserRoleDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public UserRole GetById(string userId, string roleId)
        {
			return this._testersContext.UserRoles.Find(userId, roleId);
        }

		public IList<UserRole> GetByUser(string userId)
		{
			return this._testersContext.UserRoles.ToList().FindAll(currentRole => currentRole.UserId == userId );
		}
	}
}
