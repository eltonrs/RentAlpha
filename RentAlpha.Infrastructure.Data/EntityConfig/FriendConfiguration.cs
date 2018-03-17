using RentAlpha.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAlpha.Infrastructure.Data.EntityConfig
{
  public class FriendConfiguration : EntityTypeConfiguration<Friend>
  {
    public FriendConfiguration()
    {
      int orderOfColumns = 1;

      Property(field => field.FriendId)
        .HasColumnOrder(orderOfColumns++)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      Property(field => field.FirstName)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired()
        .HasMaxLength(256);

      Property(field => field.LastaName)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired()
        .HasMaxLength(256);

      Property(field => field.NickName)
        .HasColumnOrder(orderOfColumns++);

      Property(field => field.Birthday)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();

      Property(field => field.Email)
        .HasColumnOrder(orderOfColumns++)
        .HasMaxLength(253);

      Property(field => field.CreateDate)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();
    }
  }
}
