using NHibernate;
using PayCore_HW3.Context.Abstract;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore_HW3.Context.Concrete
{
    public class ContainerMapperSession :IMapperSession<Container>
    {
        private readonly ISession session;
        private ITransaction transaction;
        public ContainerMapperSession(ISession session)
        {
            this.session = session;
        }
        public IQueryable<Container> Entities => session.Query<Container>();

        public void BeginTranstaction()
        {
            transaction = session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Delete(Container entity)
        {
            session.Delete(entity);
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(Container entity)
        {
            session.Save(entity);
        }

        public void Update(Container entity)
        {
            session.Update(entity);
        }

        public void VehicleIdDelete(List<Container> container)
        {
            session.Delete(container);
        }
    }
}
