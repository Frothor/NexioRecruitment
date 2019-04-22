using System;
using System.ComponentModel.DataAnnotations;

namespace Nexio.Models
{
    public class PersonModel : IPerson
    {
        [Required]
        [Display(Name="Imię")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Wzrost")]
        public float Height { get; set; }

        [Required]
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Kolor oczu")]
        public string EyeColor { get; set; }
    }
}