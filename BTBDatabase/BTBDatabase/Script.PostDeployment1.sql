/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
print 'Inserting seed data for User Ratings'

insert BTBDatabase.dbo.UserRating select 1, 'Asian Persuasion', Test, 5, 'Really Great Shot!', Date.today, 0
where not exists  (select 1 from BTBDatabase.dbo.UserRating where UserRating = 1)
go