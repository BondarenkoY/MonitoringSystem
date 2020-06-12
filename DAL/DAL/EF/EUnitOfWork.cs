using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;


namespace DAL.EF
{
    class EUnitOfWork
        : IUnitOfWork
    {
        private orderContext db;
        private addedRepository AddedRepository;
        private locationRepository LocationRepository;
        private operatorRepository OperatorRepository;
        private situationRepository SituationRepository;

        public EUnitOfWork(orderContext context)
        {
            db = context;
        }
        public IAddedRepository added
        {
            get
            {
                if (AddedRepository == null)
                    AddedRepository = new addedRepository(db);
                return AddedRepository;
            }
        }
        public ILocationRepository location
        {
            get
            {
                if (LocationRepository == null)
                    LocationRepository = new locationRepository(db);
                return LocationRepository;
            }
        }

        public IOperatorRepository @operator
        {
            get
            {
                if (OperatorRepository == null)
                    OperatorRepository = new operatorRepository(db);
                return OperatorRepository;
            }
        }

        public ISituationRepository situation
        {
            get
            {
                if (SituationRepository == null)
                    SituationRepository = new situationRepository(db);
                return SituationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}