using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext

{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Member> Memberss { get; }

    DbSet<City> Cities { get;}

    DbSet<District> Districts { get; }

    DbSet<Village> Villages { get; }
    DbSet<Ecarsale> Ecarsales { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
