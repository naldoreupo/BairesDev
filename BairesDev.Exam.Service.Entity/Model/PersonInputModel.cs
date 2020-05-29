using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BairesDev.Exam.Service.Model
{
    public class PersonInputModel
    {
        [Required]
        public IFormFile file { get; set; }
    }
}
