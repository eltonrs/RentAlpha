namespace RentAlpha.Infrastructure.Data.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<RentAlpha.Infrastructure.Data.Contexts.RentAlphaContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(RentAlpha.Infrastructure.Data.Contexts.RentAlphaContext context)
    {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.


      // pode ser usadao para popular a base de dados com registros iniciais
    }
  }
}
