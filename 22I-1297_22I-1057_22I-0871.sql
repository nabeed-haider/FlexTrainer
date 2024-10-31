CREATE DATABASE DBProject;

CREATE TABLE Admin(
AdminID INT identity(1,1),
Name VARCHAR(30), 
Email VARCHAR(30), 
Password VARCHAR(10)
PRIMARY KEY (AdminID)
);


CREATE TABLE GymOwner
(
OwnerID INT identity(1,1),
Name VARCHAR(30), 
Email VARCHAR(30),
Password VARCHAR(10)
PRIMARY KEY (OwnerID)
);


Create table Trainer(
TrainerID int identity(1,1),
Name varchar(20),
Email varchar(100),
username varchar(100),
Password varchar(100),
PhoneNo varchar(15)
Primary key(TrainerID)
);
select * from Trainer



CREATE TABLE Gym(
GymID INT identity(1,1),
Name VARCHAR(50),
Location VARCHAR(100),
OwnerID INT NOT NULL,
PRIMARY KEY (GymID),
FOREIGN KEY (OwnerID) REFERENCES GymOwner(OwnerID) on delete cascade on update cascade,
);


CREATE TABLE Member1(
member_id INTEGER identity(1,1),
member_FName VARCHAR(255) ,
member_LName VARCHAR(255) ,
member_Email VARCHAR(255) ,
member_password VARCHAR(255) NOT NULL,
member_username VARCHAR(255) NOT NULL,
member_DOB Date,
member_RegDate Date,
Member_Height Numeric(2),
Member_Weight Numeric(2),
member_Gender VARCHAR(255) ,
member_goal VARCHAR(255) ,
GymID INT NOT NULL,
PRIMARY KEY(member_id),
FOREIGN KEY (GymID) REFERENCES Gym(GymID)on delete cascade on update cascade
);


CREATE TABLE Member_WorkoutPlan(MemberID INT NOT NULL,
PlanID INT NOT NULL,
FOREIGN KEY (MemberID) REFERENCES Member1(member_id), 
FOREIGN KEY (PlanID) REFERENCES WorkoutPlan(WorkoutPlan_Id) on delete cascade on update cascade,
PRIMARY KEY (MemberID,PlanID));

CREATE TABLE Exercise (
Exercise_id INTEGER identity(1,1),
Exercise_Name VARCHAR(255),
Exercise_sets INTEGER,
Exercise_Reps INTEGER,
Exercise_RestTime INTEGER,
WorkoutPlan_id INTEGER,
PRIMARY KEY(Exercise_id),
FOREIGN KEY(WorkoutPlan_id) REFERENCES WorkoutPlan(WorkoutPlan_id) on delete cascade on update cascade
);

CREATE TABLE WorkoutPlan (
WorkoutPlan_id INTEGER identity(1,1),
WorkoutPlan_Name VARCHAR(255),
WorkoutPlan_goal VARCHAR(255),
trainer_id INTEGER,
member_id INTEGER,
GymID INTEGER,
PRIMARY KEY(WorkoutPlan_id),
FOREIGN KEY(trainer_id) REFERENCES TRAINER(trainerid) on delete cascade on update cascade,
FOREIGN KEY(member_id) REFERENCES Member1(member_id) on delete cascade on update cascade,
FOREIGN KEY (GymID) REFERENCES Gym(GymID)
);




CREATE TABLE WorkoutPlan2 (
WorkoutPlan2_id INTEGER identity(1,1),
trainer_id INTEGER,
member_id INTEGER,
WorkoutPlan_id INTEGER,
PRIMARY KEY(WorkoutPlan2_id),
FOREIGN KEY(trainer_id) REFERENCES TRAINER(TrainerID) on delete cascade on update cascade,
FOREIGN KEY(member_id) REFERENCES Member1(member_id),
FOREIGN KEY (WorkoutPlan_id) REFERENCES WorkoutPlan(WorkoutPlan_id)
);


CREATE TABLE Muscle(ExerciseID INT NOT NULL,
MuscleID INT NOT NULL,
Name VARCHAR(20),
FOREIGN KEY (ExerciseID) REFERENCES Exercise(Exercise_ID) on delete cascade on update cascade,
PRIMARY KEY (ExerciseID,MuscleID));


