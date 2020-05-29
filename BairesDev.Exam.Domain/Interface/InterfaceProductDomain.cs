using BairesDev.Exam.Domain.Entity.Model;
using BairesDev.Exam.Domain.Model;
using BairesDev.Exam.Transversal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BairesDev.Exam.Domain.Interface
{
    public interface InterfacePersonDomain
    {
        Task<Response<FileOutputDTO>> GetPeopleFileWithIds(IFormFile file);
    }
}
