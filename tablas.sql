------------------------------------------------------
-- 			USO GENERAL
------------------------------------------------------
USE [CvBlazor]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--DROP TABLE [dbo].[Portfolios];
--DROP TABLE [dbo].[Facts];
--DROP TABLE [dbo].[Skills];
--DROP TABLE [dbo].[Testimonials];
--DROP TABLE [dbo].[Titles];
--DROP TABLE [dbo].[Achievements];
--DROP TABLE [dbo].[Services];
--DROP TABLE [dbo].[Persons];
--DROP TABLE [dbo].[Jobs];
--DROP TABLE [dbo].[Locations];
--DROP TABLE [dbo].[Resumes];

------------------------------------------------------
-- 			RESUMES
------------------------------------------------------

CREATE TABLE [dbo].[Resumes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Profession] [VARCHAR](50),
	[Sumary] [VARCHAR](200),
	[Degree] [VARCHAR](50),
 CONSTRAINT [PK_Resumes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


------------------------------------------------------
-- 			LOCATIONS
------------------------------------------------------

CREATE TABLE [dbo].[Locations](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Street] [VARCHAR](100) NOT NULL,
	[City] [VARCHAR](100) NOT NULL,
	[PostalCode] [VARCHAR](20) NOT NULL,
	[Country] [VARCHAR](100) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


------------------------------------------------------
-- 			JOBS
------------------------------------------------------

CREATE TABLE [dbo].[Jobs](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL, 
	[Company] [varchar](100) NOT NULL, 
	[StartDate] [DATETIME]  NOT NULL DEFAULT GETDATE(),
	[EndDate] [DATETIME]  NOT NULL DEFAULT GETDATE(),
	[LocationId] [INT] NOT NULL,
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([id])
GO

ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Locations]
GO

ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Resumes]
GO


------------------------------------------------------
-- 			ACHIVEMENTS
------------------------------------------------------

