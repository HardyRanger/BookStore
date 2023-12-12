
using BookStore.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Books:IEntityBase
    {
         [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int AuthorId{ get; set; }
  
        public Author ? Author { get; set; }

        public int CatId { get; set; }
       
        public Category? Category { get; set; }
    }
    
}
