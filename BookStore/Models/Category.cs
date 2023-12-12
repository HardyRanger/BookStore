using BookStore.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BookStore.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
