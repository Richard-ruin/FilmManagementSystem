using System.ComponentModel.DataAnnotations;

namespace FilmManagementSystem.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Judul film wajib diisi")]
        [StringLength(100, ErrorMessage = "Judul film maksimal 100 karakter")]
        [Display(Name = "Judul Film")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama sutradara wajib diisi")]
        [StringLength(100, ErrorMessage = "Nama sutradara maksimal 100 karakter")]
        [Display(Name = "Sutradara")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tahun rilis wajib diisi")]
        [Display(Name = "Tahun Rilis")]
        [Range(1900, 2100, ErrorMessage = "Tahun rilis harus antara 1900-2100")]
        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Genre maksimal 50 karakter")]
        [Display(Name = "Genre")]
        public string? Genre { get; set; }

        [Display(Name = "Durasi (menit)")]
        [Range(1, 999, ErrorMessage = "Durasi harus antara 1-999 menit")]
        public int? Duration { get; set; }

        [StringLength(500, ErrorMessage = "Deskripsi maksimal 500 karakter")]
        [Display(Name = "Deskripsi")]
        public string? Description { get; set; }

        [Display(Name = "Tanggal Ditambahkan")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}