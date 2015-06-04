
/*
* create tables
*/
use [HuntingSystem]
create table Course(
ID int IDENTITY(1,1) NOT NULL,
courseName varchar(255),
courseDesc text,
Primary Key (ID) 
)

create table QuestionsBank(
ID int IDENTITY(1,1) NOT NULL,
title varchar(255),
descripton varchar(255),
mark decimal,
courseID int NOT NULL,
Primary Key (ID), 
FOREIGN KEY (courseID) REFERENCES Course(ID)
)

create table Answer(
ID int IDENTITY(1,1) NOT NULL,
title varchar(255),
correct int,
questionID int NOT NULL,
Primary Key (ID), 
FOREIGN KEY (questionID) REFERENCES QuestionsBank(ID)
)

create table RoleTable(
ID int IDENTITY(1,1) NOT NULL,
roleName varchar(255),
predefined int NOT NULL,
Primary Key (ID)
)

create table HuntingClub(
ID int IDENTITY(1,1) NOT NULL,
clubname varchar(255),
clubAddress varchar(255),
phoneNb varchar(255),
email varchar(255),
Primary Key (ID),
)


create table UserTable(
ID int IDENTITY(1,1) NOT NULL,
username varchar(255),
pass varchar(500),
firstname varchar(255),
middlename varchar(255),
lastname varchar(255),
gender varchar(50),
dateOfBirth DATE,
placeOfBirth varchar(255),
registrationNb varchar(500),
nationality varchar(255),
bloodType varchar(128),
Profession varchar(500),
email varchar(255),
mailAddress varchar(255),
fax varchar(255),
city varchar(255),
userAddress varchar(255),
cellular varchar(255),
phone varchar(255),
roleID int  NOT NULL,
clubID int  NOT NULL,
Primary Key (ID),
FOREIGN KEY (roleID) REFERENCES RoleTable(ID),
FOREIGN KEY (clubID) REFERENCES HuntingClub(ID)

)



create table RegistrationRequests(
ID int IDENTITY(1,1) NOT NULL,
userID int NOT NULL,
clubID int NOT NULL,
registrationRequestsDate DATE,
verifiedByAdmin int,
verifiationDate DATE, 
Primary Key (ID), 
FOREIGN KEY (userID) REFERENCES UserTable(ID),
FOREIGN KEY (clubID) REFERENCES HuntingClub(ID)
)

create table Exam(
ID int IDENTITY(1,1) NOT NULL,
examName varchar(255),
examDate DATE NOT NULL,
examDuration decimal NOT NULL,
elapsedTime TIME NOT NULL,
result decimal NOT NULL,
referenceID int NOT NULL, 
Primary Key (ID), 
FOREIGN KEY (referenceID) REFERENCES RegistrationRequests(ID)
)

create table ExamQuestions(
ID int IDENTITY(1,1) NOT NULL,
questionID int NOT NULL,
examID int NOT NULL,
Primary Key (ID), 
FOREIGN KEY (questionID) REFERENCES QuestionsBank(ID),
FOREIGN KEY (examID) REFERENCES Exam(ID)
)

create table Permission(
ID int IDENTITY(1,1) NOT NULL,
name varchar(255),
code varchar(255),
Primary Key (ID)
)

create table grantedPermission(
ID int IDENTITY(1,1) NOT NULL,
permissionID int NOT NULL,
roleID int NOT NULL,
Primary Key (ID),
FOREIGN KEY (permissionID) REFERENCES Permission(ID),
FOREIGN KEY (roleID) REFERENCES RoleTable(ID)
)

/**********************************************************************/