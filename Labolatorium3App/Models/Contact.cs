using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3App.Models
{
    public class Contact
    {
        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }


        [HiddenInput]
        public int Id { get; set; }


        [Required(ErrorMessage = "Musisz wpisać imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długie imię, maksymalnie 100 znaków!")]
        [Display(Name = "Wpisz imię")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Musisz podać email!")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email, brak znaku @")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Niepoprawny numer telefonu, wpisz cyfry!")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

    }
}
