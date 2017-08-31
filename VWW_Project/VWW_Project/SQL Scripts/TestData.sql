USE [aspnet-VWW_Project-20170607022226];
GO
INSERT INTO [dbo].[UserSet]
VALUES ('1','flex@email.de');
INSERT INTO [dbo].[UserSet]
VALUES ('2','frankam@inbox.lv');
GO
INSERT INTO [dbo].[EventSet]
VALUES 
('Birthday', 'It''s my birthday', '2017-11-19 00:00', null, 'green', 'true', 'false', (SELECT Id FROM [dbo].[UserSet] WHERE Id = '1')),
('Birthday', 'It''s someones birthday', '2017-08-23 00:00', null, 'green', 'true', 'false', (SELECT Id FROM [dbo].[UserSet] WHERE Id = '1'));
GO

INSERT INTO [dbo].[EventSet]
VALUES 
('Birthday', 'It''s my birthday', '2017-11-19 00:00', null, 'green', 'true', 'false', (SELECT Id FROM [dbo].[UserSet] WHERE Id = '2')),
('Birthday', 'It''s someones birthday', '2017-08-23 00:00', null, 'green', 'true', 'false', (SELECT Id FROM [dbo].[UserSet] WHERE Id = '2'));
GO