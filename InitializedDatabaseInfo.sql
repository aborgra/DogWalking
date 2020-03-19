CREATE TABLE Neighborhood (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR(55) NOT NULL
);

CREATE TABLE [Owner] (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR(55) NOT NULL,
    [Address] VARCHAR(55) NOT NULL,
    NeighborhoodId INTEGER NOT NULL,
    Phone VARCHAR(55) NOT NULL,
    CONSTRAINT FK_Owner_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
);

CREATE TABLE Walker (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR(55) NOT NULL,
    NeighborhoodId INTEGER NOT NULL,
    CONSTRAINT FK_Walker_Neighborhood FOREIGN KEY(NeighborhoodId) REFERENCES Neighborhood(Id)
);


CREATE TABLE Dog (
    Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR(55) NOT NULL,
    OwnerId INTEGER NOT NULL,
    Breed VARCHAR(55) NOT NULL,
    Notes VARCHAR(55) NOT NULL,
    CONSTRAINT FK_Dog_Owner FOREIGN KEY(OwnerId) REFERENCES [Owner](Id)
);

CREATE TABLE Walks (
   Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
   Date dateTime NOT NULL,
   Duration INTEGER NOT NULL,
   WalkerId INTEGER NOT NULL,
   DogId INTEGER NOT NULL,
   CONSTRAINT FK_Walks_Dog FOREIGN KEY(DogId) REFERENCES Dog(Id),
   CONSTRAINT FK_Walks_Walker FOREIGN KEY(WalkerId) REFERENCES Walker(Id)
);


INSERT INTO Neighborhood ([Name]) VALUES ('Tulsa');
INSERT INTO Neighborhood ([Name]) VALUES ('Jenks');
INSERT INTO Neighborhood ([Name]) VALUES ('Utah');

INSERT INTO Walker([Name], NeighborhoodId) VALUES ('Kevin', 1);
INSERT INTO Walker([Name], NeighborhoodId) VALUES ('Jansen', 2);

INSERT INTO [Owner] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Mike', '5003 E 99th st', 1,'918-728-1111');
INSERT INTO [Owner] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Madi', '123123123', 2,'918-728-1111');
INSERT INTO [Owner] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Heidi', 'Somewhere in utah', 3,'918-728-1111');
INSERT INTO [Owner] ([Name], [Address], NeighborhoodId, Phone) VALUES ('Garrett', 'Knoxville', 3,'918-728-1111');

INSERT INTO Dog ([Name], OwnerId, Breed, Notes) VALUES ('Buddy', 1, 'Husky','Very Happy Lazy Dog');
INSERT INTO Dog ([Name], OwnerId, Breed, Notes) VALUES ('Luna', 2, 'Husky','Very Happy Hyper Dog');
INSERT INTO Dog ([Name], OwnerId, Breed, Notes) VALUES ('Apollo', 2, 'Labradoodle','IDK never met him');
INSERT INTO Dog ([Name], OwnerId, Breed, Notes) VALUES ('Hazel', 3, 'American BullDog','Very Happy Lazy Dog');
INSERT INTO Dog ([Name], OwnerId, Breed, Notes) VALUES ('Lucy', 4, 'Boston Terrier','Very Happy Lazy Dog');

INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('01/01/2020', 30, 1,1);
INSERT INTO Walks ([Date], Duration, WalkerId, DogId) VALUES ('01/02/2020', 40, 1,1);

