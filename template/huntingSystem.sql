

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
questionID int IDENTITY(1,1) NOT NULL,
title varchar(255),
questionDesc varchar(255),
courseID int NOT NULL,
Primary Key (questionID), 
FOREIGN KEY (courseID) REFERENCES Course(courseID)
)

create table Answer(
answerID int IDENTITY(1,1) NOT NULL,
title varchar(255),
correct int,
questionID int NOT NULL,
Primary Key (answerID), 
FOREIGN KEY (questionID) REFERENCES QuestionsBank(questionID)
)

create table Role(
roleID int IDENTITY(1,1) NOT NULL,
roleName varchar(255),
predefined int NOT NULL,
Primary Key (roleID)
)

create table Applicant(
applicantID int IDENTITY(1,1) NOT NULL,
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
applicantAddress varchar(255),
cellular varchar(255),
phone varchar(255),
Primary Key (applicantID)
)

create table UserTable(
userID int IDENTITY(1,1) NOT NULL,
firstName varchar(255),
lastName varchar(255),
email varchar(255),
username varchar(255),
pass varchar(500),
roleID int NOT NULL,
Primary Key (userID),
FOREIGN KEY (roleID) REFERENCES Role(roleID)
)

create table HuntingClub(
clubID int IDENTITY(1,1) NOT NULL,
clubName varchar(255),
clubAddress varchar(255),
phoneNb varchar(255),
email varchar(255),
adminUserID int NOT NULL,
Primary Key (clubID),
FOREIGN KEY (adminUserID) REFERENCES UserTable(userID)
)

create table RegistrationRequests(
referenceID int IDENTITY(1,1) NOT NULL,
applicantID int NOT NULL,
clubID int NOT NULL,
registrationRequestsDate DATE,
verifiedByAdmin int,
verificationDate DATE, 
Primary Key (referenceID), 
FOREIGN KEY (applicantID) REFERENCES Applicant(applicantID),
FOREIGN KEY (clubID) REFERENCES HuntingClub(clubID)
)

create table Exam(
examID int IDENTITY(1,1) NOT NULL,
examName varchar(255),
examDescription varchar(500),
examDuration decimal NOT NULL,
passingMark decimal NOT NULL,
numberOfQuestions int NOT NULL,
questionMark decimal NOT NULL,
Primary Key (examID)
)

create table QuestionsPerCourse(
questionsPerCourseID int IDENTITY(1,1) NOT NULL,
questionsPerCourseNb int NOT NULL,
examID int NOT NULL,
courseID int NOT NULL,
PRIMARY KEY  (questionsPerCourseID),
FOREIGN KEY (examID) REFERENCES Exam(examID),
FOREIGN KEY (courseID) REFERENCES Course(courseID)
)

create table ExamInstance(
instanceID int IDENTITY(1,1) NOT NULL,
examID int NOT NULL,
examDate DATE NOT NULL,
examDuration decimal NOT NULL,
elapsedTime TIME NOT NULL,
result decimal NOT NULL,
referenceID int NOT NULL, 
Primary Key (instanceID), 
FOREIGN KEY (referenceID) REFERENCES RegistrationRequests(referenceID),
FOREIGN KEY (examID) REFERENCES Exam(examID)

)

create table ExamQuestions(
examQuestionID int IDENTITY(1,1) NOT NULL,
questionID int NOT NULL,
examInstanceID int NOT NULL,
Primary Key (examQuestionID), 
FOREIGN KEY (questionID) REFERENCES QuestionsBank(questionID),
FOREIGN KEY (examInstanceID) REFERENCES ExamInstance(instanceID)
)



create table Permission(
permissionID int IDENTITY(1,1) NOT NULL,
name varchar(255),
code varchar(255),
Primary Key (permissionID)
)

create table grantedPermission(
grantedPermissionID int IDENTITY(1,1) NOT NULL,
permissionID int NOT NULL,
roleID int NOT NULL,
Primary Key (grantedPermissionID),
FOREIGN KEY (permissionID) REFERENCES Permission(permissionID),
FOREIGN KEY (roleID) REFERENCES Role(roleID)
)

insert into UserTable(username, pass,firstname,roleID) values('admin1','1234','admin1','1');
insert into UserTable(username, pass,firstname,roleID) values('admin2','1234','admin2','2');

insert into HuntingClub(clubname, clubAddress,phoneNb,email,adminUserID) values('HuntingClub1','Beirut','70888999','club1@hunting.com','1');
insert into HuntingClub(clubname, clubAddress,phoneNb,email,adminUserID) values('HuntingClub2','Saida','70555444','club2@hunting.com','2');


insert into Role(roleName, predefined) values('superadmin','1');
insert into Role(roleName, predefined) values('HuntingClub2','1');
insert into Role(roleName, predefined) values('HuntingClub3','1');
insert into Role(roleName, predefined) values('HuntingClub4','1');
