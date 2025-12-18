using System.ComponentModel.DataAnnotations;

namespace wmyazilim.Models
{
    public class DemoRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "İsim Soyisim alanı zorunludur.")]
        [Display(Name = "İsim Soyisim")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Firma ismi alanı zorunludur.")]
        [Display(Name = "Firma İsmi")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}