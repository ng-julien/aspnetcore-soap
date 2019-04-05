namespace Infrastructure.Repositories.Entities
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    public interface IAdventureworks2017Context : IDisposable
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    }

    public partial class Adventureworks2017Context : IAdventureworks2017Context
    {
    }
}