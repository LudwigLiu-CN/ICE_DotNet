using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccessAPI.Models;

namespace DataAccessAPI.Contexts
{
    public partial class iceContext : DbContext
    {
        public iceContext()
        {
        }

        public iceContext(DbContextOptions<iceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Belong> Belong { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Chart> Chart { get; set; }
        public virtual DbSet<Consoles> Consoles { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<HasReview> HasReview { get; set; }
        public virtual DbSet<HasTag> HasTag { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PlayedOn> PlayedOn { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<RateGame> RateGame { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SaleGame> SaleGame { get; set; }
        public virtual DbSet<Sequences> Sequences { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<WriteReview> WriteReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;userid=root;pwd=20140626lym;port=3306;database=ice;sslmode=none", x => x.ServerVersion("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Belong>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PRIMARY");

                entity.ToTable("belong");

                entity.HasIndex(e => e.CateId)
                    .HasName("CATE_ID");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CateId)
                    .HasColumnName("CATE_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Belong)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("BELONG_FK2");

                entity.HasOne(d => d.Game)
                    .WithOne(p => p.Belong)
                    .HasForeignKey<Belong>(d => d.GameId)
                    .HasConstraintName("BELONG_FK1");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CateId)
                    .HasName("PRIMARY");

                entity.ToTable("categories");

                entity.Property(e => e.CateId)
                    .HasColumnName("CATE_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CateName)
                    .HasColumnName("CATE_NAME")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Chart>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("chart");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("USER_ID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConsoleId)
                    .HasColumnName("CONSOLE_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Chart)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("CHART_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("CHART_FK2");
            });

            modelBuilder.Entity<Consoles>(entity =>
            {
                entity.HasKey(e => e.ConsoleId)
                    .HasName("PRIMARY");

                entity.ToTable("consoles");

                entity.Property(e => e.ConsoleId)
                    .HasColumnName("CONSOLE_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConsoleName)
                    .HasColumnName("CONSOLE_NAME")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("PRIMARY");

                entity.ToTable("games");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AverageRate).HasColumnName("AVERAGE_RATE");

                entity.Property(e => e.CoverPath)
                    .HasColumnName("COVER_PATH")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Discount).HasColumnName("DISCOUNT");

                entity.Property(e => e.OnSale).HasColumnName("ON_SALE");

                entity.Property(e => e.PreOrder).HasColumnName("PRE_ORDER");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.RateCount)
                    .HasColumnName("RATE_COUNT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("RELEASE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<HasReview>(entity =>
            {
                entity.HasKey(e => new { e.ReviewId, e.GameId })
                    .HasName("PRIMARY");

                entity.ToTable("has_review");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.ReviewId)
                    .HasName("REVIEW_ID");

                entity.Property(e => e.ReviewId)
                    .HasColumnName("REVIEW_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.HasReview)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("HAS_REVIEW_FK1");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.HasReview)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("HAS_REVIEW_FK2");
            });

            modelBuilder.Entity<HasTag>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.TagId })
                    .HasName("PRIMARY");

                entity.ToTable("has_tag");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.TagId)
                    .HasName("TAG_ID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TagId)
                    .HasColumnName("TAG_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.HasTag)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("HAS_TAG_FK1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.HasTag)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("HAS_TAG_FK2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasIndex(e => e.ConsoleId)
                    .HasName("CONSOLE_ID");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("USER_ID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("ORDER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ConsoleId)
                    .HasColumnName("CONSOLE_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactTel)
                    .HasColumnName("CONTACT_TEL")
                    .HasColumnType("char(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Console)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ConsoleId)
                    .HasConstraintName("ORDERS_FK3");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("ORDERS_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ORDERS_FK2");
            });

            modelBuilder.Entity<PlayedOn>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.ConsoleId })
                    .HasName("PRIMARY");

                entity.ToTable("played_on");

                entity.HasIndex(e => e.ConsoleId)
                    .HasName("CONSOLE_ID");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConsoleId)
                    .HasColumnName("CONSOLE_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Console)
                    .WithMany(p => p.PlayedOn)
                    .HasForeignKey(d => d.ConsoleId)
                    .HasConstraintName("PLAYED_ON_FK2");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.PlayedOn)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("PLAYED_ON_FK1");
            });

            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PublisherId)
                    .HasName("PRIMARY");

                entity.ToTable("publishers");

                entity.Property(e => e.PublisherId)
                    .HasColumnName("PUBLISHER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LogoPath)
                    .HasColumnName("LOGO_PATH")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PublisherName)
                    .HasColumnName("PUBLISHER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pwd)
                    .HasColumnName("PWD")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<RateGame>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("rate_game");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("USER_ID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.RateGame)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("RATE_GAME_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RateGame)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("RATE_GAME_FK2");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PRIMARY");

                entity.ToTable("reviews");

                entity.Property(e => e.ReviewId)
                    .HasColumnName("REVIEW_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ReviewDate)
                    .HasColumnName("REVIEW_DATE")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<SaleGame>(entity =>
            {
                entity.HasKey(e => new { e.PublisherId, e.GameId })
                    .HasName("PRIMARY");

                entity.ToTable("sale_game");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.PublisherId)
                    .HasName("PUBLISHER_ID");

                entity.Property(e => e.PublisherId)
                    .HasColumnName("PUBLISHER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.SaleGame)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("SALE_GAME_FK1");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.SaleGame)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("SALE_GAME_FK2");
            });

            modelBuilder.Entity<Sequences>(entity =>
            {
                entity.HasKey(e => e.SequenceName)
                    .HasName("PRIMARY");

                entity.ToTable("sequences");

                entity.Property(e => e.SequenceName)
                    .HasColumnName("sequence_name")
                    .HasColumnType("varchar(64)")
                    .HasComment("序列名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("bigint(20)")
                    .HasComment("当前值");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PRIMARY");

                entity.ToTable("tags");

                entity.Property(e => e.TagId)
                    .HasColumnName("TAG_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TagName)
                    .HasColumnName("TAG_NAME")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AvatarPath)
                    .HasColumnName("AVATAR_PATH")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Birthday)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("date");

                entity.Property(e => e.Gender).HasColumnName("GENDER");

                entity.Property(e => e.Pwd)
                    .HasColumnName("PWD")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
                    .HasColumnType("char(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("wishlist");

                entity.HasIndex(e => e.GameId)
                    .HasName("GAME_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("USER_ID");

                entity.Property(e => e.GameId)
                    .HasColumnName("GAME_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notification).HasColumnName("NOTIFICATION");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("WISHLIST_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("WISHLIST_FK2");
            });

            modelBuilder.Entity<WriteReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PRIMARY");

                entity.ToTable("write_review");

                entity.HasIndex(e => e.ReviewId)
                    .HasName("REVIEW_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("USER_ID");

                entity.Property(e => e.ReviewId)
                    .HasColumnName("REVIEW_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Review)
                    .WithOne(p => p.WriteReview)
                    .HasForeignKey<WriteReview>(d => d.ReviewId)
                    .HasConstraintName("WRITE_REVIEW_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WriteReview)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("WRITE_REVIEW_FK2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
