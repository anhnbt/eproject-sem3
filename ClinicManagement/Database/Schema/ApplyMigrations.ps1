/*
Initial Migration Script for Clinic Management System
*/

-- Create initial migration
Add-Migration InitialCreate -Project ClinicManagement.Infrastructure -StartupProject ClinicManagement.Web -Context ApplicationDbContext -OutputDir Data/Migrations

-- Update the database with the migration
Update-Database -Project ClinicManagement.Infrastructure -StartupProject ClinicManagement.Web -Context ApplicationDbContext

-- Generate SQL script (useful for review or manual application to production)
Script-Migration -Project ClinicManagement.Infrastructure -StartupProject ClinicManagement.Web -Context ApplicationDbContext -Output "Database\Schema\InitialMigration.sql"
