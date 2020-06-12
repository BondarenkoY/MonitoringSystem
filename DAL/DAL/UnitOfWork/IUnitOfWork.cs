using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddedRepository added { get; }
        ILocationRepository location { get; }
        IOperatorRepository @operator { get; }
        ISituationRepository situation { get; }
        void Save();

    }
}