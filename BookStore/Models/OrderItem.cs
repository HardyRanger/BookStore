using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Books ? Books { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order ? Order { get; set; }
    }
}
