using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public static class ConfigurationExtensions
    {
        public static PropertyBuilder<T> ApplyConversion<T>(this PropertyBuilder<T> builder)
            where T:EntityId<T>,new()
        {
            builder.HasConversion<Guid>(
                id=>id.Value,
                value=> EntityId<T>.Create(value));
            return builder;
        }
    }
}