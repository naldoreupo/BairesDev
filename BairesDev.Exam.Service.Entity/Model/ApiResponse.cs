using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BairesDev.Exam.Service.Model
{
    public class ApiResponse<TEntity>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public TEntity Data { get; set; }
        public List<TEntity> List{ get; set; }
    }
}
