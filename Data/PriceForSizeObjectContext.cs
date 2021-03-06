﻿using Nop.Core;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PriceForSize.Data
{
  public class PriceForSizeObjectContext : DbContext, IDbContext
  {
    public PriceForSizeObjectContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

    #region Implementation of IDbContext

    #endregion

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new Product_PriceForSizeMap());
      modelBuilder.Configurations.Add(new ProductAttributeValue_PriceForSizeMap());

      base.OnModelCreating(modelBuilder);
    }

    public string CreateDatabaseInstallationScript()
    {
      return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
    }

    public void Install()
    {
      Database.SetInitializer<PriceForSizeObjectContext>(null);
      var dbScript = CreateDatabaseInstallationScript();

      Database.ExecuteSqlCommand(dbScript);
      SaveChanges();
    }

    public void Uninstall()
    {
      var dbScript = "DROP TABLE Product_PriceForSize; DROP TABLE ProductAttributeValue_PriceForSize";
      Database.ExecuteSqlCommand(dbScript);
      SaveChanges();
    }

    public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
    {
      return base.Set<TEntity>();
    }

    public System.Collections.Generic.IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
    {
      throw new System.NotImplementedException();
    }

    public System.Collections.Generic.IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
    {
      throw new System.NotImplementedException();
    }

    public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
    {
      throw new System.NotImplementedException();
    }
  }

}