CREATE TABLE Machine(MachineID INT NOT NULL PRIMARY KEY,
Name VARCHAR (30));

CREATE TABLE Exercise_Machine(MachineID INT NOT NULL,
ExerciseID INT NOT NULL,
FOREIGN KEY (MachineID) REFERENCES Machine(MachineID) on delete cascade on update cascade,
FOREIGN KEY (ExerciseID) REFERENCES Exercise(Exercise_ID) on delete cascade on update cascade,
PRIMARY KEY (MachineID, ExerciseID));


CREATE TABLE DietPlan (
DietPlan_id INTEGER identity(1,1),
DietPlan_Name VARCHAR(255) ,
DietPlan_goal VARCHAR(255),
trainer_id INTEGER,
member_id INTEGER,
GymID INTEGER,
PRIMARY KEY(DietPlan_id),
FOREIGN KEY(trainer_id) REFERENCES TRAINER(TrainerID) on delete cascade on update cascade,
FOREIGN KEY(member_id) REFERENCES Member1(member_id) on delete cascade on update cascade,
FOREIGN KEY (GymID) REFERENCES Gym(GymID)
);

--============================

CREATE TABLE DietPlan2 (
DietPlan2_id INTEGER identity(1,1),
trainer_id INTEGER,
member_id INTEGER,
DietPlan_id INTEGER,
PRIMARY KEY(DietPlan2_id),
FOREIGN KEY(trainer_id) REFERENCES TRAINER(TrainerID) on delete cascade on update cascade,
FOREIGN KEY(member_id) REFERENCES Member1(member_id) on delete cascade on update cascade,
FOREIGN KEY (DietPlan_id) REFERENCES DietPlan(DietPlan_id)
);


CREATE TABLE MEAL(
Meal_id INTEGER identity(1,1),
Meal_Name VARCHAR(255),
Meal_type VARCHAR(255),
Meal_cal Numeric(5,2),
Meal_fats Numeric(5,2),
Meal_protein Numeric(5,2),
DietPlan_id INTEGER ,
PRIMARY KEY(Meal_id),
FOREIGN KEY(DietPlan_id) REFERENCES DietPlan(DietPlan_id) on delete cascade on update cascade
);


CREATE TABLE DietPlan_Meals(DietPlanID INT NOT NULL,
MealID INT NOT NULL,
FOREIGN KEY (DietPlanID) REFERENCES DietPlan(DietPlan_ID) on delete cascade on update cascade,
FOREIGN KEY (MealID) REFERENCES Meal(Meal_ID),
PRIMARY KEY (MealID, DietPlanID));


CREATE TABLE Allergies(MealID INT NOT NULL FOREIGN KEY REFERENCES Meal(Meal_ID),
MemberID INT NOT NULL FOREIGN KEY REFERENCES Member1(Member_ID) on delete cascade on update cascade,
PRIMARY KEY (MealID, MemberID),
Allergen VARCHAR (20));

CREATE TABLE Registration_Requests(GymName varchar(50), Location varchar(50), OwnerDetail varchar (50), BusinessDetails VARCHAR (50), Facilites VARCHAR(50), Status VARCHAR(20), RequestID INT  Identity(1,1), OwnerID INT NOT NULL,
PRIMARY KEY (RequestID),
FOREIGN KEY (OwnerID) REFERENCES GymOwner(OwnerID) on delete cascade on update cascade,
);


CREATE TABLE Trainer_Requests(Name varchar(100), email varchar(100),Password varchar(100),PhoneNo varchar(100),username varchar(100),Expierience varchar(100),Specialty varchar(100), Status VARCHAR(20), RequestID INT  Identity(1,1), trainerId INT NOT NULL, ownerId INT NOT NULL,
PRIMARY KEY (RequestID),
FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerID) on delete cascade on update cascade,
FOREIGN KEY (ownerId) REFERENCES GymOwner(OwnerID) on delete cascade on update cascade

);


