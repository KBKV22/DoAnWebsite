using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebsiteDuLichDiaPhuong.Models
{
    public partial class DuLichDiaPhuongModel : DbContext
    {
        public DuLichDiaPhuongModel()
            : base("name=DuLichDiaPhuongModel")
        {
        }

        public virtual DbSet<DIADANH> DIADANHs { get; set; }
        public virtual DbSet<HINHANH> HINHANHs { get; set; }
        public virtual DbSet<HUYEN> HUYENs { get; set; }
        public virtual DbSet<KHACHSAN> KHACHSANs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THELOAITIN> THELOAITINs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }
        public virtual DbSet<TOURDULICH> TOURDULICHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HINHANH>()
                .HasMany(e => e.DIADANHs)
                .WithRequired(e => e.HINHANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HINHANH>()
                .HasMany(e => e.TOURDULICHes)
                .WithRequired(e => e.HINHANH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HUYEN>()
                .HasMany(e => e.DIADANHs)
                .WithRequired(e => e.HUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HUYEN>()
                .HasMany(e => e.TOURDULICHes)
                .WithRequired(e => e.HUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHSAN>()
                .Property(e => e.SĐT)
                .IsUnicode(false);

            modelBuilder.Entity<THELOAITIN>()
                .HasMany(e => e.TINTUCs)
                .WithRequired(e => e.THELOAITIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TINTUC>()
                .HasMany(e => e.TOURDULICHes)
                .WithRequired(e => e.TINTUC)
                .WillCascadeOnDelete(false);
        }
    }
}
