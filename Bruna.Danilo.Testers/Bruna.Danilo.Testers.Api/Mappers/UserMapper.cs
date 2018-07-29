using System;
using Bruna.Danilo.Testers.Api.Models;
using Bruna.Danilo.Testers.Database.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bruna.Danilo.Testers.Api.Mappers
{
    public static class UserMapper
	{
		
		public static User ToEntity(this RegisterModel model, IdentityUser identityUser)
        {
			var user = new User();
			user.Id = identityUser.Id;
			user.UserName = model.Name;
			user.NormalizedUserName = identityUser.NormalizedUserName;
			user.Email = model.Email;
			user.NormalizedEmail = identityUser.NormalizedEmail;
			user.EmailConfirmed = identityUser.EmailConfirmed;
			user.PasswordHash = identityUser.PasswordHash;
			user.SecurityStamp = identityUser.SecurityStamp;
			user.ConcurrencyStamp = identityUser.ConcurrencyStamp;
			user.PhoneNumber = identityUser.PhoneNumber;
			user.PhoneNumberConfirmed = identityUser.PhoneNumberConfirmed;
			user.TwoFactorEnabled = identityUser.TwoFactorEnabled;
			user.LockoutEnd = identityUser.LockoutEnd;
			user.LockoutEnabled = identityUser.LockoutEnabled;
			user.AccessFailedCount = identityUser.AccessFailedCount;
			user.FullName = model.FullName;
			user.Sex = model.Sex;
			user.City = model.City;
			user.AcceptTerms = model.AcceptTerms;

			return user;
        }
    }
}
