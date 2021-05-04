using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Velo.Models
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<CONVERSATION> CONVERSATIONs { get; set; }
        public virtual DbSet<CONVERSATION_DETAIL> CONVERSATION_DETAIL { get; set; }
        public virtual DbSet<MESSAGE> MESSAGEs { get; set; }
        public virtual DbSet<PHOTO> Photos { get; set; }
        public virtual DbSet<RELATION> RELATIONs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.ID_User)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Account_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.CONVERSATION_DETAIL)
                .WithRequired(e => e.ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.RELATIONs)
                .WithOptional(e => e.ACCOUNT)
                .HasForeignKey(e => e.Account_ID_received);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.RELATIONs1)
                .WithOptional(e => e.ACCOUNT1)
                .HasForeignKey(e => e.Account_ID_sent);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.MESSAGEs)
                .WithOptional(e => e.ACCOUNT)
                .HasForeignKey(e => e.User_ID_sent);

            modelBuilder.Entity<CONVERSATION>()
                .Property(e => e.Conversation_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONVERSATION>()
                .HasMany(e => e.CONVERSATION_DETAIL)
                .WithRequired(e => e.CONVERSATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONVERSATION_DETAIL>()
                .Property(e => e.Conversation_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONVERSATION_DETAIL>()
                .Property(e => e.ID_User)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE>()
                .Property(e => e.Message_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE>()
                .Property(e => e.User_ID_sent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MESSAGE>()
                .Property(e => e.Conversation_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHOTO>()
                .Property(e => e.Photo_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHOTO>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<PHOTO>()
                .Property(e => e.ID_User)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RELATION>()
                .Property(e => e.Rela_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RELATION>()
                .Property(e => e.Account_ID_sent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RELATION>()
                .Property(e => e.Account_ID_received)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
