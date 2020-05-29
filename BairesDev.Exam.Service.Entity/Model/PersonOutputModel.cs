using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BairesDev.Exam.Service.Model
{
    public class PersonOutputModel
    {
        public FileStreamResult OutputFile { get; set; }
    }
}
