using System;
using System.Net.Http;
using Xunit;

namespace Bruna.Danilo.Testers.Test
{
	public class AccountControllerTest
    {
        [Fact]
        public async void CreateUser()
        {
			var client = new HttpClient();
			var content = new StringContent("test");
          
			var response = await client.PostAsync(
				"http://localhost:26116/api/account/login", content);
            response.EnsureSuccessStatusCode();

            Assert.Equal(response.Content.ToString(), "logins");
        }
    }
}
