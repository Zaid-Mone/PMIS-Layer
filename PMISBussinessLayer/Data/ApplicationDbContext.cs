using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBussinessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManger> ProjectMangers { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }

        internal object Include()
        {
            throw new NotImplementedException();
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProjectPhase>().HasIndex(v => new { v.ProjectId, v.PhaseId }).IsUnique();
            builder.Entity<InvoicePaymentTerm>().HasKey(y => new { y.InvoiceId, y.PaymentTermId });

            builder.Entity<InvoicePaymentTerm>()
             .HasOne(sc => sc.PaymentTerm)
             .WithMany(c => c.InvoicePaymentTerms)
            .HasForeignKey(sc => sc.PaymentTermId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
            builder.Entity<InvoicePaymentTerm>()
                    .HasOne(sc => sc.Invoice)
                    .WithMany(c => c.InvoicePaymentTerms)
                    .HasForeignKey(sc => sc.InvoiceId)
                    .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
          
                
        }
    }
}
