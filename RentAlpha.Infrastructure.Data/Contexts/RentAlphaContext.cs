using RentAlpha.Domain.Entities;
using RentAlpha.Infrastructure.Data.EntityConfig;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace RentAlpha.Infrastructure.Data.Contexts
{
  public class RentAlphaContext : DbContext
  {
    public RentAlphaContext()
      : base("RentAlphaMain")
    {
      
    }
    public DbSet<Friend> Friends { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

      // forçando o Context a entender que campos com "Id" no final, são PrimaryKey (NA VERDADE O EF Fluent API JÁ FAZ ISSO)
      modelBuilder.Properties()
        .Where(property => property.Name == property.ReflectedType.Name + "Id")
        .Configure(property => property.IsKey());

      // Tudo que for do tipo string (c#), definir o tipo de coluna igual a "VARCHAR", para não criar como NVARCHAR
      modelBuilder.Properties<string>()
        .Configure(property => property.HasColumnType("VARCHAR"));

      // Quando não informar um tamanho para as colunas do tipo string (VARCHAR), será confiugurado com 256
      modelBuilder.Properties<string>()
        .Configure(property => property.HasMaxLength(256));

      // Configurações específicas de cada entidade
      modelBuilder.Configurations.Add(new FriendConfiguration());
      modelBuilder.Configurations.Add(new GameConfiguration());

      base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
      const string nomenclatureCreateDate = "CreateDate";
      // percorrer as mudanças que serão feitas na base de dados...
      foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nomenclatureCreateDate) != null))
      {
        // ... para setar o valor dos campos denominados "CreateDate" no INSERT ...
        if (entry.State == EntityState.Added)
          entry.Property(nomenclatureCreateDate).CurrentValue = DateTime.Now;
        // ... e impedir que sejam alteradas no UPDATE
        if (entry.State == EntityState.Modified)
          entry.Property(nomenclatureCreateDate).IsModified = false;
      }

        const string nomenclatureRented = "Rented";
      foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nomenclatureRented) != null))
      {
        if (entry.State == EntityState.Added)
          entry.Property(nomenclatureRented).CurrentValue = false;
      }

      try
      {
        return base.SaveChanges();
      }
      catch (DbEntityValidationException ex)
      {
        // Retrieve the error messages as a list of strings.
        var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

        // Join the list to a single string.
        var fullErrorMessage = string.Join("; ", errorMessages);

        // Combine the original exception message with the new one.
        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

        Console.WriteLine(exceptionMessage);

        // Throw a new DbEntityValidationException with the improved exception message.
        //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

        return -1;
      }
    }
  }
}
