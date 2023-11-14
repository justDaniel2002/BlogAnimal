using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogAnimalApi.Entity
{
    public partial class BlogAnimalContext : DbContext
    {
        public BlogAnimalContext()
        {
        }

        public BlogAnimalContext(DbContextOptions<BlogAnimalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogComment> BlogComments { get; set; } = null!;
        public virtual DbSet<BlogTag> BlogTags { get; set; } = null!;
        public virtual DbSet<BlogType> BlogTypes { get; set; } = null!;
        public virtual DbSet<PetType> PetTypes { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostComment> PostComments { get; set; } = null!;
        public virtual DbSet<PostLike> PostLikes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<TradeComment> TradeComments { get; set; } = null!;
        public virtual DbSet<TradePost> TradePosts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =localhost; database = BlogAnimal;uid=sa;pwd=123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__Account__AB6E616466BE87EA")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("contact");

                entity.Property(e => e.Email)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("facebook");

                entity.Property(e => e.HashPassword)
                    .IsUnicode(false)
                    .HasColumnName("hash_password");

                entity.Property(e => e.IsBanned)
                    .HasColumnName("isBanned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__role_id__3E52440B");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("blog_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.BlogTypeId).HasColumnName("blog_type_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PetTypeId).HasColumnName("pet_type_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(225)
                    .HasColumnName("title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Blog__account_id__534D60F1");

                entity.HasOne(d => d.BlogType)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogTypeId)
                    .HasConstraintName("FK_Blog_BlogType");

                entity.HasOne(d => d.PetType)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.PetTypeId)
                    .HasConstraintName("FK__Blog__type_id__5441852A");
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__BlogComm__E79576877BDF8D37");

                entity.ToTable("BlogComment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.BlogId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("blog_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__BlogComme__accou__5CD6CB2B");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK__BlogComme__blog___5BE2A6F2");
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.ToTable("BlogTag");

                entity.Property(e => e.BlogTagId).HasColumnName("blog_tag_id");

                entity.Property(e => e.BlogId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("blog_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK__BlogTag__blog_id__59063A47");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BlogTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK__BlogTag__tag_id__5812160E");
            });

            modelBuilder.Entity<BlogType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("BlogType");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<PetType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__PetType__2C00059879454FF1");

                entity.ToTable("PetType");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("post_id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Images)
                    .IsUnicode(false)
                    .HasColumnName("images");

                entity.Property(e => e.IsSecure)
                    .HasColumnName("isSecure")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .HasMaxLength(225)
                    .HasColumnName("title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Post__account_id__44FF419A");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__PostComm__E79576879A716837");

                entity.ToTable("PostComment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("post_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__PostComme__accou__49C3F6B7");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__PostComme__post___48CFD27E");
            });

            modelBuilder.Entity<PostLike>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PK__PostLike__992C7930F8047785");

                entity.ToTable("PostLike");

                entity.Property(e => e.LikeId).HasColumnName("like_id");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("post_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PostLikes)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__PostLike__accoun__4E88ABD4");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostLikes)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__PostLike__post_i__4D94879B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.TagName)
                    .HasMaxLength(100)
                    .HasColumnName("tag_name");
            });

            modelBuilder.Entity<TradeComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__TradeCom__CDDE919D96732E36");

                entity.ToTable("TradeComment");

                entity.Property(e => e.CommentId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("commentId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TradeId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tradeId");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TradeComments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__TradeComm__accou__76969D2E");

                entity.HasOne(d => d.Trade)
                    .WithMany(p => p.TradeComments)
                    .HasForeignKey(d => d.TradeId)
                    .HasConstraintName("FK__TradeComm__trade__778AC167");
            });

            modelBuilder.Entity<TradePost>(entity =>
            {
                entity.HasKey(e => e.TradeId)
                    .HasName("PK__TradePos__F7D149DDCDEED70D");

                entity.ToTable("TradePost");

                entity.Property(e => e.TradeId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tradeId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsSecure)
                    .HasColumnName("isSecure")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTrade)
                    .HasColumnName("isTrade")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TradePosts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__TradePost__accou__73BA3083");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
