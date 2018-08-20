using System;
using System.Collections.Generic;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Models;
using System.Linq;
namespace Bruna.Danilo.Testers.Api.Mappers
{
	public static class UserRoleMapper
    {


        public static UserRoleModel ToModel(this UserRole entity)
        {
			return new UserRoleModel()
			{
				RoleId = entity.RoleId,
				UserId = entity.UserId
			};
        }

		public static IList<UserRoleModel> ToModels(this IList<UserRole> entities)
        {
			return entities.Select(current => current.ToModel()).ToList();
        }
    }
}
