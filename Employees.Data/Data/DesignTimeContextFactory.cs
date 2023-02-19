using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Data
{
    class DesignTimeContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Employees"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<SchoolContext>();
            builder.UseNpgsql(connectionString);

            return new SchoolContext(builder.Options);
        }
    }

}
