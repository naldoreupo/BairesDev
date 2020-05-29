using Microsoft.EntityFrameworkCore;
using BairesDev.Exam.Infraestructure.Entity;
using BairesDev.Exam.Infraestructure.Interface;
using BairesDev.Exam.Infraestructure.Models;
using System.Threading.Tasks;

namespace BairesDev.Exam.Infraestructure
{
    public class UnitOfWork : InterfaceUnitOfWork
    {
        private readonly ActiveDBContext _context;
        private InterfaceGenericRepository<Person> _personRepository;
        public UnitOfWork(ActiveDBContext context) 
        {
            _context = context;
        }
        public InterfaceGenericRepository<Person> PersonRepository
        {
            get
            {
                return _personRepository ??
                    (_personRepository = new GenericRepository<Person>(_context));
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
