using System.ComponentModel.DataAnnotations;

namespace Form_Data.Models
{
    public class Registration
    {
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(6)]
        [MinLength(4)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(6)]
        public required string LastName{ get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telephone")]
        public required string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public required string EmailAddress { get; set;}

        
    }
}