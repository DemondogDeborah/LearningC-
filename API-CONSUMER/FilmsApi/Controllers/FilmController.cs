using FilmsApi.Data;
using FilmsApi.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {

        private readonly AppDbContext _context;
        private ResponseDto _response;

        public FilmController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetFilms")]
        public ResponseDto GetFilms()
        {
            try
            {
                IEnumerable<Film> films = _context.Films.ToList();
                _response.Data = films;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        [HttpGet("GetFilmById/{id}")]
        public ResponseDto GetFilmById(int id)
        {
            try
            {
                var film = _context.Films.FirstOrDefault(f => f.Id == id);
                _response.Data = film;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }



        [HttpGet("GetFilmByTitle/{title}")]
        public ResponseDto GetFilmByTitle(string title)
        {
            try
            {
                var film = _context.Films.FirstOrDefault(f => f.Title == title);
                _response.Data = film;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPost("PostFilm")]
        public ResponseDto PostFilm([FromBody] Film film)
        {
            try
            {
                _context.Films.Add(film);
                _context.SaveChanges();

                _response.Data = film;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut("PutFilm")]
        [Authorize]
        public ResponseDto PutFilm([FromBody] Film film)
        {
            try
            {
                _context.Films.Update(film);
                _context.SaveChanges();

                _response.Data = film;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }




        [HttpDelete("DeleteFilm/{id}")]
        [Authorize]
        public ResponseDto DeleteFilm(int id)
        {
            try
            {
                var film = _context.Films.FirstOrDefault(f => f.Id == id);
                _context.Remove(film);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
