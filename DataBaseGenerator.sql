drop table Books
go

drop table Movies
go

drop table Music
go

drop table Records
go

drop table Logins

go

CREATE TABLE Books
(
	ID_Record  int  NOT NULL ,
	PublishingHouse  varchar(50) NOT NULL ,
	Pages  int NOT NULL 
)
go


ALTER TABLE Books
	ADD CONSTRAINT  XPKBooks PRIMARY KEY   NONCLUSTERED (ID_Record  ASC)
go


CREATE TABLE Logins
(
	ID_Login  int  IDENTITY (1,1) ,
	EMail  varchar(50)  NOT NULL UNIQUE ,
	Login  varchar(50)  NOT NULL UNIQUE,
	Password  varchar(50)  NOT NULL ,
	IsAdmin  bit  NOT NULL 
)
go


ALTER TABLE Logins
	ADD CONSTRAINT  XPKLogins PRIMARY KEY   NONCLUSTERED (ID_Login  ASC)
go


CREATE TABLE Movies
(
	ID_Record  int  NOT NULL ,
	PlayTime  varchar(20) NOT NULL ,
	Genre  varchar(20) NOT NULL ,
	Quality  varchar(20) NOT NULL
)
go


ALTER TABLE Movies
	ADD CONSTRAINT  XPKMovies PRIMARY KEY   NONCLUSTERED (ID_Record  ASC)
go


CREATE TABLE Music
(
	ID_Record  int  NOT NULL ,
	PlayTime  varchar(20) NOT NULL ,
	Bitrate  int NOT NULL ,
	Album  varchar(50) NOT NULL,
	Style  varchar(20) NOT NULL 
)
go


ALTER TABLE Music
	ADD CONSTRAINT  XPKMusic PRIMARY KEY   NONCLUSTERED (ID_Record  ASC)
go


CREATE TABLE Records
(
	ID_Record  int  IDENTITY (1,1) ,
	Name varchar(250) NOT NULL ,
	Image varchar(100) NULL, 
	Author  varchar(50) NOT NULL ,
	Year  int  NOT NULL ,
	UploadBy  int NOT NULL ,
	UploadDate  datetime NOT NULL ,
	Type  varchar(20)  NOT NULL,
	FileWay varchar(100) NOT NULL,
	Format  varchar(20)  Not NULL 
)
go


ALTER TABLE Records
	ADD CONSTRAINT  XPKRecords PRIMARY KEY   NONCLUSTERED (ID_Record  ASC)
go



ALTER TABLE Books
	ADD CONSTRAINT  R_3 FOREIGN KEY (ID_Record) REFERENCES Records(ID_Record)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Movies
	ADD CONSTRAINT  R_2 FOREIGN KEY (ID_Record) REFERENCES Records(ID_Record)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Music
	ADD CONSTRAINT  R_4 FOREIGN KEY (ID_Record) REFERENCES Records(ID_Record)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Records
	ADD CONSTRAINT  R_1 FOREIGN KEY (UploadBy) REFERENCES Logins(ID_Login)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



