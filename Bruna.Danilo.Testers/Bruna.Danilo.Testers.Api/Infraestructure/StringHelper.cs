using System;
namespace Bruna.Danilo.Testers.Api.Infraestructure
{
    public static class StringHelper
    {
		public static string FirstLetterToLower(this string text)
		{
			if (String.IsNullOrEmpty(text))
				return text;

			var array = text.ToCharArray();

			array[0] = Char.ToLower(array[0]);
            
			return new String(array);
		}
    }
}
