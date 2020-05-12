using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_GAMK_Lab3.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string  MestoZiveenje { get; set; }
    }
}