﻿using BookKeeperNewJosh.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Repository
{
    public class GenericUnitOfWork:IDisposable
    {
        private BookKeeperEntities2 DBEntity = new BookKeeperEntities2();
        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new GenericRepository<Tbl_EntityType>(DBEntity);
        }
        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}