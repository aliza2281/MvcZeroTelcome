using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroTelcome.Models
{
    public class Package
    {
        [Key]
        public int PacakgeId { get;}

        public string PackageName { get; set; }

        public int Minutes { get; set; }

        public int Giga { get; set; }

        public int callsAbroads { get; set; }

    }
}