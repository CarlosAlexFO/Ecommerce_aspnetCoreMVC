﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries;
using LojaVirtual.Models;

namespace LojaVirtual.Models
{
    public class Contato
    {   
        [Required]
        [MinLength(4)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Texto { get; set; }

    }
}