CREATE TABLE PerformanceMetric(MetricID INT NOT NULL,
MemberRates NUMERIC(5,2),
MemberSatisfaction VARCHAR(15),
MembershipGrowth VARCHAR (20),
FinancialPerformance VARCHAR(40),
AdminID INT NOT NULL,
GymID INT NOT NULL,
PRIMARY KEY (MetricID),
FOREIGN KEY (AdminID) REFERENCES Admin(AdminID) on delete cascade on update cascade,
FOREIGN KEY (GymID) REFERENCES Gym(GymID) on delete cascade on update cascade
);

Create Table TrainerReport
(
GymId INT NOT NULL,
TrainerId INT NOT NULL,
Speciality varchar(50),
Expierience varchar(50),
Foreign Key (GymId) References Gym(GymId) on delete cascade on update cascade,
Foreign Key (TrainerId) References Trainer(TrainerId) on delete cascade on update cascade,
);



Create table Sessions
(
	SessionId INT PRIMARY KEY identity(1,1),
	TrainerId INT foreign key references Trainer(TrainerId) on delete cascade on update cascade,
	MemberId INT Foreign Key References Member1(Member_id) on delete cascade on update cascade,
	start_d date,
	end_d date,
	Status varchar(20)
);

CREATE TABLE Trainer_Feedback (
    FeedbackID INT PRIMARY KEY identity(1,1),
    trainer_ID INT,
	member_id INT,
	sesion_id INT,
    FOREIGN KEY (trainer_ID) REFERENCES Trainer(TrainerID) on delete cascade on update cascade,
	FOREIGN KEY(member_id) REFERENCES Member1(member_id) on delete cascade on update cascade,
	FOREIGN KEY(sesion_id) REFERENCES Sessions(SessionId)
);

Create Table MemberReport
(
	MemberId INT Foreign key References Member1(Member_Id) on delete cascade on update cascade,
	GymId INT FOREIGN KEY REFERENCES Gym(GymID) ,
	MemberShipDuration varchar(25),
	MemberShipType varchar(20),
	Goals varchar(100)
);




CREATE TABLE Gym_Trainer(GymID INT NOT NULL FOREIGN KEY REFERENCES Gym(GymID),
TrainerID INT NOT NULL FOREIGN KEY REFERENCES Trainer(TrainerID) on delete cascade on update cascade,
PRIMARY KEY (GymID,TrainerID),
Rating INT NOT NULL);


CREATE TABLE Feedback_questions (
    fq_id INT PRIMARY KEY identity(1,1),
    feedback_ID INT,
    Question VARCHAR(255),
    Answer VARCHAR(255),
    FOREIGN KEY (feedback_ID) REFERENCES Trainer_Feedback(FeedbackID) on delete cascade on update cascade
);

create table Expanses(
gymid int foreign key References Gym(GymId),
Membership Int,
Wages Int
);
select * from Trainer_Requests
drop table expanses

Create table Audit_Trail(
AuditId Int Primary Key Identity(1,1),
Action varchar(20) Not NULL,
Time_stamp DateTime,
details varchar(100)
);


--============ TRIGGERS ==================
 CREATE TRIGGER GymInsertion 
ON Gym
AFTER INSERT
AS
BEGIN
DECLARE @name varchar(20);
SELECT @name = Name from inserted;
INSERT INTO Audit_Trail VALUES('Gym Added',getDate(),'Gym ' + @name + ' Added')
END

-------------

 CREATE TRIGGER GymDeletion 
ON Gym
AFTER DELETE
AS
BEGIN
DECLARE @name varchar(20);
SELECT @name = Name from deleted;
INSERT INTO Audit_Trail VALUES('Gym Deleted',getDate(),'Gym ' + @name + ' Deleted')
END

--------------
 CREATE TRIGGER TrainerInsertion 
ON Trainer
AFTER INSERT
AS
BEGIN
DECLARE @name varchar(20);
SELECT @name = Name from inserted;
INSERT INTO Audit_Trail VALUES('Trainer Added',getDate(),'Trainer ' + @name + ' Added')
END
------------
 CREATE TRIGGER TrainerDeletion 
ON Trainer
AFTER DELETE
AS
BEGIN
DECLARE @name varchar(20);
SELECT @name = Name from deleted;
INSERT INTO Audit_Trail VALUES('Trainer Deleted',getDate(),'Trainer ' + @name + ' Deleted')
END
---------------
 CREATE TRIGGER MemberInserion 
