using Microsoft.EntityFrameworkCore;
using BairesDev.Exam.Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BairesDev.Exam.Infraestructure.Interface
{
    public interface InterfaceUnitOfWork
    {
        InterfaceGenericRepository<Person> PersonRepository { get; }
        Task Save();
    }
}
