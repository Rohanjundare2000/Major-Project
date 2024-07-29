namespace BookShoppingCartMvcUI.Models.DTOs
{
    // Define the BookDisplayModel class
    public class BookDisplayModel
    {
        // A collection of Book entities to be displayed
        public IEnumerable<Book> Books { get; set; }

        // A collection of Genre entities to be displayed
        public IEnumerable<Genre> Genres { get; set; }

        // A search term to filter the list of books, initialized to an empty string
        public string STerm { get; set; } = "";

        // A genre ID to filter the list of books by genre, initialized to 0
        public int GenreId { get; set; } = 0;
    }
}
