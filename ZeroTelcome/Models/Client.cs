using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroTelcome.Models
{
    public class Client
    {
        [Required(ErrorMessage = "Required field")]
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string LastName { get; set; }

        [Required (ErrorMessage ="Required field")]
        [MinLength(2, ErrorMessage = "4 character at least")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string City { get; set; }

        [Required]
        public bool Isactive = true;

        [Required]
        public bool Isbuisness = false;

        [Required]
        [ForeignKey("PacakgeId")]
        public int[] Lines = new int[1];

}
}