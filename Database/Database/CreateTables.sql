
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

CREATE TABLE [Student] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Person_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Student_ToPerson] FOREIGN KEY ([Person_Id]) REFERENCES [Person] ([Id])
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
    CONSTRAINT [FK_Enrollment_Person_ID] FOREIGN KEY ([Person_ID]) REFERENCES [Person] ([Id])
);
