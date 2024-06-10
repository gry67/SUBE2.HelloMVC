using Microsoft.EntityFrameworkCore;

namespace Sube2.HelloMvc.Models
{
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<OgrenciDers> OgrencilerDersler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OkulDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o=> o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o=>o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();

            modelBuilder.Entity<OgrenciDers>().HasKey(od => new { od.OgrenciId, od.DersId });

            modelBuilder.Entity<OgrenciDers>().HasOne(d=> d.Ders).WithMany(o=>o.Ogrenciler)
            .HasForeignKey(d=>d.DersId);
            modelBuilder.Entity<OgrenciDers>().HasOne(o=>o.Ogrenci).WithMany(d=>d.Dersler)
            .HasForeignKey(o=>o.OgrenciId);
        }
    }
}
