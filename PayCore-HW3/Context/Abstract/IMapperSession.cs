using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Context.Abstract
{
    public interface IMapperSession<T> where T:class,new()
    {
        void BeginTranstaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);

        

        IQueryable<T> Entities { get; }

    }
}