ON Member1
AFTER Insert
AS
BEGIN
DECLARE @name varchar(20);
SELECT @name = member_FName from inserted;
INSERT INTO Audit_Trail VALUES('Member Added',getDate(),'Member ' + @name + ' Added')
END

 CREATE TRIGGER MemberDeletion 
ON Member1
AFTER DELETE
AS
BEGIN
DECLARE @name varchar(20);
SELECT @name = member_FName from deleted;
INSERT INTO Audit_Trail VALUES('Member Deleted',getDate(),'Member ' + @name + ' Deleted')
END

CREATE Trigger Insert_DietPlan
ON DietPlan
AFTER Insert
AS 
BEGIN 
DECLARE @DietID INT;
DECLARE @TrainerID INT; 
SELECT @DietID = inserted.DietPlan_ID,@TrainerID=inserted.trainer_id from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Diet Plan ' , @DietID,'associated with Trainer ' ,@TrainerID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getDate(),@Details);
END;

select * from gymOwner

CREATE Trigger Delete_DietPlan
ON DietPlan
AFTER Delete
AS 
BEGIN 
DECLARE @DietID INT;
DECLARE @TrainerID INT; 
SELECT @DietID = inserted.DietPlan_ID,@TrainerID=inserted.Trainer_ID from inserted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Diet Plan ' , @DietID,'associated with Trainer ' ,@TrainerID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE Trigger Insert_Admin
ON Admin
AFTER Insert
AS 
BEGIN 
DECLARE @AdminID INT;
SELECT @AdminID= inserted.AdminID from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Admin ' , @AdminID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE Trigger Delete_Admin
ON Admin
AFTER Delete
AS 
BEGIN 
DECLARE @AdminID INT;
SELECT @AdminID = deleted.AdminID from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Admin ' , @AdminID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;


CREATE Trigger Insert_Exercise
ON Exercise
AFTER Insert
AS 
BEGIN 
DECLARE @ExerciseID INT;
SELECT @ExerciseID= inserted.Exercise_ID from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Exericse' , @ExerciseID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE Trigger Delete_Exercise
ON Exercise
AFTER Delete
AS 
BEGIN 
DECLARE @ExerciseID INT;
SELECT @ExerciseID = deleted.Exercise_ID from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Exercise ' , @ExerciseID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;


CREATE Trigger Insert_Meal
ON Meal
AFTER Insert
AS 
BEGIN 
DECLARE @MealID INT;
SELECT @MealID = inserted.Meal_id from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Meal ' , @MealID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;
select * from meal

CREATE Trigger Delete_Meal
ON Meal
AFTER Delete
AS 
BEGIN 
DECLARE @MealID INT;
SELECT @MealID= deleted.Meal_id from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Meal ' , @MealID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;


CREATE Trigger Insert_Muscle
ON Muscle
AFTER Insert
AS 
BEGIN 
DECLARE @MuscleID INT;
DECLARE @ExerciseID INT;
SELECT @MuscleID = inserted.MuscleID, @ExerciseID=inserted.ExerciseID from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Muscle ' , @MuscleID, ' associated with ', @ExerciseID, ' has been created' );
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE Trigger Delete_Muscle
ON Muscle
AFTER Delete
AS 
BEGIN 
DECLARE @MuscleID INT;
DECLARE @ExerciseID INT;
SELECT @MuscleID = inserted.MuscleID, @ExerciseID=inserted.ExerciseID from inserted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Muscle ' , @MuscleID, ' associated with ', @ExerciseID, ' has been deleted' );
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;



CREATE Trigger Insert_Machine
ON Machine
AFTER Insert
AS 
BEGIN 
DECLARE @MachineId INT;
SELECT @MachineId = inserted.MachineID from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Machine ' , @MachineID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE Trigger Delete_Machine
ON Machine
AFTER Delete
AS 
BEGIN 
DECLARE @MachineID INT;
SELECT @MachineID = deleted.MachineID from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Machine ' , @MachineID ,'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;


