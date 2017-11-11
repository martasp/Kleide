using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kleide.Models
{
    public partial class KleideContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Aksesuaras> Aksesuaras { get; set; }
        public virtual DbSet<AksesuaruKategorija> AksesuaruKategorija { get; set; }
        public virtual DbSet<Asmuo> Asmuo { get; set; }
        public virtual DbSet<Avalyne> Avalyne { get; set; }
        public virtual DbSet<Draudimas> Draudimas { get; set; }
        public virtual DbSet<Mokejimas> Mokejimas { get; set; }
        public virtual DbSet<Nuoma> Nuoma { get; set; }
        public virtual DbSet<Pirkimas> Pirkimas { get; set; }
        public virtual DbSet<Preke> Preke { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sandelys> Sandelys { get; set; }
        public virtual DbSet<Suknele> Suknele { get; set; }
        public virtual DbSet<Vartotojas> Vartotojas { get; set; }

        public KleideContext(DbContextOptions<KleideContext> options)
    : base(options)
        { }
        // public DbSet<Asmuo> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aksesuaras>(entity =>
            {
                entity.HasKey(e => e.IdAksesuaras);

                entity.HasIndex(e => e.FkPrekeidPreke)
                    .HasName("UQ__Aksesuar__EFDEFA2005051911")
                    .IsUnique();

                entity.Property(e => e.IdAksesuaras)
                    .HasColumnName("id_Aksesuaras")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArElektroninis).HasColumnName("ar_elektroninis");

                entity.Property(e => e.ArSuGrandinele).HasColumnName("ar_su_grandinele");

                entity.Property(e => e.FkAksesuaruKategorijaidAksesuaruKategorija).HasColumnName("fk_Aksesuaru_kategorijaid_Aksesuaru_kategorija");

                entity.Property(e => e.FkPrekeidPreke).HasColumnName("fk_Prekeid_Preke");

                entity.Property(e => e.Lytis)
                    .HasColumnName("lytis")
                    .HasColumnType("char(7)");

                entity.Property(e => e.MetaloTipas)
                    .HasColumnName("metalo_tipas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkAksesuaruKategorijaidAksesuaruKategorijaNavigation)
                    .WithMany(p => p.Aksesuaras)
                    .HasForeignKey(d => d.FkAksesuaruKategorijaidAksesuaruKategorija)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi_1");

                entity.HasOne(d => d.FkPrekeidPrekeNavigation)
                    .WithOne(p => p.Aksesuaras)
                    .HasForeignKey<Aksesuaras>(d => d.FkPrekeidPreke)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("yra_2");
            });

            modelBuilder.Entity<AksesuaruKategorija>(entity =>
            {
                entity.HasKey(e => e.IdAksesuaruKategorija);

                entity.ToTable("Aksesuaru_kategorija");

                entity.Property(e => e.IdAksesuaruKategorija)
                    .HasColumnName("id_Aksesuaru_kategorija")
                    .ValueGeneratedNever();

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Asmuo>(entity =>
            {
                entity.HasKey(e => e.AsmensKodas);

                entity.Property(e => e.AsmensKodas)
                    .HasColumnName("asmens_kodas")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adresas)
                    .HasColumnName("adresas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Miestas)
                    .HasColumnName("miestas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PastoKodas)
                    .HasColumnName("pasto_kodas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pavarde)
                    .HasColumnName("pavarde")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salis)
                    .HasColumnName("salis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefonas)
                    .HasColumnName("telefonas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vardas)
                    .HasColumnName("vardas")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Avalyne>(entity =>
            {
                entity.HasKey(e => e.IdAvalyne);

                entity.HasIndex(e => e.FkPrekeidPreke)
                    .HasName("UQ__Avalyne__EFDEFA206FBB2F18")
                    .IsUnique();

                entity.Property(e => e.IdAvalyne)
                    .HasColumnName("id_Avalyne")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkPrekeidPreke).HasColumnName("fk_Prekeid_Preke");

                entity.Property(e => e.Lytis)
                    .HasColumnName("lytis")
                    .HasColumnType("char(7)");

                entity.Property(e => e.MedziagosTipas)
                    .HasColumnName("medziagos_tipas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pobudis)
                    .HasColumnName("pobudis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SuKulniuku).HasColumnName("su_kulniuku");

                entity.Property(e => e.Uzsegimas).HasColumnName("uzsegimas");

                entity.HasOne(d => d.FkPrekeidPrekeNavigation)
                    .WithOne(p => p.Avalyne)
                    .HasForeignKey<Avalyne>(d => d.FkPrekeidPreke)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("yra_1");
            });

            modelBuilder.Entity<Draudimas>(entity =>
            {
                entity.HasKey(e => e.IdDraudimas);

                entity.HasIndex(e => e.FkPrekeidPreke)
                    .HasName("UQ__Draudima__EFDEFA209C9C0485")
                    .IsUnique();

                entity.Property(e => e.IdDraudimas)
                    .HasColumnName("id_Draudimas")
                    .ValueGeneratedNever();

                entity.Property(e => e.DraudimoNumeris)
                    .HasColumnName("draudimo_numeris")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DraudimoSuma).HasColumnName("draudimo_suma");

                entity.Property(e => e.FkPrekeidPreke).HasColumnName("fk_Prekeid_Preke");

                entity.Property(e => e.PabaigosData)
                    .HasColumnName("pabaigos_data")
                    .HasColumnType("date");

                entity.Property(e => e.Pobudis)
                    .HasColumnName("pobudis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PradziosData)
                    .HasColumnName("pradzios_data")
                    .HasColumnType("date");

                entity.Property(e => e.Tiekejas)
                    .HasColumnName("tiekejas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkPrekeidPrekeNavigation)
                    .WithOne(p => p.Draudimas)
                    .HasForeignKey<Draudimas>(d => d.FkPrekeidPreke)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("itraukatas");
            });

            modelBuilder.Entity<Mokejimas>(entity =>
            {
                entity.HasKey(e => e.MokejimoId);

                entity.Property(e => e.MokejimoId)
                    .HasColumnName("mokejimo_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AtsiskaitymoBūdas)
                    .HasColumnName("atsiskaitymo_būdas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AtsiėmimoVieta).HasColumnName("atsiėmimo_vieta");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.DraudimoTipas)
                    .HasColumnName("draudimo_tipas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MokejimoBusena)
                    .HasColumnName("mokejimo_busena")
                    .HasColumnType("char(10)");

                entity.Property(e => e.NuolaidosSuma).HasColumnName("nuolaidos_suma");

                entity.Property(e => e.SumoketaSuma).HasColumnName("sumoketa_suma");
            });

            modelBuilder.Entity<Nuoma>(entity =>
            {
                entity.HasKey(e => e.NuomosNumeris);

                entity.Property(e => e.NuomosNumeris)
                    .HasColumnName("nuomos_numeris")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkAsmuoasmensKodas).HasColumnName("fk_Asmuoasmens_kodas");

                entity.Property(e => e.FkAsmuoasmensKodas1).HasColumnName("fk_Asmuoasmens_kodas1");

                entity.Property(e => e.FkMokejimasmokejimoId).HasColumnName("fk_Mokejimasmokejimo_id");

                entity.Property(e => e.GrazinimoData)
                    .HasColumnName("grazinimo_data")
                    .HasColumnType("date");

                entity.Property(e => e.Kaina).HasColumnName("kaina");

                entity.Property(e => e.Kuponas).HasColumnName("kuponas");

                entity.Property(e => e.Pvm).HasColumnName("pvm");

                entity.Property(e => e.RezervavimoData)
                    .HasColumnName("rezervavimo_data")
                    .HasColumnType("date");

                entity.HasOne(d => d.FkAsmuoasmensKodasNavigation)
                    .WithMany(p => p.NuomaFkAsmuoasmensKodasNavigation)
                    .HasForeignKey(d => d.FkAsmuoasmensKodas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patvirtina_2");

                entity.HasOne(d => d.FkAsmuoasmensKodas1Navigation)
                    .WithMany(p => p.NuomaFkAsmuoasmensKodas1Navigation)
                    .HasForeignKey(d => d.FkAsmuoasmensKodas1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atlieka");

                entity.HasOne(d => d.FkMokejimasmokejimo)
                    .WithMany(p => p.Nuoma)
                    .HasForeignKey(d => d.FkMokejimasmokejimoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uz");
            });

            modelBuilder.Entity<Pirkimas>(entity =>
            {
                entity.HasKey(e => e.UzsakymoNumeris);

                entity.Property(e => e.UzsakymoNumeris)
                    .HasColumnName("uzsakymo_numeris")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArApdrausta).HasColumnName("ar_apdrausta");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.FkAsmuoasmensKodas).HasColumnName("fk_Asmuoasmens_kodas");

                entity.Property(e => e.FkAsmuoasmensKodas1).HasColumnName("fk_Asmuoasmens_kodas1");

                entity.Property(e => e.FkMokejimasmokejimoId).HasColumnName("fk_Mokejimasmokejimo_id");

                entity.Property(e => e.Kaina).HasColumnName("kaina");

                entity.Property(e => e.Kuponas).HasColumnName("kuponas");

                entity.Property(e => e.Pvm).HasColumnName("pvm");

                entity.HasOne(d => d.FkAsmuoasmensKodasNavigation)
                    .WithMany(p => p.PirkimasFkAsmuoasmensKodasNavigation)
                    .HasForeignKey(d => d.FkAsmuoasmensKodas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patvirtina_1");

                entity.HasOne(d => d.FkAsmuoasmensKodas1Navigation)
                    .WithMany(p => p.PirkimasFkAsmuoasmensKodas1Navigation)
                    .HasForeignKey(d => d.FkAsmuoasmensKodas1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atlieka_1");

                entity.HasOne(d => d.FkMokejimasmokejimo)
                    .WithMany(p => p.Pirkimas)
                    .HasForeignKey(d => d.FkMokejimasmokejimoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uz_1");
            });

            modelBuilder.Entity<Preke>(entity =>
            {
                entity.HasKey(e => e.IdPreke);

                entity.HasIndex(e => e.FkNuomanuomosNumeris)
                    .HasName("UQ__Preke__BF9E9BB67701A75D")
                    .IsUnique();

                entity.HasIndex(e => e.FkPirkimasuzsakymoNumeris)
                    .HasName("UQ__Preke__7E0206E7D43AA57F")
                    .IsUnique();

                entity.Property(e => e.IdPreke)
                    .HasColumnName("id_Preke")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aprasymas)
                    .HasColumnName("aprasymas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArRankuDarbo).HasColumnName("ar_ranku_darbo");

                entity.Property(e => e.Bukle)
                    .HasColumnName("bukle")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Dydis)
                    .HasColumnName("dydis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkNuomanuomosNumeris).HasColumnName("fk_Nuomanuomos_numeris");

                entity.Property(e => e.FkPirkimasuzsakymoNumeris).HasColumnName("fk_Pirkimasuzsakymo_numeris");

                entity.Property(e => e.FkSandelysidSandelys).HasColumnName("fk_Sandelysid_Sandelys");

                entity.Property(e => e.NuomosSkaicius).HasColumnName("nuomos_skaicius");

                entity.Property(e => e.Nuotrauka)
                    .HasColumnName("nuotrauka")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PagaminimoSalis)
                    .HasColumnName("pagaminimo_salis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PridejimoData)
                    .HasColumnName("pridejimo_data")
                    .HasColumnType("date");

                entity.Property(e => e.RezervavimoTipas)
                    .HasColumnName("rezervavimo_tipas")
                    .HasColumnType("char(17)");

                entity.Property(e => e.Spalva)
                    .HasColumnName("spalva")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkNuomanuomosNumerisNavigation)
                    .WithOne(p => p.Preke)
                    .HasForeignKey<Preke>(d => d.FkNuomanuomosNumeris)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nuomoja");

                entity.HasOne(d => d.FkPirkimasuzsakymoNumerisNavigation)
                    .WithOne(p => p.Preke)
                    .HasForeignKey<Preke>(d => d.FkPirkimasuzsakymoNumeris)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perka");

                entity.HasOne(d => d.FkSandelysidSandelysNavigation)
                    .WithMany(p => p.Preke)
                    .HasForeignKey(d => d.FkSandelysidSandelys)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.Property(e => e.IdRole)
                    .HasColumnName("id_Role")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkVartotojasidVartotojas).HasColumnName("fk_Vartotojasid_Vartotojas");

                entity.Property(e => e.Lygis).HasColumnName("lygis");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkVartotojasidVartotojasNavigation)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.FkVartotojasidVartotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi_2");
            });

            modelBuilder.Entity<Sandelys>(entity =>
            {
                entity.HasKey(e => e.IdSandelys);

                entity.Property(e => e.IdSandelys)
                    .HasColumnName("id_Sandelys")
                    .ValueGeneratedNever();

                entity.Property(e => e.DarboMasinosKiekis).HasColumnName("darbo_masinos_kiekis");

                entity.Property(e => e.DarbuotojuKiekis).HasColumnName("darbuotoju_kiekis");

                entity.Property(e => e.GatvėsPavadinimas)
                    .HasColumnName("gatvės_pavadinimas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kiekis).HasColumnName("kiekis");

                entity.Property(e => e.KontaktinisAsmuo)
                    .HasColumnName("kontaktinis_asmuo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Miestas)
                    .HasColumnName("miestas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PastoKodas)
                    .HasColumnName("pasto_kodas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrekesBukle)
                    .HasColumnName("prekes_bukle")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrekesTipas)
                    .HasColumnName("prekes_tipas")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Salis)
                    .HasColumnName("salis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SandelioDydis).HasColumnName("sandelio_dydis");
            });

            modelBuilder.Entity<Suknele>(entity =>
            {
                entity.HasKey(e => e.SuknelesNumeris);

                entity.HasIndex(e => e.FkPrekeidPreke)
                    .HasName("UQ__Suknele__EFDEFA20D956F343")
                    .IsUnique();

                entity.Property(e => e.SuknelesNumeris)
                    .HasColumnName("sukneles_numeris")
                    .ValueGeneratedNever();

                entity.Property(e => e.Audinys)
                    .HasColumnName("audinys")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkPrekeidPreke).HasColumnName("fk_Prekeid_Preke");

                entity.Property(e => e.Ilgis).HasColumnName("ilgis");

                entity.Property(e => e.ModelioTipas)
                    .HasColumnName("modelio_tipas")
                    .HasColumnType("char(9)");

                entity.HasOne(d => d.FkPrekeidPrekeNavigation)
                    .WithOne(p => p.Suknele)
                    .HasForeignKey<Suknele>(d => d.FkPrekeidPreke)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("yra_3");
            });

            modelBuilder.Entity<Vartotojas>(entity =>
            {
                entity.HasKey(e => e.IdVartotojas);

                entity.HasIndex(e => e.FkAsmuoasmensKodas)
                    .HasName("UQ__Vartotoj__BFDBFAF0588FD67A")
                    .IsUnique();

                entity.Property(e => e.IdVartotojas)
                    .HasColumnName("id_Vartotojas")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkAsmuoasmensKodas).HasColumnName("fk_Asmuoasmens_kodas");

                entity.Property(e => e.IpAdresas)
                    .HasColumnName("ip_adresas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrisijungimoVardas)
                    .HasColumnName("prisijungimo_vardas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Slaptazodis)
                    .HasColumnName("slaptazodis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkAsmuoasmensKodasNavigation)
                    .WithOne(p => p.Vartotojas)
                    .HasForeignKey<Vartotojas>(d => d.FkAsmuoasmensKodas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("yra");
            });
        }
    }
}
