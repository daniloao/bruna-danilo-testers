using System;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class UserDao
    {
		private TestersContext _testersContext;

		public UserDao(TestersContext testersContext)
        {
			this._testersContext = testersContext;
        }

		public User GetById(string userId){
			return this._testersContext.Users.Find(userId);
		}

		public int Update(User user){
			var currentUser = this.GetById(user.Id);

			if (currentUser == null)
				throw new Exception($"Usuario nao encontrado: {user.Id}");

			this.MapUser(user, ref currentUser);
			return _testersContext.SaveChanges();
		}

		private void MapUser(User user, ref User currentUser)
		{
			currentUser.UserName = user.UserName;
            currentUser.NormalizedUserName = user.NormalizedUserName;
            currentUser.Email = user.Email;
            currentUser.NormalizedEmail = user.NormalizedEmail;
            currentUser.EmailConfirmed = user.EmailConfirmed;
            currentUser.PasswordHash = user.PasswordHash;
            currentUser.SecurityStamp = user.SecurityStamp;
            currentUser.ConcurrencyStamp = user.ConcurrencyStamp;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            currentUser.TwoFactorEnabled = user.TwoFactorEnabled;
            currentUser.LockoutEnd = user.LockoutEnd;
            currentUser.LockoutEnabled = user.LockoutEnabled;
            currentUser.AccessFailedCount = user.AccessFailedCount;
            currentUser.FullName = user.FullName;
            currentUser.Sex = user.Sex;
            currentUser.City = user.City;
            currentUser.AcceptTerms = user.AcceptTerms;
			currentUser.Estado = user.Estado;
		}
	}
}
