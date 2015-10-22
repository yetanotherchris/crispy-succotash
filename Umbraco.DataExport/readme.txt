About
This tool is for backing up your http://www.codeplex.com/umbraco database.

The tool was written for people who use shared hosting and don't have the luxury of being able to backup the database when they want, or install SSIS packages. The tool replaces the SQL Enterprise Manager/SQL Server Management Studio export (which doesn't copy keys/constraints anyhow) and is written specifically for Umbraco database objects.



This tool is intended to be used by people who know about connection strings and how to SQL Enterprise Manager/Management Studio, and have a basic understanding of the workings of SQL Server.

Getting started
The tool is simple to use. It grabs the data from your remote SQL Server, and writes out 3 SQL Scripts:
Step1.sql - This drops and creates all umbraco objects
Step2.sql - This contains all your data
Step3.sql - This creates all the database keys.

You need to run the SQL scripts inside Query Analyser (SQL Server 2000) or Management Studio (2005) in that order.

The export tool includes the option to ignore the log tables (which can often be very bulky) and also write out each of your tables to seperate files. This is useful if you only want to grab data from one particular table.

You can also set the dateformat if your server is running on a different Locale to your workstation. For example, setting it to dmy gives the UK time format.

Required downloads

SQL Server Management Studio
http://msdn.microsoft.com/vstudio/express/sql/download/

.NET 2 Framework
http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en 