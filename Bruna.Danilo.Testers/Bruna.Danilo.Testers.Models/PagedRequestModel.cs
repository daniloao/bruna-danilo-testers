using System;
using System.Collections.Generic;

namespace Bruna.Danilo.Testers.Models
{
	public class PagedRequestModel<T>
    {
        public T Model { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
		public SortModel SortModel { get; set; }
		public string FiltrarPorTexto { get; set; }
    }
}
