using System;
namespace Bruna.Danilo.Testers.Models
{
    public class PagedColumn
    {
		public const string NUMBER = "number";
		public const string DATETIME = "datetime";
		public const string STRING = "string";

		public string ColumnHeader { get; set; }
		public string ColumnType { get; set; }
		public string Format { get; set; }
		public string PropertyName { get; set; }

    }
}
