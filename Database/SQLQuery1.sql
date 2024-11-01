

create database DiemDanh
go
use DiemDanh
go

CREATE TABLE Account (
    id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(50) NOT NULL,
    FullName NVARCHAR(100) NOT NULL
);

CREATE TABLE FileAcc (
    id INT PRIMARY KEY IDENTITY(1,1),
    file_name NVARCHAR(255) NOT NULL,
    account_id INT,
    FOREIGN KEY (account_id) REFERENCES Account(id)
);
CREATE TABLE StudentUploads (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự động tăng
    StudentId VARCHAR(50) NOT NULL,    -- Mã số sinh viên
    LocalIPAddress VARCHAR(15) NOT NULL, -- Địa chỉ IP cục bộ
    GPSCoordinates VARCHAR(50) NOT NULL, -- Tọa độ GPS
    CreatedAt DATETIME DEFAULT GETDATE() -- Thời gian tạo bản ghi
);
CREATE TABLE TeacherQRData (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    QRCode VARCHAR(5) NOT NULL,
    GPSCoordinates VARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE InfoFile (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FileId INT NOT NULL,
    NumberOfLessons INT DEFAULT -1,
    AbsencePercentage INT DEFAULT -1
FOREIGN KEY (FileId) REFERENCES FileAcc(id)
);
go
CREATE TRIGGER trg_AfterInsert_FileAcc
ON FileAcc
AFTER INSERT
AS
BEGIN
    -- Thêm một bản ghi vào InfoFile tương ứng với bản ghi mới trong FileAcc
    INSERT INTO InfoFile (FileId)
    SELECT id FROM inserted;
END;
go
CREATE TRIGGER trg_AfterDelete_FileAcc
ON FileAcc
AFTER DELETE
AS
BEGIN
    -- Xóa bản ghi trong InfoFile tương ứng với bản ghi bị xóa trong FileAcc
    DELETE FROM InfoFile
    WHERE FileId IN (SELECT id FROM deleted);
END;