/*CREATE TRIGGER tD_Books ON Books FOR DELETE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* DELETE trigger on Books */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Records R/3 Books on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00012f93", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Books"
    P2C_VERB_PHRASE="R/3", C2P_VERB_PHRASE="R/3", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="ID_Record" */
    IF EXISTS (SELECT * FROM deleted,Records
      WHERE
        /* %JoinFKPK(deleted,Records," = "," AND") */
        deleted.ID_Record = Records.ID_Record AND
        NOT EXISTS (
          SELECT * FROM Books
          WHERE
            /* %JoinFKPK(Books,Records," = "," AND") */
            Books.ID_Record = Records.ID_Record
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Books because Records exists.'
      GOTO ERROR
    END


    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
*/
go

CREATE TRIGGER tU_Books ON Books FOR UPDATE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* UPDATE trigger on Books */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insID_Record int,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Records R/3 Books on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00014e36", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Books"
    P2C_VERB_PHRASE="R/3", C2P_VERB_PHRASE="R/3", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="ID_Record" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(ID_Record)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Records
        WHERE
          /* %JoinFKPK(inserted,Records) */
          inserted.ID_Record = Records.ID_Record
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Books because Records does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go


CREATE TRIGGER tD_Logins ON Logins FOR DELETE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* DELETE trigger on Logins */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Logins R/1 Records on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="0000fa70", PARENT_OWNER="", PARENT_TABLE="Logins"
    CHILD_OWNER="", CHILD_TABLE="Records"
    P2C_VERB_PHRASE="R/1", C2P_VERB_PHRASE="R/1", 
    FK_CONSTRAINT="R_1", FK_COLUMNS="UploadBy" */
    IF EXISTS (
      SELECT * FROM deleted,Records
      WHERE
        /*  %JoinFKPK(Records,deleted," = "," AND") */
        Records.UploadBy = deleted.ID_Login
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Logins because Records exists.'
      GOTO ERROR
    END


    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go

CREATE TRIGGER tU_Logins ON Logins FOR UPDATE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* UPDATE trigger on Logins */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insID_Login int,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Logins R/1 Records on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00011553", PARENT_OWNER="", PARENT_TABLE="Logins"
    CHILD_OWNER="", CHILD_TABLE="Records"
    P2C_VERB_PHRASE="R/1", C2P_VERB_PHRASE="R/1", 
    FK_CONSTRAINT="R_1", FK_COLUMNS="UploadBy" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(ID_Login)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Records
      WHERE
        /*  %JoinFKPK(Records,deleted," = "," AND") */
        Records.UploadBy = deleted.ID_Login
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Logins because Records exists.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go


/*CREATE TRIGGER tD_Movies ON Movies FOR DELETE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* DELETE trigger on Movies */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Records R/2 Movies on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00012d8d", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Movies"
    P2C_VERB_PHRASE="R/2", C2P_VERB_PHRASE="R/2", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="ID_Record" */
    IF EXISTS (SELECT * FROM deleted,Records
      WHERE
        /* %JoinFKPK(deleted,Records," = "," AND") */
        deleted.ID_Record = Records.ID_Record AND
        NOT EXISTS (
          SELECT * FROM Movies
          WHERE
            /* %JoinFKPK(Movies,Records," = "," AND") */
            Movies.ID_Record = Records.ID_Record
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Movies because Records exists.'
      GOTO ERROR
    END


    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
*/
go



CREATE TRIGGER tU_Movies ON Movies FOR UPDATE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* UPDATE trigger on Movies */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insID_Record int,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Records R/2 Movies on child update no action */
  /* ERWIN_RELATION:CHECKSUM="000151af", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Movies"
    P2C_VERB_PHRASE="R/2", C2P_VERB_PHRASE="R/2", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="ID_Record" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(ID_Record)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Records
        WHERE
          /* %JoinFKPK(inserted,Records) */
          inserted.ID_Record = Records.ID_Record
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Movies because Records does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go


/*CREATE TRIGGER tD_Music ON Music FOR DELETE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* DELETE trigger on Music */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Records R/4 Music on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00012380", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Music"
    P2C_VERB_PHRASE="R/4", C2P_VERB_PHRASE="R/4", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="ID_Record" */
    IF EXISTS (SELECT * FROM deleted,Records
      WHERE
        /* %JoinFKPK(deleted,Records," = "," AND") */
        deleted.ID_Record = Records.ID_Record AND
        NOT EXISTS (
          SELECT * FROM Music
          WHERE
            /* %JoinFKPK(Music,Records," = "," AND") */
            Music.ID_Record = Records.ID_Record
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Music because Records exists.'
      GOTO ERROR
    END


    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
*/
go


CREATE TRIGGER tU_Music ON Music FOR UPDATE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* UPDATE trigger on Music */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insID_Record int,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Records R/4 Music on child update no action */
  /* ERWIN_RELATION:CHECKSUM="000146f6", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Music"
    P2C_VERB_PHRASE="R/4", C2P_VERB_PHRASE="R/4", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="ID_Record" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(ID_Record)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Records
        WHERE
          /* %JoinFKPK(inserted,Records) */
          inserted.ID_Record = Records.ID_Record
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Music because Records does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go


CREATE TRIGGER tD_Records ON Records FOR DELETE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* DELETE trigger on Records */
BEGIN
  DECLARE  @errno   int,
           @errmsg  varchar(255)
    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Records R/2 Movies on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="000402dd", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Movies"
    P2C_VERB_PHRASE="R/2", C2P_VERB_PHRASE="R/2", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="ID_Record" */
    IF EXISTS (
      SELECT * FROM deleted,Movies
      WHERE
        /*  %JoinFKPK(Movies,deleted," = "," AND") */
        Movies.ID_Record = deleted.ID_Record
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Records because Movies exists.'
      GOTO ERROR
    END

    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Records R/3 Books on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Books"
    P2C_VERB_PHRASE="R/3", C2P_VERB_PHRASE="R/3", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="ID_Record" */
    IF EXISTS (
      SELECT * FROM deleted,Books
      WHERE
        /*  %JoinFKPK(Books,deleted," = "," AND") */
        Books.ID_Record = deleted.ID_Record
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Records because Books exists.'
      GOTO ERROR
    END

    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Records R/4 Music on parent delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Music"
    P2C_VERB_PHRASE="R/4", C2P_VERB_PHRASE="R/4", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="ID_Record" */
    IF EXISTS (
      SELECT * FROM deleted,Music
      WHERE
        /*  %JoinFKPK(Music,deleted," = "," AND") */
        Music.ID_Record = deleted.ID_Record
    )
    BEGIN
      SELECT @errno  = 30001,
             @errmsg = 'Cannot delete Records because Music exists.'
      GOTO ERROR
    END
    /*
    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    /* Logins R/1 Records on child delete no action */
    /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Logins"
    CHILD_OWNER="", CHILD_TABLE="Records"
    P2C_VERB_PHRASE="R/1", C2P_VERB_PHRASE="R/1", 
    FK_CONSTRAINT="R_1", FK_COLUMNS="UploadBy" */
    IF EXISTS (SELECT * FROM deleted,Logins
      WHERE
        /* %JoinFKPK(deleted,Logins," = "," AND") */
        deleted.UploadBy = Logins.ID_Login AND
        NOT EXISTS (
          SELECT * FROM Records
          WHERE
            /* %JoinFKPK(Records,Logins," = "," AND") */
            Records.UploadBy = Logins.ID_Login
        )
    )
    BEGIN
      SELECT @errno  = 30010,
             @errmsg = 'Cannot delete last Records because Logins exists.'
      GOTO ERROR
    END
    */


    /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
    RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go

CREATE TRIGGER tU_Records ON Records FOR UPDATE AS
/* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
/* UPDATE trigger on Records */
BEGIN
  DECLARE  @NUMROWS int,
           @nullcnt int,
           @validcnt int,
           @insID_Record int,
           @errno   int,
           @errmsg  varchar(255)

  SELECT @NUMROWS = @@rowcount
  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Records R/2 Movies on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00047925", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Movies"
    P2C_VERB_PHRASE="R/2", C2P_VERB_PHRASE="R/2", 
    FK_CONSTRAINT="R_2", FK_COLUMNS="ID_Record" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(ID_Record)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Movies
      WHERE
        /*  %JoinFKPK(Movies,deleted," = "," AND") */
        Movies.ID_Record = deleted.ID_Record
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Records because Movies exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Records R/3 Books on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Books"
    P2C_VERB_PHRASE="R/3", C2P_VERB_PHRASE="R/3", 
    FK_CONSTRAINT="R_3", FK_COLUMNS="ID_Record" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(ID_Record)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Books
      WHERE
        /*  %JoinFKPK(Books,deleted," = "," AND") */
        Books.ID_Record = deleted.ID_Record
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Records because Books exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Records R/4 Music on parent update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Records"
    CHILD_OWNER="", CHILD_TABLE="Music"
    P2C_VERB_PHRASE="R/4", C2P_VERB_PHRASE="R/4", 
    FK_CONSTRAINT="R_4", FK_COLUMNS="ID_Record" */
  IF
    /* %ParentPK(" OR",UPDATE) */
    UPDATE(ID_Record)
  BEGIN
    IF EXISTS (
      SELECT * FROM deleted,Music
      WHERE
        /*  %JoinFKPK(Music,deleted," = "," AND") */
        Music.ID_Record = deleted.ID_Record
    )
    BEGIN
      SELECT @errno  = 30005,
             @errmsg = 'Cannot update Records because Music exists.'
      GOTO ERROR
    END
  END

  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  /* Logins R/1 Records on child update no action */
  /* ERWIN_RELATION:CHECKSUM="00000000", PARENT_OWNER="", PARENT_TABLE="Logins"
    CHILD_OWNER="", CHILD_TABLE="Records"
    P2C_VERB_PHRASE="R/1", C2P_VERB_PHRASE="R/1", 
    FK_CONSTRAINT="R_1", FK_COLUMNS="UploadBy" */
  IF
    /* %ChildFK(" OR",UPDATE) */
    UPDATE(UploadBy)
  BEGIN
    SELECT @nullcnt = 0
    SELECT @validcnt = count(*)
      FROM inserted,Logins
        WHERE
          /* %JoinFKPK(inserted,Logins) */
          inserted.UploadBy = Logins.ID_Login
    /* %NotnullFK(inserted," IS NULL","select @nullcnt = count(*) from inserted where"," AND") */
    select @nullcnt = count(*) from inserted where
      inserted.UploadBy IS NULL
    IF @validcnt + @nullcnt != @NUMROWS
    BEGIN
      SELECT @errno  = 30007,
             @errmsg = 'Cannot update Records because Logins does not exist.'
      GOTO ERROR
    END
  END


  /* ERwin Builtin 5 декабря 2012 г. 23:33:46 */
  RETURN
ERROR:
    raiserror @errno @errmsg
    rollback transaction
END
go

