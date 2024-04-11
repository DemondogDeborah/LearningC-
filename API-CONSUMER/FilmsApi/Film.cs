using System.ComponentModel.DataAnnotations;

namespace FilmsApi
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
            
        public string Description { get; set; }
            
        public string FilmMaker { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        //public byte[] ImageData { get; set; } (para subir las fotos desde local)
    }
}
