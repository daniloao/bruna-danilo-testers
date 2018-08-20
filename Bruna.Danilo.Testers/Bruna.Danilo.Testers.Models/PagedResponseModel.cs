using System;
using System.Collections.Generic;

namespace Bruna.Danilo.Testers.Models
{
	public class PagedResponseModel<T>
    {
		public IEnumerable<PagedColumn> Columns { get; set; }
        public IList<T> Models { get; set; }
        public int PageCount { get; set; }
    }
}
