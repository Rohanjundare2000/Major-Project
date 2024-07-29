using Microsoft.AspNetCore.Authorization; // Provides authorization functionality
using Microsoft.AspNetCore.Mvc; // Provides functionalities for MVC pattern

namespace BookShoppingCartMvcUI.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))] // Ensures only users with the 'Admin' role can access this controller
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepo; // Repository for Genre data

        public GenreController(IGenreRepository genreRepo)
        {
            _genreRepo = genreRepo; // Dependency injection for genre repository
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepo.GetGenres(); // Retrieves list of genres asynchronously
            return View(genres); // Passes the list of genres to the view
        }
        public IActionResult AddGenre()
        {
            return View(); // Returns the view for adding a genre
        }






        [HttpPost] // Specifies this action handles POST requests
        public async Task<IActionResult> AddGenre(GenreDTO genre)
        {
            if (!ModelState.IsValid) // Checks if the model state is valid
            {
                return View(genre); // Returns the same view with the current model if invalid
            }
            try
            {
                var genreToAdd = new Genre { GenreName = genre.GenreName, Id = genre.Id }; // Maps GenreDTO to Genre entity
                await _genreRepo.AddGenre(genreToAdd); // Adds the new genre asynchronously
                TempData["successMessage"] = "Genre added successfully"; // Sets a success message
                return RedirectToAction(nameof(AddGenre)); // Redirects to the AddGenre action
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Genre could not be added!"; // Sets an error message
                return View(genre); // Returns the same view with the current model
            }
        }



        public async Task<IActionResult> UpdateGenre(int id)
        {
            var genre = await _genreRepo.GetGenreById(id); // Retrieves genre by id asynchronously
            if (genre is null)
                throw new InvalidOperationException($"Genre with id: {id} not found"); // Throws an exception if genre not found

            var genreToUpdate = new GenreDTO
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
            return View(genreToUpdate); // Passes the genre to the view for updating
        }

        [HttpPost] // Specifies this action handles POST requests
        public async Task<IActionResult> UpdateGenre(GenreDTO genreToUpdate)
        {
            if (!ModelState.IsValid) // Checks if the model state is valid
            {
                return View(genreToUpdate); // Returns the same view with the current model if invalid
            }
            try
            {
                var genre = new Genre { GenreName = genreToUpdate.GenreName, Id = genreToUpdate.Id }; // Maps GenreDTO to Genre entity
                await _genreRepo.UpdateGenre(genre); // Updates the genre asynchronously
                TempData["successMessage"] = "Genre updated successfully"; // Sets a success message
                return RedirectToAction(nameof(Index)); // Redirects to the Index action
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Genre could not be updated!"; // Sets an error message
                return View(genreToUpdate); // Returns the same view with the current model
            }
        }

        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreRepo.GetGenreById(id); // Retrieves genre by id asynchronously
            if (genre is null)
                throw new InvalidOperationException($"Genre with id: {id} not found"); // Throws an exception if genre not found

            await _genreRepo.DeleteGenre(genre); // Deletes the genre asynchronously
            return RedirectToAction(nameof(Index)); // Redirects to the Index action
        }
    }
}
