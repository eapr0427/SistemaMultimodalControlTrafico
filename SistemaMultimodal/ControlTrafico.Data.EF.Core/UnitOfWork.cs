using ControlTrafico.Data.Domain;
using ControlTrafico.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF.Core
{
    public interface IEfUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }
    public class UnitOfWork : DbContext, IEfUnitOfWork
    {
        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
        {
        }

        public DbSet<Flujo> Flujo { get; set; }
        public DbSet<RutasDisponibles> RutasDisponibles { get; set; }
        public DbSet<Ruta> Ruta { get; set; }
        public DbSet<Estacion> Estacion { get; set; }
        public DbSet<EstacionRutas> EstacionRutas { get; set; }
        public DbSet<Prueba> Prueba { get; set; }

        public void CommitChanges()
        {
            SaveChanges();
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void RollbackChanges()
        {
            ChangeTracker.Entries()
                 .ToList()
                 .ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}
