using System;
namespace Bruna.Danilo.Testers.Models.Extensions
{
    public static class StringExtensions
    {
		public static string FirstLetterToLower(this string text)
		{
			if (String.IsNullOrEmpty(text))
				return text;

			var array = text.ToCharArray();

			array[0] = Char.ToLower(array[0]);
            
			return new String(array);
		}

		public static string FirstLetterToUpper(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return text;

            var array = text.ToCharArray();

            array[0] = Char.ToUpper(array[0]);
            
            return new String(array);
        }
    }
}