CREATE TABLE [dbo].[Achievements](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NOT NULL, 
	[JobId] [INT] NOT NULL,
 CONSTRAINT [PK_Achievements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Achievements]  WITH CHECK ADD  CONSTRAINT [FK_Achievements_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([id])
GO

ALTER TABLE [dbo].[Achievements] CHECK CONSTRAINT [FK_Achievements_Jobs]
GO


------------------------------------------------------
-- 			FACTS
------------------------------------------------------

CREATE TABLE [dbo].[Facts](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL, 
	[Quantity] [INT] NOT NULL, 
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Facts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Facts]  WITH CHECK ADD  CONSTRAINT [FK_Facts_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Facts] CHECK CONSTRAINT [FK_Facts_Resumes]
GO


------------------------------------------------------
-- 			PERSONS
------------------------------------------------------

CREATE TABLE [dbo].[Persons](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL, 
	[LastName] [varchar](100) NOT NULL, 
	[Birthday] [DATETIME]  NOT NULL DEFAULT GETDATE(),
	[Website] [varchar](MAX) NOT NULL, 
	[Phone] [varchar](30) NOT NULL, 
	[Email] [varchar](200) NOT NULL, 
	[IsFreelancer] [bit] NOT NULL DEFAULT 0,
	[LocationId] [INT] NOT NULL,
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([id])
GO

ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Locations]
GO

ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Resumes]
GO


------------------------------------------------------
-- 			PORTFOLIO
------------------------------------------------------

CREATE TABLE [dbo].[Portfolios](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL, 
	[Description] [varchar](100) NOT NULL, 
	[Filter] [varchar](100) NOT NULL, 
	[SrcMainImage] [varchar](100) NOT NULL, 
	[Category] [varchar](100) NOT NULL, 
	[ClientName] [varchar](100) NOT NULL, 
	[ProjectDate] [DATETIME]  NOT NULL DEFAULT GETDATE(),
	[ProjectUrl] [varchar](MAX) NOT NULL, 
	[SumaryTitle] [varchar](200) NOT NULL, 
	[Sumary] [varchar](500) NOT NULL, 
	[UrlImageList] [varchar](MAX) NOT NULL, 
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Portfolios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Portfolios]  WITH CHECK ADD  CONSTRAINT [FK_Portfolios_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_Portfolios_Resumes]
GO

------------------------------------------------------
-- 			SERVICES
------------------------------------------------------

CREATE TABLE [dbo].[Services](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL, 
	[Description] [varchar](200) NOT NULL, 
	[Color] [varchar](50) NOT NULL, 
	[DPath] [varchar](MAX) NOT NULL, 
	[IbiClass] [varchar](50) NOT NULL, 
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Resumes]
GO


------------------------------------------------------
-- 			SKILLS
------------------------------------------------------

CREATE TABLE [dbo].[Skills](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL, 
	[Percentage] [INT] NOT NULL, 
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_Skills_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Skills] CHECK CONSTRAINT [FK_Skills_Resumes]
GO


------------------------------------------------------
-- 			TESTIMONIALS
------------------------------------------------------

CREATE TABLE [dbo].[Testimonials](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL, 
	[Occupation] [varchar](200) NOT NULL, 
	[SrcProfileImage] [varchar](MAX) NOT NULL, 
	[TextMessage] [varchar](500) NOT NULL, 
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Testimonials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Testimonials]  WITH CHECK ADD  CONSTRAINT [FK_Testimonials_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Testimonials] CHECK CONSTRAINT [FK_Testimonials_Resumes]
GO
	
	
------------------------------------------------------
-- 			TITLES
------------------------------------------------------

CREATE TABLE [dbo].[Titles](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL, 
	[Description] [varchar](500) NOT NULL, 
	[EducationalCenter] [varchar](100) NOT NULL, 
	[StartDate] [DATETIME]  NOT NULL DEFAULT GETDATE(),
	[EndDate] [DATETIME]  NOT NULL DEFAULT GETDATE(),
	[LocationId] [INT] NOT NULL,
	[ResumeId] [INT] NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Titles]  WITH CHECK ADD  CONSTRAINT [FK_Titles_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([id])
GO

ALTER TABLE [dbo].[Titles] CHECK CONSTRAINT [FK_Titles_Locations]
GO

ALTER TABLE [dbo].[Titles]  WITH CHECK ADD  CONSTRAINT [FK_Titles_Resumes] FOREIGN KEY([ResumeId])
REFERENCES [dbo].[Resumes] ([id])
GO

ALTER TABLE [dbo].[Titles] CHECK CONSTRAINT [FK_Titles_Resumes]
GO


------------------------------------------------------
-- 			INSERTS
------------------------------------------------------

-- RESUME
INSERT INTO [dbo].[Resumes] (Profession, Sumary, Degree) VALUES ('Developer', 'Three years working as developer in large companies, with technologies as .NET, Angular or UiPath', 'Senior')


-- LOCATIONS
INSERT INTO [dbo].[Locations] (Street, City, PostalCode, Country) VALUES 
	('Calle Amendras 21', 'Alicante', '06587', 'España'),
	('Calle Dorada 5', 'Alicante', '06587', 'España'),
	('Avenida Alfonso XIII 12', 'Alicante', '06587', 'España'),
	('Calle Principal 15', 'Alicante', '06587', 'España'),
	('Calle Venecia 8', 'Alicante', '06587', 'España'),
	('Calle Francia 6', 'Alicante', '06587', 'España');


-- JOBS
INSERT INTO [dbo].[Jobs] (Description, Company, StartDate, EndDate, LocationId, ResumeId) VALUES 
	('RPA developer', 'NTT Data', '2020-10-01 00:00:00','2022-12-31 00:00:00', 2, 1),
	('Visual Basic/PL-SQL Developer', 'Altera Software', '2023-05-15 00:00:00','2024-01-15 00:00:00', 3, 1),
	('.NET/SQL Server/SAP developer', 'Panama Jack', '2024-02-01 00:00:00','2024-04-30 00:00:00', 4, 1),
	('.NET developer', 'Cuenta Propia', '2024-05-01 00:00:00','2025-04-30 00:00:00', 5, 1);


-- ACHIEVEMENTS
INSERT INTO [dbo].[Achievements] (Description, JobId) VALUES 
	('Maintenance and development of over 25 processes using UiPath.', 1),
	('Database migration from Microsoft SQL Server to PostgreSQL.', 1),
	('Maintenance and development of over 25 processes using UiPath.', 1),
	('Performed major modifications to applications written in Visual Basic .NET and VBA, with data access using PL/SQL.', 2),
	('Restructured a project using PHP, JavaScript, and responsive CSS.', 2),
	('Development and issue resolution using Visual Basic .NET, SQL Server, SAP, and Crystal Reports.', 3),
	('Application development using ASP.NET, Angular, and Blazor, as well as related technologies such as JavaScript, HTML, CSS, Bootstrap, and SQL Server.', 4);

-- FACTS
INSERT INTO [dbo].[Facts] (Name, Quantity, ResumeId) VALUES 
	('Clients', 232, 1),
	('Projects', 251, 1),
	('Hours Of Support', 1453, 1),
	('Workers', 32, 1);


-- PERSONS
INSERT INTO [dbo].[Persons] (Name, LastName, Birthday, Website, Phone, Email, IsFreelancer, LocationId, ResumeId) VALUES 
	('Juan Carlos', 'Parralejo', '1987-06-03 00:00:00','https://github.com/Juancar-Git', '635968754', 'www.juancar.p@gmail.com', 0,1, 1);
	
	
-- PORTFOLIO
INSERT INTO [dbo].[Portfolios] (Name, Description, Filter, SrcMainImage, Category, ClientName, ProjectDate, ProjectUrl, SumaryTitle, Sumary, UrlImageList, ResumeId) VALUES 
	('App 1', 'Lorem ipsum, dolor sit', 'APP', 'assets/img/masonry-portfolio/masonry-portfolio-1.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('Product 1', 'Lorem ipsum, dolor sit', 'CARD', 'assets/img/masonry-portfolio/masonry-portfolio-2.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('Branding 1', 'Lorem ipsum, dolor sit', 'WEB', 'assets/img/masonry-portfolio/masonry-portfolio-3.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('App 2', 'Lorem ipsum, dolor sit', 'APP', 'assets/img/masonry-portfolio/masonry-portfolio-4.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('Product 2', 'Lorem ipsum, dolor sit', 'CARD', 'assets/img/masonry-portfolio/masonry-portfolio-5.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('Branding 2', 'Lorem ipsum, dolor sit', 'WEB', 'assets/img/masonry-portfolio/masonry-portfolio-6.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('App 3', 'Lorem ipsum, dolor sit', 'APP', 'assets/img/masonry-portfolio/masonry-portfolio-7.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('Product 3', 'Lorem ipsum, dolor sit', 'CARD', 'assets/img/masonry-portfolio/masonry-portfolio-8.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1),
	('Branding 3', 'Lorem ipsum, dolor sit', 'WEB', 'assets/img/masonry-portfolio/masonry-portfolio-9.jpg', 'ASU Company', 'Web design', GETDATE(), 'www.example.com', 'Exercitationem repudiandae officiis neque suscipit', 'Autem ipsum nam porro corporis rerum. Quis eos dolorem eos itaque inventore commodi labore quia quia. Exercitationem repudiandae officiis neque suscipit non officia eaque itaque enim. Voluptatem officia accusantium nesciunt est omnis tempora consectetur dignissimos. Sequi nulla at esse enim cum deserunt eius.', 'assets/img/portfolio/app-1.jpg;assets/img/portfolio/books-1.jpg;assets/img/portfolio/branding-1.jpg;assets/img/portfolio/product-1.jpg', 1)
	;
	

-- SERVICES
INSERT INTO [dbo].[Services] (Name, Description, Color, DPath, IbiClass, ResumeId) VALUES 
	('Nesciunt Mete','Provident nihil minus qui consequatur non omnis maiores. Eos accusantium minus dolores iure perferendis tempore et consequatur.','cyan','M300,521.0016835830174C376.1290562159157,517.8887921683347,466.0731472004068,529.7835943286574,510.70327084640275,468.03025145048787C554.3714126377745,407.6079735673963,508.03601936045806,328.9844924480964,491.2728898941984,256.3432110539036C474.5976632858925,184.082847569629,479.9380746630129,96.60480741107993,416.23090153303,58.64404602377083C348.86323505073057,18.502131276798302,261.93793281208167,40.57373210992963,193.5410806939664,78.93577620505333C130.42746243093433,114.334589627462,98.30271207620316,179.96522072025542,76.75703585869454,249.04625023123273C51.97151888228291,328.5150500222984,13.704378332031375,421.85034740162234,66.52175969318436,486.19268352777647C119.04800174914682,550.1803526380478,217.28368757567262,524.383925680826,300,521.0016835830174','bi bi-activity', 1),
	('Eosle Commodi','Ut autem aut autem non a. Sint sint sit facilis nam iusto sint. Libero corrupti neque eum hic non ut nesciunt dolorem.','orange','M300,582.0697525312426C382.5290701553225,586.8405444964366,449.9789794690241,525.3245884688669,502.5850820975895,461.55621195738473C556.606425686781,396.0723002908107,615.8543463187945,314.28637112970534,586.6730223649479,234.56875336149918C558.9533121215079,158.8439757836574,454.9685369536778,164.00468322053177,381.49747125262974,130.76875717737553C312.15926192815925,99.40240125094834,248.97055460311594,18.661163978235184,179.8680185752513,50.54337015887873C110.5421016452524,82.52863877960104,119.82277516462835,180.83849132639028,109.12597500060166,256.43424936330496C100.08760227029461,320.3096726198365,92.17705696193138,384.0621239912766,124.79988738764834,439.7174275375508C164.83382741302287,508.01625554203684,220.96474134820875,577.5009287672846,300,582.0697525312426','bi bi-broadcast', 1),
	('Ledo Markt','Ut excepturi voluptatem nisi sed. Quidem fuga consequatur. Minus ea aut. Vel qui id voluptas adipisci eos earum corrupti.','teal','M300,541.5067337569781C382.14930387511276,545.0595476570109,479.8736841581634,548.3450877840088,526.4010558755058,480.5488172755941C571.5218469581645,414.80211281144784,517.5187510058486,332.0715597781072,496.52539010469104,255.14436215662573C477.37192572678356,184.95920475031193,473.57363656557914,105.61284051026155,413.0603344069578,65.22779650032875C343.27470386102294,18.654635553484475,251.2091493199835,5.337323636656869,175.0934190732945,40.62881213300186C97.87086631185822,76.43348514350839,51.98124368387456,156.15599469081315,36.44837278890362,239.84606092416172C21.716077023791087,319.22268207091537,43.775223500013084,401.1760424656574,96.891909868211,461.97329694683043C147.22146801428983,519.5804099606455,223.5754009179313,538.201503339737,300,541.5067337569781','bi bi-easel', 1),
	('Asperiores Commodit','Non et temporibus minus omnis sed dolor esse consequatur. Cupiditate sed error ea fuga sit provident adipisci neque.','red','M300,503.46388370962813C374.79870501325706,506.71871716319447,464.8034551963731,527.1746412648533,510.4981551193396,467.86667711651364C555.9287308511215,408.9015244558933,512.6030010748507,327.5744911775523,490.211057578863,256.5855673507754C471.097692560561,195.9906835881958,447.69079081568157,138.11976852964426,395.19560036434837,102.3242989838813C329.3053358748298,57.3949838291264,248.02791733380457,8.279543830951368,175.87071277845988,42.242879143198664C103.41431057327972,76.34704239035025,93.79494320519305,170.9812938413882,81.28167332365135,250.07896920659033C70.17666984294237,320.27484674793965,64.84698225790005,396.69656628748305,111.28512138212992,450.4950937839243C156.20124167950087,502.5303643271138,231.32542653798444,500.4755392045468,300,503.46388370962813','bi bi-bounding-box-circles', 1),
	('Velit Doloremque','Cumque et suscipit saepe. Est maiores autem enim facilis ut aut ipsam corporis aut. Sed animi at autem alias eius labore.','indigo','M300,532.3542879108572C369.38199826031484,532.3153073249985,429.10787420159085,491.63046689027357,474.5244479745417,439.17860296908856C522.8885846962883,383.3225815378663,569.1668002868075,314.3205725914397,550.7432151929288,242.7694973846089C532.6665558377875,172.5657663291529,456.2379748765914,142.6223662098291,390.3689995646985,112.34683881706744C326.66090330228417,83.06452184765237,258.84405631176094,53.51806209861945,193.32584062364296,78.48882559362697C121.61183558270385,105.82097193414197,62.805066853699245,167.19869350419734,48.57481801355237,242.6138429142374C34.843463184063346,315.3850353017275,76.69343916112496,383.4422959591041,125.22947124332185,439.3748458443577C170.7312796277747,491.8107796887764,230.57421082200815,532.3932930995766,300,532.3542879108572','bi bi-calendar4-week icon', 1),
	('Dolori Architecto','Hic molestias ea quibusdam eos. Fugiat enim doloremque aut neque non et debitis iure. Corrupti recusandae ducimus enim.','pink','M300,566.797414625762C385.7384707136149,576.1784315230908,478.7894351017131,552.8928747891023,531.9192734346935,484.94944893311C584.6109503024035,417.5663521118492,582.489472248146,322.67544863468447,553.9536738515405,242.03673114598146C529.1557734026468,171.96086150256528,465.24506316201064,127.66468636344209,395.9583748389544,100.7403814666027C334.2173773831606,76.7482773500951,269.4350130405921,84.62216499799875,207.1952322260088,107.2889140133804C132.92018162631612,134.33871894543012,41.79353780512637,160.00259165414826,22.644507872594943,236.69541883565114C3.319112789854554,314.0945973066697,72.72355303640163,379.243833228382,124.04198916343866,440.3218312028393C172.9286146004772,498.5055451809895,224.45579914871206,558.5317968840102,300,566.797414625762','bi bi-chat-square-text', 1)
;


-- SKILLS
INSERT INTO [dbo].[Skills] (Name, Percentage, ResumeId) VALUES 
	('C#/Visual Basic .NET', 100, 1),
	('UiPath', 90, 1),
	('Blazor', 70, 1),
	('Angular', 60, 1),
	('html/CSS', 75, 1),
	('JavaScript', 50, 1),
	('Sql Server', 85, 1);


-- TESTIMONIALS
INSERT INTO [dbo].[Testimonials] (Name, Occupation, SrcProfileImage, TextMessage, ResumeId) VALUES 
	('Saul Goodman', 'Ceo &amp; Founder', 'assets/img/testimonials/testimonials-1.jpg', 'Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus. Accusantium quam, ultricies eget id, aliquam eget nibh et. Maecen aliquam, risus at semper.', 1),
	('Sara Wilsson', 'Designer', 'assets/img/testimonials/testimonials-2.jpg', 'Export tempor illum tamen malis malis eram quae irure esse labore quem cillum quid cillum eram malis quorum velit fore eram velit sunt aliqua noster fugiat irure amet legam anim culpa.', 1),
	('Jena Karlis', 'Store Owner', 'assets/img/testimonials/testimonials-3.jpg', 'Enim nisi quem export duis labore cillum quae magna enim sint quorum nulla quem veniam duis minim tempor labore quem eram duis noster aute amet eram fore quis sint minim.', 1),
	('Matt Brandon', 'Freelancer', 'assets/img/testimonials/testimonials-4.jpg', 'Fugiat enim eram quae cillum dolore dolor amet nulla culpa multos export minim fugiat minim velit minim dolor enim duis veniam ipsum anim magna sunt elit fore quem dolore labore illum veniam.', 1),
	('John Larson', 'Entrepreneur', 'assets/img/testimonials/testimonials-5.jpg', 'Quis quorum aliqua sint quem legam fore sunt eram irure aliqua veniam tempor noster veniam enim culpa labore duis sunt culpa nulla illum cillum fugiat legam esse veniam culpa fore nisi cillum quid.', 1)
	;
	
	
-- TITLES
INSERT INTO [dbo].[Titles] (Name, Description, EducationalCenter, StartDate, EndDate, LocationId, ResumeId) VALUES 
	('VET Technician in Networks and Microcomputer Systems', 'Qui deserunt veniam. Et sed aliquam labore tempore sed quisquam iusto autem sit. Ea vero voluptatum qui ut dignissimos deleniti nerada porti sand markend', 'HS Doctor Balmis,', '2015-09-10 00:00:00','2017-06-20 00:00:00', 6, 1),
	('VET Multiplatform Application Development', 'Quia nobis sequi est occaecati aut. Repudiandae et iusto quae reiciendis et quis Eius vel ratione eius unde vitae rerum voluptates asperiores voluptatem Earum molestiae consequatur neque etlon sader mart dila','HS Doctor Balmis,', '2017-09-10 00:00:00','2020-06-20 00:00:00', 6, 1);

