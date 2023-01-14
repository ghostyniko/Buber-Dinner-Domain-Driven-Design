using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistance;

public interface IMenuRepository
{
    Task Add(Menu menu);
    Task<Menu?> GetMenuById(MenuId id);
}
