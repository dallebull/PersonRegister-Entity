namespace Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=StudentEntity")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Lastname)
                .IsUnicode(false);
        }
    }
}
