﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Projekt.Models
{
    public class Photo
    {
        // Photo - data i godzina, opis, aparat, autor, rozdzielczość, format
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj Datę")]
        public DateTime? Wykonano { get; set; }

   
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długi opis, maksymalnie 100 znaków.")]
        public string? Opis { get; set; }

        [Required(ErrorMessage = "Musisz wpisać nazwę aparatu")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długa nazwa aparatu, maksymalnie 100 znaków.")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Podaj imię i nazwisko autora")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Podaj rozdzielczość zdjęcia")]
        public string Rozdzielczość { get; set; }

        [Required(ErrorMessage = "Podaj Format")]
        public string Format { get; set; }
        
    }
}
