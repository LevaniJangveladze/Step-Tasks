CREATE TABLE Users
(
    Id       INT IDENTITY (1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email    NVARCHAR(100) NOT NULL UNIQUE,
    IsActive BIT DEFAULT 1,
    Phone NVARCHAR(20)
);

INSERT INTO Users (FullName, Email, Phone)
VALUES ('Nika Beridze', 'nika@gmail.com', '+995599123456'),
       ('Ana Kvaratskhelia', 'ana.kv@gmail.com', '+995577889900'),
       ('Giorgi Lomidze', 'giorgi.l@yahoo.com', '+995591234567'),
       ('Mariam Tsiklauri', 'mariam.ts@gmail.com', '+995598112233'),
       ('Levan Gogoladze', 'levan.g@outlook.com', '+995555443322');


CREATE TABLE Rooms
(
    Id       INT IDENTITY (1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(10) UNIQUE,
    TypeRoom  NVARCHAR(50)  NOT NULL,
    Price     DECIMAL(10, 2) NOT NULL,
    Capacity  INT           NOT NULL,
    Available BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT SYSUTCDATETIME()
);

INSERT INTO Rooms (RoomNumber, TypeRoom, Price, Capacity)
VALUES ('101', 'Single', 95.00, 1),
       ('102', 'Single', 110.00, 1),
       ('201', 'Double', 180.00, 2),
       ('202', 'Double', 220.00, 2),
       ('301', 'Suite', 450.00, 4),
       ('302', 'Suite', 520.00, 4);
UPDATE Rooms SET Available = 0 WHERE RoomNumber IN ('102', '301');
UPDATE Users SET IsActive = 0 WHERE Email = 'giorgi.l@yahoo.com';
SELECT * FROM Users;
SELECT * FROM Rooms;
SELECT COUNT(*) FROM Rooms;
SELECT AVG(Price) FROM Rooms;
SELECT MAX(Price) FROM Rooms;
SELECT TypeRoom, MAX(Price) AS MaxPrice FROM Rooms GROUP BY TypeRoom;
SELECT * FROM Users WHERE Email LIKE '%gmail.com';
SELECT * FROM Rooms WHERE TypeRoom IN ('Single', 'Double');
SELECT * FROM Rooms WHERE Price BETWEEN 100 AND 300;
SELECT TOP 3 * FROM Rooms ORDER BY Price DESC;
SELECT FullName FROM Users ORDER BY FullName;
SELECT Email FROM Users WHERE IsActive = 0;
SELECT COUNT(*) AS TotalUsers FROM Users;
SELECT FullName, Email FROM Users;
