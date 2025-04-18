using Microsoft.EntityFrameworkCore;
using ProjectTracker.API.Models;

namespace ProjectTracker.API.Data;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Website Redesign", Description = "Modernize the company website with new design and features", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-30), Priority = 1 },
            new Project { Id = 2, Name = "Mobile App Development", Description = "Create a new mobile app for customer engagement", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(7), Priority = 2 },
            new Project { Id = 3, Name = "Database Migration", Description = "Migrate legacy database to new cloud infrastructure", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-60), EndDate = DateTime.Now.AddDays(-5), Priority = 3 },
            new Project { Id = 4, Name = "Security Audit", Description = "Perform comprehensive security audit of all systems", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(14), Priority = 1 },
            new Project { Id = 5, Name = "Employee Training Portal", Description = "Develop internal training portal for employees", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-15), Priority = 4 },
            new Project { Id = 6, Name = "Cloud Infrastructure Setup", Description = "Set up cloud infrastructure for new services", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-45), Priority = 2 },
            new Project { Id = 7, Name = "Customer Feedback System", Description = "Implement new customer feedback collection system", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-90), EndDate = DateTime.Now.AddDays(-30), Priority = 3 },
            new Project { Id = 8, Name = "API Gateway Implementation", Description = "Deploy new API gateway for microservices", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(21), Priority = 1 },
            new Project { Id = 9, Name = "Data Analytics Dashboard", Description = "Create dashboard for business analytics", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-20), Priority = 2 },
            new Project { Id = 10, Name = "Payment System Upgrade", Description = "Upgrade payment processing system", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-75), EndDate = DateTime.Now.AddDays(-15), Priority = 1 },
            new Project { Id = 11, Name = "Content Management System", Description = "Develop new CMS for marketing team", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(30), Priority = 3 },
            new Project { Id = 12, Name = "Automated Testing Framework", Description = "Build automated testing infrastructure", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-10), Priority = 2 },
            new Project { Id = 13, Name = "Customer Support Chatbot", Description = "Implement AI-powered customer support chatbot", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-120), EndDate = DateTime.Now.AddDays(-60), Priority = 4 },
            new Project { Id = 14, Name = "Inventory Management System", Description = "Create new inventory tracking system", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(45), Priority = 2 },
            new Project { Id = 15, Name = "Social Media Integration", Description = "Integrate social media platforms with main app", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-25), Priority = 3 },
            new Project { Id = 16, Name = "Document Management System", Description = "Develop system for document storage and retrieval", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-100), EndDate = DateTime.Now.AddDays(-40), Priority = 1 },
            new Project { Id = 17, Name = "Performance Monitoring Tools", Description = "Create tools for system performance monitoring", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(60), Priority = 2 },
            new Project { Id = 18, Name = "Email Marketing Platform", Description = "Build platform for automated email campaigns", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-5), Priority = 3 },
            new Project { Id = 19, Name = "User Authentication System", Description = "Implement new authentication system", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-80), EndDate = DateTime.Now.AddDays(-20), Priority = 1 },
            new Project { Id = 20, Name = "Reporting System", Description = "Develop comprehensive reporting system", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(90), Priority = 4 },
            new Project { Id = 21, Name = "Mobile App Analytics", Description = "Add analytics to mobile applications", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-35), Priority = 2 },
            new Project { Id = 22, Name = "Customer Portal Redesign", Description = "Redesign customer-facing portal", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-110), EndDate = DateTime.Now.AddDays(-50), Priority = 3 },
            new Project { Id = 23, Name = "API Documentation", Description = "Create comprehensive API documentation", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(15), Priority = 1 },
            new Project { Id = 24, Name = "Data Backup System", Description = "Implement automated data backup system", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-40), Priority = 2 },
            new Project { Id = 25, Name = "System Integration", Description = "Integrate various internal systems", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-95), EndDate = DateTime.Now.AddDays(-35), Priority = 4 },
            new Project { Id = 26, Name = "Mobile App Push Notifications", Description = "Add push notification system to mobile app", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(75), Priority = 2 },
            new Project { Id = 27, Name = "Performance Optimization", Description = "Optimize system performance", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-50), Priority = 1 },
            new Project { Id = 28, Name = "User Feedback Collection", Description = "Implement system for collecting user feedback", Status = ProjectStatus.Completed, StartDate = DateTime.Now.AddDays(-130), EndDate = DateTime.Now.AddDays(-70), Priority = 3 },
            new Project { Id = 29, Name = "System Monitoring Dashboard", Description = "Create dashboard for system monitoring", Status = ProjectStatus.NotStarted, StartDate = DateTime.Now.AddDays(120), Priority = 2 },
            new Project { Id = 30, Name = "Data Migration Tools", Description = "Develop tools for data migration", Status = ProjectStatus.InProgress, StartDate = DateTime.Now.AddDays(-55), Priority = 4 }
        );
    }
} 