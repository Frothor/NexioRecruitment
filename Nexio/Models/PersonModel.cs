using System;
using System.ComponentModel.DataAnnotations;
using Nexio.CustomAnnotations;

namespace Nexio.Models
{
    public class PersonModel
    {
        [Required]
        [Display(Name="Imię")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Wzrost")]
        [Range(0.00, 3.00, ErrorMessage = "Wartość musi być z zakresu 0,00 - 3.00.")]
        public float Height { get; set; }

        [Required]
        [Display(Name = "Data urodzenia")]
        [MustBeOfAge(ErrorMessage = "Osoba musi być pełnoletnia.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Kolor oczu")]
        public string EyeColor { get; set; }
    }
}