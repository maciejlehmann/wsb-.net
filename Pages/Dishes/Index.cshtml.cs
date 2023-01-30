using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesDish.Models;
using Restuarant.Data;

namespace Restuarant.Pages.Dishes
{
	public class IndexModel : PageModel
	{
		private readonly Restuarant.Data.RestuarantContext _context;

		public IndexModel(Restuarant.Data.RestuarantContext context)
		{
			_context = context;
		}

		public IList<Dish> Dish { get; set; } = default!;
		[BindProperty(SupportsGet = true)]
		public string? SearchString { get; set; }
		public SelectList? Types { get; set; }
		[BindProperty(SupportsGet = true)]
		public string? DishType { get; set; }

		public async Task OnGetAsync()
		{
			IQueryable<string> typeQuery = from d in _context.Dish
										   orderby d.Type
										   select d.Type;

			var dishes = from d in _context.Dish
						 select d;

			if (!string.IsNullOrEmpty(SearchString))
			{
				dishes = dishes.Where(s => s.Name.Contains(SearchString));
			}

			if (!string.IsNullOrEmpty(DishType))
			{
				dishes = dishes.Where(x => x.Type == DishType);
			}
			Types = new SelectList(await typeQuery.Distinct().ToListAsync());
			Dish = await dishes.ToListAsync();
		}
	}
}