CREATE Trigger Insert_Sessions
ON Sessions
AFTER Insert
AS 
BEGIN 
DECLARE @SessionID INT;
DECLARE @MemberID INT;
DECLARE @TrainerID INT;
SELECT @SessionID = inserted.SessionId, @MemberID=inserted.MemberId, @TrainerID=inserted.TrainerId from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Session ' , @SessionID, 'has been created' , 'between Member ',@MemberID,'and Trainer ',@TrainerID );
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;


CREATE Trigger Delete_Sessions
ON Sessions
AFTER Delete
AS 
BEGIN 
DECLARE @SessionID INT;
DECLARE @MemberID INT;
DECLARE @TrainerID INT;
SELECT @SessionID = deleted.SessionId, @MemberID=deleted.MemberId, @TrainerID=deleted.TrainerId from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Session ' , @SessionID,'between Member ',@MemberID,'and Trainer ',@TrainerID,'has been deleted' );
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE TRigger Update_Sessions
ON Sessions
AFTER Update
AS 
BEGIN 
DECLARE @SessionID INT;
SELECT @SessionID = inserted.SessionId from inserted;
DECLARE @Type VARCHAR(20) = 'Update';
DECLARE @Details VARCHAR(50) = CONCAT('Session ' , @SessionID, 'has been updated ' );
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;




CREATE Trigger Insert_WorkoutPlan
ON WorkoutPlan
AFTER Insert
AS 
BEGIN 
DECLARE @WorkoutID INT;
DECLARE @TrainerID INT; 
SELECT @WorkoutID = inserted.WorkoutPlan_id,@TrainerID=inserted.Trainer_ID from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Workout Plan ' , @WorkoutID,'associated with Trainer ' ,@TrainerID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);

END;

CREATE Trigger Delete_workoutPlan
ON WorkoutPlan
AFTER Delete
AS 
BEGIN 
DECLARE @WorkoutID INT;
DECLARE @TrainerID INT; 
SELECT @WorkoutID = deleted.WorkoutPlan_id,@TrainerID=deleted.Trainer_ID from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Workout Plan ' , @WorkoutID,'associated with Trainer ' ,@TrainerID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);
END;

CREATE Trigger Insert_Registration
ON Registration_Requests
AFTER Insert
AS
BEGIN
DECLARE @OwnerID INT;
DECLARE @RequestID INT; 
SELECT @OwnerID = inserted.OwnerID,@RequestID =inserted.RequestID from inserted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Registration Request ' , @RequestID,'has been submitted to' ,@OwnerID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);
END;

CREATE Trigger Delete_Registration
ON Registration_Requests
AFTER Delete
AS
BEGIN
DECLARE @OwnerID INT;
DECLARE @RequestID INT; 
SELECT @OwnerID = deleted.OwnerID,@RequestID =deleted.RequestID from deleted;
DECLARE @Type VARCHAR(20) = 'Deletion';
DECLARE @Details VARCHAR(50) = CONCAT('Registration Request ' , @RequestID,'has been submitted to' ,@OwnerID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);
END;

CREATE Trigger Insert_Metric
ON PerformanceMetric
AFTER Insert
AS
BEGIN
DECLARE @MetricID INT;
DECLARE @GymID INT; 
DECLARE @AdminID INT;
SELECT @MetricID = inserted.MetricID,@GymID =inserted.GymID, @AdminID=inserted.AdminID from inserted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Metric ' , @MetricID,'associated with Gym ' ,@GymID, ' and Admin ',@AdminID, 'has been created');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);
END;

CREATE Trigger Delete_Metric
ON PerformanceMetric
AFTER Insert
AS
BEGIN
DECLARE @MetricID INT;
DECLARE @GymID INT; 
DECLARE @AdminID INT;
SELECT @MetricID = deleted.MetricID,@GymID =deleted.GymID, @AdminID=deleted.AdminID from deleted;
DECLARE @Type VARCHAR(20) = 'Insertion';
DECLARE @Details VARCHAR(50) = CONCAT('Metric ' , @MetricID,'associated with Gym ' ,@GymID, ' and Admin ',@AdminID, 'has been deleted');
INSERT INTO Audit_Trail VALUES(@Type,getdate(),@Details);
END;



