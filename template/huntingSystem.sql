

/*
* create DB 
* run this three lines first then refresh the db in order to be shown then run the remaing code ... 
*/

USE master;
CREATE DATABASE HuntingSystem
COLLATE SQL_Latin1_General_CP1_CS_AS;


/*
* Remaing Code must be run after creating the db ...
*/
use [HuntingSystem]
create table Course(
courseID int IDENTITY(1,1) NOT NULL,
courseName NVARCHAR(255),
courseDesc text,
Primary Key (courseID) 
)

create table QuestionsBank(
questionID int IDENTITY(1,1) NOT NULL,
title NVARCHAR(255),
questionDesc NVARCHAR(255),
courseID int NOT NULL,
Primary Key (questionID), 
FOREIGN KEY (courseID) REFERENCES Course(courseID)
)

create table Answer(
answerID int IDENTITY(1,1) NOT NULL,
title NVARCHAR(255),
correct int,
questionID int NOT NULL,
Primary Key (answerID), 
FOREIGN KEY (questionID) REFERENCES QuestionsBank(questionID)
)

create table Country
(
countryID int IDENTITY(1,1) NOT NULL,
countryCode char(2) NOT NULL,
countryName varchar(255) NOT NULL,
countryNameAr NVARCHAR(255) NOT NULL,
PRIMARY KEY (countryCode)
)

create table Role(
roleID int IDENTITY(1,1) NOT NULL,
roleName NVARCHAR(255),
predefined int NOT NULL,
Primary Key (roleID)
)

create table Applicant(
applicantID int IDENTITY(1,1) NOT NULL,
username NVARCHAR(255),
pass NVARCHAR(500),
firstname NVARCHAR(255),
middlename NVARCHAR(255),
lastname NVARCHAR(255),
gender NVARCHAR(50),
dateOfBirth DATE,
placeOfBirth NVARCHAR(255),
registrationNb NVARCHAR(500),
nationality char(2),
bloodType NVARCHAR(128),
Profession NVARCHAR(500),
email NVARCHAR(255),
mailAddress NVARCHAR(255),
fax NVARCHAR(255),
city NVARCHAR(255),
applicantAddress NVARCHAR(255),
cellular NVARCHAR(255),
phone NVARCHAR(255),
accountActivated int,
activationCodeToken varchar(500),
userActivation int,
Primary Key (applicantID),
FOREIGN KEY (nationality) REFERENCES Country(countryCode)

)

create table UserTable(
userID int IDENTITY(1,1) NOT NULL,
firstName NVARCHAR(255),
lastName NVARCHAR(255),
email NVARCHAR(255),
username NVARCHAR(255),
pass NVARCHAR(500),
roleID int NOT NULL,
Primary Key (userID),
FOREIGN KEY (roleID) REFERENCES Role(roleID)
)

create table HuntingClub(
clubID int IDENTITY(1,1) NOT NULL,
clubName NVARCHAR(255),
clubAddress NVARCHAR(255),
phoneNb NVARCHAR(255),
email NVARCHAR(255),
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
examName NVARCHAR(255),
examDescription NVARCHAR(500),
examDuration decimal NOT NULL,
passingMark decimal NOT NULL,
numberOfQuestions int NOT NULL,
questionMark decimal NOT NULL,
Primary Key (examID)
)

create table ExamSchedule(
examScheduleID int IDENTITY(1,1) NOT NULL,
examID int NOT NULL,
clubID int NOT NULL,
scheduledateTime DATETime,
numberOfSeats int,
 Primary Key (examScheduleID), 
FOREIGN KEY (examID) REFERENCES Exam(examID),
FOREIGN KEY (clubID) REFERENCES HuntingClub(clubID)
)

create table ExamReservation(
reservationID int IDENTITY(1,1) NOT NULL,
examScheduleID int NOT NULL,
applicantID int NOT NULL,
referenceID int NOT NULL, 
Primary Key (reservationID), 
FOREIGN KEY (examScheduleID) REFERENCES ExamSchedule(examScheduleID),
FOREIGN KEY (applicantID) REFERENCES Applicant(applicantID),
FOREIGN KEY (referenceID) REFERENCES RegistrationRequests(referenceID)
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
staringTime DATE NOT NULL,
examDuration decimal NOT NULL,
elapsedTime TIME NOT NULL,
result decimal NOT NULL,
active int,
activationTime DATE ,
reservationID int NOT NULL, 
Primary Key (instanceID), 
FOREIGN KEY (reservationID) REFERENCES ExamReservation(reservationID),
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
name NVARCHAR(255),
code NVARCHAR(255),
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

insert into Role(roleName, predefined) values('superadmin','1');
insert into Role(roleName, predefined) values('HuntingClub2','1');
insert into Role(roleName, predefined) values('HuntingClub3','1');
insert into Role(roleName, predefined) values('HuntingClub4','1');

insert into UserTable (firstName,lastName,email,username,pass,roleID) values ('firstname','lastname','email','admin','111111',1);
insert into UserTable(firstName,lastName,email,username,pass,roleID) values('user','user','email','user2','1234',1);
/*
insert into UserTable(username, pass,firstname,roleID) values('admin2','1234','admin2','2');
*/
insert into HuntingClub(clubName, clubAddress,phoneNb,email,adminUserID) values('HuntingClub1','Beirut','70888999','club1@hunting.com','1');
insert into HuntingClub(clubName, clubAddress,phoneNb,email,adminUserID) values('HuntingClub2','Saida','70555444','club2@hunting.com','2');

/*************countries table ************/
INSERT INTO countries (countryCode, countryName,countryNameAr) VALUES
('AE', 'United Arab Emirates',N'الامارات العربية'),
('BH', 'Bahrain',N'البحرين'),
('DZ', 'Algeria',N'الجزائر'),
('EG', 'Egypt',N'مصر'),
('IQ', 'Iraq',N'العراق'),
('JO', 'Jordan',N'الأردن'),
('KW', 'Kuwait',N'الكويت'),
('LB','Lebanon',N'لبنان'),
('LY', 'Libya',N'ليبيا'),
('MA', 'Morocco',N'المغرب'),
('MR', 'Mauritania',N'موريتانيا'),
('PA', 'Palestine',N'فلسطين'),
('SA','Saudi Arabia',N'المملكة العربية السعودية'),
('QA', 'Qatar',N'قطر'),
('SD', 'Sudan',N'السودان'),
('SY', 'Syria',N'سوريا'),
('TN', 'Tunisia',N'تونس'),
('YE', 'Yemen',N'اليمن'),
('OM','Oman',N'عمان'),
('OO', 'Others',N'غير موجود')
;


