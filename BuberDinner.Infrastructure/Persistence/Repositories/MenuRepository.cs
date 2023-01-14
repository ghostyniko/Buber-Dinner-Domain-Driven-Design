using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BubberDinnerDbContext _dbContext;

    public MenuRepository(BubberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Menu menu)
    {
        await _dbContext.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Menu?> GetMenuById(MenuId id)
    {
        return await _dbContext.FindAsync<Menu>(id);
    }
}
