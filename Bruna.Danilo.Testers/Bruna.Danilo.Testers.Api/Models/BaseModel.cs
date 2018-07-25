using System;
using System.Collections.Generic;
using Bruna.Danilo.Testers.Api.Infraestructure;

namespace Bruna.Danilo.Testers.Api.Models
{
    public class BaseModel
    {
		public Dictionary<string, string> ModelErrors { get; set; }

		public BaseModel(){
			ModelErrors = new Dictionary<string, string>();
		}


		public void AddModelError(string propertyName, string message){
			this.ModelErrors.Add($"model.{propertyName.FirstLetterToLower()}", message);

		}
    }
}
