using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaPractica.Models
{
    public class UsuarioCLS
    {
        [Display(Name ="Id Usuario")]
        public int Id { get; set; }
        [Display(Name = "Nombres")]
        [Required]
        [StringLength(256, ErrorMessage = "Longiutd máxima 256")]
        public string Nombre { get; set; }
        [Display(Name = "Apellidos")]
        [Required]
        [StringLength(256, ErrorMessage = "Longiutd máxima 256")]
        public string Apellidos { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }
        [Display(Name = "Telefono Celular")]
        [Required]
        [StringLength(20, ErrorMessage = "Longiutd máxima 20")]
        public string TelefonoCelular { get; set; }
        public bool Bhabilitado { get; set; }
    }
}
