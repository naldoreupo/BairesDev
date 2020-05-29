using System;
using System.Collections.Generic;
using System.Text;

namespace BairesDev.Exam.Domain.Model
{
    public class PersonDTO
    {
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CurrentRole { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public int? NumberOfRecommendations { get; set; }
        public int? NumberOfConnections { get; set; }
    }
}
