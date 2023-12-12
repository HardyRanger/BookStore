using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public int BooksId { get; set; }  
        public Books Books { get; set; }

        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
