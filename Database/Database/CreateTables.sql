
/**
*Use this file to create all the necessary tables.
*The tables are ordered to ngith create any conflicts
**/
CREATE TABLE [Grade] (
    [Id]     INT        IDENTITY (1, 1) NOT NULL,
    [Letter] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [Department] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [Major] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Department_Id] INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Major_ToDepartment] FOREIGN KEY ([Department_Id]) REFERENCES [Department] ([Id])
);

CREATE TABLE [Season] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [Semester] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Season] INT NOT NULL,
    [Year]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Semester_Season] FOREIGN KEY ([Season]) REFERENCES [Season] ([id])
);

CREATE TABLE [Person] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NULL,
    [Email]  NVARCHAR (50) NULL,
    [Number] NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Student] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Person_Id] INT NOT NULL,
    [Major_Id]  INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Student_ToMajor] FOREIGN KEY ([Major_Id]) REFERENCES [dbo].[Major] ([Id]),
    CONSTRAINT [FK_Student_ToPerson] FOREIGN KEY ([Person_Id]) REFERENCES [dbo].[Person] ([Id])
);

CREATE TABLE [Faculty] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Person_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Faculty_ToPerson] FOREIGN KEY ([Person_Id]) REFERENCES [Person] ([Id])
);

CREATE TABLE [Course] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Department] INT           NOT NULL,
    [Major]      INT           NOT NULL,
    [Number]     INT           NOT NULL,
    [Name]       NVARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Course_ToDeparment] FOREIGN KEY ([Department]) REFERENCES [Department] ([Id]),
    CONSTRAINT [FK_Course_ToMajor] FOREIGN KEY ([Major]) REFERENCES [Major] ([Id])
);

CREATE TABLE [Section] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (40) NOT NULL,
    [Faculty_ID]  INT NOT NULL,
    [Course_ID]   INT NOT NULL,
    [Semester_ID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Section_Semester] FOREIGN KEY ([Semester_ID]) REFERENCES [Semester] ([Id]),
    CONSTRAINT [FK_Section_Faculty] FOREIGN KEY ([Faculty_ID]) REFERENCES [Faculty] ([Id]),
    CONSTRAINT [FK_Section_Course] FOREIGN KEY ([Course_ID]) REFERENCES [Course] ([Id])
);

CREATE TABLE [Enrollment] (
    [Id]            INT NOT NULL IDENTITY(1,1),
    [Person_ID]     INT NOT NULL,
    [Semester]      INT NOT NULL,
    [Course_ID]     INT NOT NULL,
    [Section_ID]    INT NOT NULL,
    [FinalGrade_ID] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enrollment_Semester] FOREIGN KEY ([Semester]) REFERENCES [Semester] ([Id]),
    CONSTRAINT [FK_Enrollment_Grade] FOREIGN KEY ([FinalGrade_ID]) REFERENCES [Grade] ([Id]),
    CONSTRAINT [FK_Enrollment_Section_ID] FOREIGN KEY ([Section_ID]) REFERENCES [Section] ([Id]),
    CONSTRAINT [FK_Enrollment_Person_ID] FOREIGN KEY ([Person_ID]) REFERENCES [Person] ([Id]),
    CONSTRAINT [FK_Enrollment_Course_ID] FOREIGN KEY ([Course_ID]) REFERENCES [Course] ([Id])
);


INSERT INTO [dbo].[Season] ([name]) VALUES ('Winter')
INSERT INTO [dbo].[Season] ([name]) VALUES ('Summer')
INSERT INTO [dbo].[Season] ([name]) VALUES ('Fall')
INSERT INTO [dbo].[Department] ([name]) VALUES ('NONE')
INSERT INTO [dbo].[Department] ([name]) VALUES ('CASL')
INSERT INTO [dbo].[Department] ([name]) VALUES ('CECS')
INSERT INTO [dbo].[Department] ([name]) VALUES ('COB')
INSERT INTO [dbo].[Department] ([name]) VALUES ('CEHHS')
INSERT INTO [dbo].[Major] ([Name],[Department_id]) VALUES ('Undecided',1)
INSERT INTO [dbo].[Major] ([Name],[Department_id]) VALUES ('Computer Science',3)
INSERT INTO [dbo].[Major] ([Name],[Department_id]) VALUES ('Computer Engineering',3)
INSERT INTO [dbo].[Major] ([Name],[Department_id]) VALUES ('Decision Sciences',4)
INSERT INTO [dbo].[Major] ([Name],[Department_id]) VALUES ('Statistics',1)
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('A+');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('A');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('A-')
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('B+');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('B');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('B-');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('C+');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('C');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('C-');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('D+');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('D');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('D-');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('E');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('P');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('F');
INSERT INTO [dbo].[Grade] ([Letter]) VALUES ('W');
INSERT INTO [dbo].[Semester] ([Season],[Year]) VALUES (1, 2019);
INSERT INTO [dbo].[Semester] ([Season],[Year]) VALUES (2, 2019);
INSERT INTO [dbo].[Semester] ([Season],[Year]) VALUES (3, 2020);
INSERT INTO [dbo].[Course] ([Department],[Major], [Number], [Name]) VALUES (1,2,297, 'Intro to C#');
INSERT INTO [dbo].[Course] ([Department],[Major], [Number], [Name]) VALUES (1,2,150, 'CIS 150');
INSERT INTO [dbo].[Course] ([Department],[Major], [Number], [Name]) VALUES (1,2,200, 'CIS 200');
INSERT INTO [dbo].[Course] ([Department],[Major], [Number], [Name]) VALUES (1,5,317, 'Statistics and Probability');
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('Kevin Lam', 'lamkk@umich.edu', '313-593-4357')
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('Antony Gordon', 'gordonad@umich.edu', '313-593-4357')
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('Tyler Senkbeil', 'dsenkbei@umich.edu', '313-593-4357')
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('Rachel Petty', 'rkpetty@umich.edu', '313-593-4357')
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('Eric Charnesky', 'echarnes@umich.edu','248-762-4206')
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('William Grosky', 'wgrosky@umich.edu', '313-583-6424')
INSERT INTO [dbo].[Person] ([Name],[Email], [Number]) VALUES ('Bruce Maxim', 'bmaxim@umich.edu', '313-436-9155')
