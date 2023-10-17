using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium3App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musisz wpisać imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długie imię, maksymalnie 100 znaków!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Musisz podać email!")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email, brak znaku @")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Niepoprawny numer telefonu, wpisz cyfry!")]
        public string Phone { get; set; }
        
        public DateTime Birth { get; set; }



    }
}
