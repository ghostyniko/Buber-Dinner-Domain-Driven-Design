using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
    }

    

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);
        builder.Property (m => m.Id )
            .ValueGeneratedNever()
            .HasConversion(
                id=>id.Value,
                value=>MenuId.Create(value));
        builder.Property(m => m.Name)
                .HasMaxLength(100);

        builder.Property(m => m.Description)
                .HasMaxLength(100);
        builder.Property(m => m.HostId)
                .HasConversion(
                    id=>id.Value,
                    value=>HostId.Create(value));
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m=>m.Sections, sb=>{
            sb.ToTable("MenuSections");
            sb.HasKey("Id","MenuId");
            sb.WithOwner().HasForeignKey("MenuId");
            sb.Property(s=>s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id=>id.Value,
                    value=>MenuSectionId.Create(value));
            sb.Property(s=>s.Name)
                .HasMaxLength(100);
            sb.Property(s=>s.Description)
                .HasMaxLength(100);
            sb.OwnsMany(sb=>sb.Items, ib=>{
                ib.ToTable("MenuItems");
                ib.WithOwner().HasForeignKey("MenuSectionId","MenuId");
                ib.Property(i=>i.Id)
                  .ValueGeneratedNever()
                  .ApplyConversion<MenuItemId>();
                //   .HasConversion(
                //     id=>id.Value,
                //     value=>MenuItemId.Create(value));

            });
        });
    }
}