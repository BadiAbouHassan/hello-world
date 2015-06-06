
/*
* create tables
*/
use [HuntingSystem]
create table Course(
courseID int IDENTITY(1,1) NOT NULL,
courseName varchar(255),
courseDesc text,
Primary Key (courseID) 
)

create table QuestionsBank(
questionsBankID int IDENTITY(1,1) NOT NULL,
title varchar(255),
questionDesc varchar(255),
mark decimal,
courseID int NOT NULL,
Primary Key (questionsBankID), 
FOREIGN KEY (courseID) REFERENCES Course(courseID)
)

create table Answer(
answerID int IDENTITY(1,1) NOT NULL,
title varchar(255),
correct int,
questionID int NOT NULL,
Primary Key (ID), 
FOREIGN KEY (questionID) REFERENCES QuestionsBank(questionsBankID)
)

create table Role(
roleID int IDENTITY(1,1) NOT NULL,
roleName varchar(255),
predefined int NOT NULL,
Primary Key (roleID)
)

create table HuntingClub(
clubID int IDENTITY(1,1) NOT NULL,
clubName varchar(255),
clubAddress varchar(255),
phoneNb varchar(255),
email varchar(255),
userID int NOT NULL,
Primary Key (ID),
FOREIGN KEY (userID) REFERENCES User(questionsBankID)

)


create table Applicant(
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

create table UserTable(
ID int IDENTITY(1,1) NOT NULL,
username varchar(255),
pass varchar(500),
firstname varchar(255),
middlename varchar(255),
lastname varchar(255),
email varchar(255),
cellular varchar(255),
phone varchar(255),
clubID int  NOT NULL,
roleID int NOT NULL.
Primary Key (ID),
FOREIGN KEY (roleID) REFERENCES RoleTable(ID),
FOREIGN KEY (clubID) REFERENCES HuntingClub(ID)
)


create table RegistrationRequests(
ID int IDENTITY(1,1) NOT NULL,
applicantID int NOT NULL,
clubID int NOT NULL,
registrationRequestsDate DATE,
verifiedByAdmin int,
verifiationDate DATE, 
Primary Key (ID), 
FOREIGN KEY (applicantID) REFERENCES Applicant(ID),
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
/****************INSERT STATIC QUERIES
/***********************************************************************/

use [HuntingSystem]


insert into HuntingClub(clubname, clubAddress,phoneNb,email) values('HuntingClub1','Beirut','70888999','club1@hunting.com');
insert into HuntingClub(clubname, clubAddress,phoneNb,email) values('HuntingClub2','Saida','70555444','club2@hunting.com');
insert into HuntingClub(clubname, clubAddress,phoneNb,email) values('HuntingClub3','Tripoli','70666333','club3@hunting.com');
insert into HuntingClub(clubname, clubAddress,phoneNb,email) values('HuntingClub4','Nabatieh','70111222','club4@hunting.com');


insert into RoleTable(roleName, predefined) values('superadmin','1');
insert into RoleTable(roleName, predefined) values('HuntingClub2','1');
insert into RoleTable(roleName, predefined) values('HuntingClub3','1');
insert into RoleTable(roleName, predefined) values('HuntingClub4','1');
