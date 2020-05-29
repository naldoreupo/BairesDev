using BairesDev.Exam.Transversal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BairesDev.Exam.Infraestructure.Interface
{
    public interface InterfaceGenericRepository<TEntity> where TEntity : class
    {
        Response<bool> Save(TEntity tEntity);

    }
}
