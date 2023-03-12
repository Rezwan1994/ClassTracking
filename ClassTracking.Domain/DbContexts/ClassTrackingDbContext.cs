using ClassTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.DbContexts
{
    public class ClassTrackingDbContext : DbContext, IClassTrackingDbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public ClassTrackingDbContext(DbContextOptions<ClassTrackingDbContext> options)
             : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClassMap> StudentClassMaps { get; set; }
        public DbSet<TeacherEnrollment> TeacherEnrollments { get; set; }
        public DbSet<TeacherEnrollment> Classes { get; set; }

        public List<T> ExecSQL<T>(string query)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                Database.OpenConnection();

                List<T> list = new List<T>();
                using (var result = command.ExecuteReader())
                {
                    T obj = default(T);
                    while (result.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {
                            if (!object.Equals(result[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, result[prop.Name], null);
                            }
                        }
                        list.Add(obj);
                    }
                }
                Database.CloseConnection();
                return list;
            }
        }
    }
}
