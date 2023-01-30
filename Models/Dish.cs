using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesDish.Models
{
    public class Dish
    {
        public int ID { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
        [Display(Name = "Nazwa")]
		public string Name { get; set; } = string.Empty;

        [Display(Name = "Opis")]
        public string Description { get; set; } = string.Empty;

		[Range(1, 100)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Typ")]
        public string Type { get; set; } = string.Empty;

        [Display(Name = "Zdjęcie")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}