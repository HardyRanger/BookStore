using BookStore.Models;

namespace BookStore.Data.ViewModels
{
    public class DropDownVM
    {
        public DropDownVM()
        {
            Authors = new List<Author>();
            Categories = new List<Category>();
        }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
