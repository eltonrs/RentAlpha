using RentAlpha.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAlpha.Infrastructure.Data.EntityConfig
{
  public class GameConfiguration : EntityTypeConfiguration<Game>
  {
    public GameConfiguration()
    {
      int orderOfColumns = 1;

      Property(field => field.GameId)
        .HasColumnOrder(orderOfColumns++)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

      Property(field => field.Title)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();

      Property(field => field.AgeRating)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();

      Property(field => field.CreateDate)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();

      Property(field => field.ReleaseDate)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();

      Property(field => field.Rented)
        .HasColumnOrder(orderOfColumns++)
        .IsRequired();

      Property(field => field.DateToDeliver)
        .HasColumnOrder(orderOfColumns++);

      Property(field => field.FriendId)
        .HasColumnOrder(orderOfColumns++);
    }
  }
}
