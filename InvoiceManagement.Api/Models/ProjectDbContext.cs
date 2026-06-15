using System.Reflection;
using Microsoft.EntityFrameworkCore;
using InvoiceManagement.Api.Models.Frameworks;

namespace InvoiceManagement.Api.Models
{
    public class ProjectDbContext : DbContext
    {
        #region [- Ctor -]
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        } 
        #endregion

        #region [- OnModelCreating(ModelBuilder modelBuilder) -]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [- RegisterAllEntities() -]
            modelBuilder.RegisterAllEntities<IDbSetEntity>(typeof(IDbSetEntity).Assembly);
            #endregion

            #region [- ApplyConfigurationsFromAssembly() -]
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            base.OnModelCreating(modelBuilder);
        } 
        #endregion

    }
}
