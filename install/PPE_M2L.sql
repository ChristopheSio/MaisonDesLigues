/*
 ----------------------------------------------------------------------------
             Génération d'une base de données pour
                      Microsoft SQL Server
                       (11/2/2016 13:22:18)
 ----------------------------------------------------------------------------
     Nom de la base : PPE_M2L
     Projet : Maison des Ligues - Février 2016
     Auteur : Lycée Marie  Curie
     
 ----------------------------------------------------------------------------
*/

/* -----------------------------------------------------------------------------
      SUPRESSION DE LA BASE PPE_M2L SI EXISTANTE
----------------------------------------------------------------------------- */
USE master  -- change database for disconnect PPE_M2L
IF EXISTS(
	SELECT name FROM sys.databases
	WHERE name = 'PPE_M2L'
)
DROP DATABASE PPE_M2L
go
/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE PPE_M2L
----------------------------------------------------------------------------- */
create database PPE_M2L
go
use PPE_M2L
go
/* -----------------------------------------------------------------------------
      TABLE : PAIEMENT
----------------------------------------------------------------------------- */
create table PAIEMENT
(
     ID int IDENTITY(1,1) not null,
     IDPARTICIPANT int not null,
     MONTANTCHEQUE float ,
     NUMEROCHEQUE varchar(15) ,
     TYPEPAIEMENT varchar(30) 
)
go

/*      INDEX DE PAIEMENT      */
ALTER TABLE PAIEMENT ADD CONSTRAINT PK_PAIEMENT PRIMARY KEY(ID)
go
/* -----------------------------------------------------------------------------
      TABLE : STATUT
----------------------------------------------------------------------------- */
create table STATUT
(
      ID varchar(3)  not null,
     LIBELLE varchar(15)
    
)
go

/*      INDEX DE PAIEMENT      */
ALTER TABLE STATUT ADD CONSTRAINT PK_STATUT PRIMARY KEY(ID)
go

insert into STATUT(id, libelle) values('ANI', 'Animateur');
insert into STATUT(id, libelle) values('INT', 'Intervenant');
go
/* -----------------------------------------------------------------------------
      TABLE : PARTICIPANT
----------------------------------------------------------------------------- */
create table PARTICIPANT
(
     ID int IDENTITY(1,1) not null,
     NOM varchar(50) not null,
     PRENOM varchar(50)not null ,
     ADRESSE1 varchar(50) ,
     ADRESSE2 varchar(50) ,
     CP varchar(5) ,
     VILLE varchar(50) ,
	 TEL varchar(15),
     MAIL varchar(50) ,
     DATEINSCRIPTION date ,
     DATEARRIVEE date ,
     CLEWIFI varchar(50),
	 TYPEPARTICIPANT varchar(1),
	 NUMEROLICENCE varchar(32),
	 DATENAISSANCEBENEVOLE date,
	 IDATELIERINTERVENANT int,
	 IDQUALITELICENCIE int,
	 IDSTATUT varchar(3)
)
go
/*      INDEX DE PARTICIPANT      */
ALTER TABLE PARTICIPANT ADD CONSTRAINT PK_PARTICIPANT PRIMARY KEY(ID)
go
/* -----------------------------------------------------------------------------
      TABLE : DATENUITEE
----------------------------------------------------------------------------- */
create table DATENUITEE
(
     ID int IDENTITY(1,1) not null,
     DATEARRIVEENUITEE date 
)
go
/*      INDEX DE DATENUITEE      */
ALTER TABLE DATENUITEE ADD CONSTRAINT PK_DATENUITEE PRIMARY KEY(ID)
go
insert into DATENUITEE (DATEARRIVEENUITEE) values ('2015-09-12');
insert into DATENUITEE (DATEARRIVEENUITEE) values ('2015-09-12');
/* -----------------------------------------------------------------------------
      TABLE : ATELIER
----------------------------------------------------------------------------- */
create table ATELIER
(
     ID int IDENTITY(1,1) not null,
     IDPARTICIPANT int null,
     LIBELLEATELIER varchar(50) null ,
     NBPLACESMAXI int null
)
go
/*      INDEX DE ATELIER      */
ALTER TABLE ATELIER ADD CONSTRAINT PK_ATELIER  PRIMARY KEY(ID)
go
insert into atelier (LIBELLEATELIER, NBPLACESMAXI) values ('Le club et son projet', 20);
insert into atelier (LIBELLEATELIER, NBPLACESMAXI) values ('Le fonctionnement du club', 20);
insert into atelier (LIBELLEATELIER, NBPLACESMAXI) values ('Les outils à disposition et remis aux clubs', 20);
insert into atelier (LIBELLEATELIER, NBPLACESMAXI) values ('Observatoire des métiers de l"escrime', 20);
insert into atelier (LIBELLEATELIER, NBPLACESMAXI) values ('I.F.F.E', 25);
insert into atelier (LIBELLEATELIER, NBPLACESMAXI) values ('Déceloppement durable', 35);

/* -----------------------------------------------------------------------------
      TABLE : DETAILHEBERGEMENT
---------------------------------------------------------------------------- */
create table DETAILHEBERGEMENT
(
     IDPARTICIPANT int not null,
     NUMORDRE int not null,
     CODEHOTEL int not null,
     IDCATEGORIE int not null,
     IDDATENUITEE int not null
)
go
/*      INDEX DE DETAILHEBERGEMENT      */
ALTER TABLE DETAILHEBERGEMENT ADD CONSTRAINT PK_DETAILHEBERGEMENT  PRIMARY KEY(IDPARTICIPANT, NUMORDRE)
go
/* -----------------------------------------------------------------------------
      TABLE : DATEBENEVOLAT
----------------------------------------------------------------------------- */
create table DATEBENEVOLAT
(
     ID int IDENTITY(1,1) not null,
     DATEBENEVOLAT date 
)
go
/*      INDEX DE DATEBENEVOLAT      */
ALTER TABLE DATEBENEVOLAT ADD CONSTRAINT PK_DATEBENEVOLAT  PRIMARY KEY(ID)
go
insert into DATEBENEVOLAT (DATEBENEVOLAT) values ('2015-09-13');
insert into DATEBENEVOLAT (DATEBENEVOLAT) values ('2015-09-14');
/* -----------------------------------------------------------------------------
      TABLE : HOTEL
----------------------------------------------------------------------------- */
create table HOTEL
(
     CODEHOTEL int IDENTITY(1,1) not null,
     NOMHOTEL varchar(50) ,
     ADRESSE1HOTEL varchar(50) ,
     ADRESSE2HOTEL varchar(50) ,
     CPHOTEL varchar(5) ,
     VILLEHOTEL varchar(50) ,
     TELHOTEL varchar(10) ,
     MAILHOTEL varchar(100) 
)
go
/*      INDEX DE HOTEL      */
ALTER TABLE HOTEL ADD CONSTRAINT PK_HOTEL  PRIMARY KEY(CODEHOTEL)
go
insert into HOTEL (NOMHOTEL, ADRESSE1HOTEL, ADRESSE2HOTEL, CPHOTEL, VILLEHOTEL, MAILHOTEL ) values ('IBIS', '29, avenue Charles Venant', 'Le Forum', '59000', 'LILLE','H0901@ACCOR.COM' );
insert into HOTEL (NOMHOTEL, ADRESSE1HOTEL, ADRESSE2HOTEL, CPHOTEL, VILLEHOTEL, MAILHOTEL ) values ('NOVOTEL', '116 rue de l"Hopital Militaire', '', '59000', 'LILLE','H0918@ACCOR.COM' );
/* -----------------------------------------------------------------------------
      TABLE : RESTAURATION
---------------------------------------------------------------------------- */
create table RESTAURATION
(
     IDRESTAURATION int IDENTITY(1,1) not null,
     DATERESTAURATION date ,
     TYPEREPAS varchar(10) 
)
go
/*      INDEX DE RESTAURATION      */
ALTER TABLE RESTAURATION ADD CONSTRAINT PK_RESTAURATION  PRIMARY KEY(IDRESTAURATION)
/* -----------------------------------------------------------------------------
      TABLE : CATEGORIECHAMBRE
----------------------------------------------------------------------------- */
create table CATEGORIECHAMBRE
(
     ID int IDENTITY(1,1) not null,
     LIBELLECATEGORIE varchar(50) 
)
go
/*      INDEX DE CATEGORIECHAMBRE      */
ALTER TABLE CATEGORIECHAMBRE ADD CONSTRAINT PK_CATEGORIECHAMBRE  PRIMARY KEY(ID)
go
insert into CATEGORIECHAMBRE (LIBELLECATEGORIE) values ('Simple');
insert into CATEGORIECHAMBRE (LIBELLECATEGORIE) values ('Double');

/* -----------------------------------------------------------------------------
      TABLE : HOTELCHAMBREPRIX
----------------------------------------------------------------------------- */
CREATE TABLE HOTELCHAMBREPRIX (
    CODEHOTEL int NOT NULL,
    IDCATEGORIECHAMBRE int NOT NULL,
    PRIX float NOT NULL
)
/*      INDEX DE HOTELCHAMBREPRIX      */
ALTER TABLE HOTELCHAMBREPRIX ADD CONSTRAINT PK_HOTELCHAMBREPRIX  PRIMARY KEY(CODEHOTEL,IDCATEGORIECHAMBRE)
go
INSERT HOTELCHAMBREPRIX (CODEHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (1, 1, 61.2);
INSERT HOTELCHAMBREPRIX (CODEHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (1, 2, 62.2);
INSERT HOTELCHAMBREPRIX (CODEHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (2, 1, 112);
INSERT HOTELCHAMBREPRIX (CODEHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (2, 2, 122);

/* -----------------------------------------------------------------------------
      TABLE : VACATION
----------------------------------------------------------------------------- */
create table VACATION
(
     IDATELIER int not null,
     IDVACATION int not null,
     DATEHEUREDEBUT datetime ,
     DATEHEUREFIN datetime 
)
go
/*      INDEX DE VACATION      */
ALTER TABLE VACATION ADD CONSTRAINT PK_VACATION  PRIMARY KEY(IDATELIER ,IDVACATION)
go
INSERT INTO VACATION VALUES (1,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (1,2,cast('20150913 14:00' as datetime),cast('20150913 15:30'as datetime));
INSERT INTO VACATION VALUES (1,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (1,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (1,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (2,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (2,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (2,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (2,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (2,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (3,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (3,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (3,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (3,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (3,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (4,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (4,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (4,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (4,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (4,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (5,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (5,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (5,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (5,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (5,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
INSERT INTO VACATION VALUES (6,1,cast('20150913 11:00' as datetime),cast('20150913 12:30' as datetime));
INSERT INTO VACATION VALUES (6,2,cast('20150913 14:00' as datetime),cast('20150913 15:30' as datetime));
INSERT INTO VACATION VALUES (6,3,cast('20150913 16:00' as datetime),cast('20150913 17:30' as datetime));
INSERT INTO VACATION VALUES (6,4,cast('20150914 09:00' as datetime),cast('20150914 10:30' as datetime));
INSERT INTO VACATION VALUES (6,5,cast('20150914 11:00' as datetime),cast('20150914 12:30' as datetime));
/* -----------------------------------------------------------------------------
      TABLE : QUALITE
----------------------------------------------------------------------------- */
create table QUALITE
(
     ID int IDENTITY(1,1) not null,
     LIBELLEQUALITE varchar(50) 
)
go
/*      INDEX DE QUALITE      */
ALTER TABLE QUALITE ADD CONSTRAINT PK_QUALITE  PRIMARY KEY(ID)
go
insert into qualite (libellequalite) values ('Licencié(e)');
insert into qualite (libellequalite) values ('Président(e)');
insert into qualite (libellequalite) values ('Vice Président(e)');
insert into qualite (libellequalite) values ('Trésorier(e) de la Ligue');
insert into qualite (libellequalite) values ('Trésorier(e) du club');
insert into qualite (libellequalite) values ('Trésorier(e) du comité départemental');
insert into qualite (libellequalite) values ('Secrétaire');
/* -----------------------------------------------------------------------------
      TABLE : THEME
----------------------------------------------------------------------------- */
create table THEME
(
     IDATELIER int not null,
     IDTHEME int not null,
     LIBELLETHEME varchar(50) 
)
go
/*      INDEX DE THEME      */
ALTER TABLE THEME ADD CONSTRAINT PK_THEME  PRIMARY KEY(IDATELIER, IDTHEME)
go
INSERT INTO THEME VALUES (1,1,'Diagnostic et identification des critères du club');
INSERT INTO THEME VALUES (1,2,'Analyse systèmique de l"environement');
INSERT INTO THEME VALUES (1,3,'Actions solidaires et innovantes');
INSERT INTO THEME VALUES (1,4,'Financements');
INSERT INTO THEME VALUES (1,5,'Outils et documentation');
INSERT INTO THEME VALUES (1,6,'Valoriser et communiquer sur le projet');
INSERT INTO THEME VALUES (2,1,'Création Obligations Légales');
INSERT INTO THEME VALUES (2,2,'Gestion du Personnel');
INSERT INTO THEME VALUES (2,3,'Relations Internes, Externes et avec le comite');
INSERT INTO THEME VALUES (2,4,'Conventions');
INSERT INTO THEME VALUES (2,5,'Partenariats');
INSERT INTO THEME VALUES (3,1,'Logiciel FFE Gestion des compétitions');
INSERT INTO THEME VALUES (3,2,'Presentation du document "abitrage en image"');
INSERT INTO THEME VALUES (3,3,'Plaquette "Guide Projet du Club"');
INSERT INTO THEME VALUES (3,4,'Labellisation du club');
INSERT INTO THEME VALUES (3,5,'Amenagement des équipements');
INSERT INTO THEME VALUES (3,6,'Assurances');
INSERT INTO THEME VALUES (4,1,'Observations et Analyse sur l"encadement actuel');
INSERT INTO THEME VALUES (4,2,'Proposition de nouveaux schéma d"organisation');
INSERT INTO THEME VALUES (4,3,'Profils type et pratiques innovantes');
INSERT INTO THEME VALUES (4,4,'Critère et seuil nécessaire à la perennité emploi');
INSERT INTO THEME VALUES (4,5,'Exercice du métier d"enseignant');
INSERT INTO THEME VALUES (5,1,'Presentation');
INSERT INTO THEME VALUES (5,2,'Fonctionnement');
INSERT INTO THEME VALUES (5,3,'Objectifs');
INSERT INTO THEME VALUES (5,4,'Nouveaux Diplomés');
INSERT INTO THEME VALUES (5,5,'Financements');
INSERT INTO THEME VALUES (6,1,'Les enjeux climatiques, energetiques, economiques');
INSERT INTO THEME VALUES (6,2,'Sport et developpement durable');
INSERT INTO THEME VALUES (6,3,'Démarche Fédérale');
INSERT INTO THEME VALUES (6,4,'Echange');
/* -----------------------------------------------------------------------------
      TABLE : PARAMETRES
----------------------------------------------------------------------------- */
create table PARAMETRES
(
     NOMDDL varchar(32) ,
     ADRRUE1 varchar(50) ,
     ADRRUE2 varchar(50) ,
     CP varchar(5) ,
     VILLE varchar(50) ,
     TEL varchar(10) ,
     FAX varchar(10) ,
     MAIL varchar(100) ,
     TARIFINSCRIPTION float ,
     TARIFREPASACCOMPAGNANT float ,
     NUMERO int not null
)
go
/*      INDEX DE PARAMETRES      */
ALTER TABLE PARAMETRES ADD CONSTRAINT PK_PARAMETRES  PRIMARY KEY(NUMERO)
go
INSERT INTO PARAMETRES  VALUES ('Maison Régionale des Sports','13 rue jean moulin','BP 70001','54510','Tromblaine','0383188702','','escrime@lorraine-sport.com',100,35,1);
/* -----------------------------------------------------------------------------
      TABLE : INSCRIRE
----------------------------------------------------------------------------- */
create table INSCRIRE
(
     IDATELIER int not null,
     IDPARTICIPANT int not null
)
go
/*      INDEX DE INSCRIRE      */
ALTER TABLE INSCRIRE ADD CONSTRAINT PK_INSCRIRE  PRIMARY KEY(IDATELIER, IDPARTICIPANT)
go
/* -----------------------------------------------------------------------------
      TABLE : PARTICIPER
----------------------------------------------------------------------------- */
create table PARTICIPER
(
     IDATELIER int not null,
     IDVACATION int not null,
     IDPARTICIPANT int not null
)
go
/*      INDEX DE PARTICIPER      */
ALTER TABLE PARTICIPER ADD CONSTRAINT PK_PARTICIPER  PRIMARY KEY(IDATELIER, IDVACATION, IDPARTICIPANT)
go
/* -----------------------------------------------------------------------------
      TABLE : PROPOSER
----------------------------------------------------------------------------- */
create table PROPOSER
(
     CODEHOTEL int not null,
     IDCATEGORIE int not null,
     TARIFNUITEE float 
)
go
/*      INDEX DE PROPOSER      */
ALTER TABLE PROPOSER ADD CONSTRAINT PK_PROPOSER  PRIMARY KEY(CODEHOTEL, IDCATEGORIE)
go
/* -----------------------------------------------------------------------------
      TABLE : ETREPRESENT
----------------------------------------------------------------------------- */
create table ETREPRESENT
(
     IDPARTICIPANT int not null,
     IDDATEBENEVOLAT int not null
)
go
/*      INDEX DE ETREPRESENT      */
ALTER TABLE ETREPRESENT ADD CONSTRAINT PK_ETREPRESENT  PRIMARY KEY(IDPARTICIPANT, IDDATEBENEVOLAT)
go
/* -----------------------------------------------------------------------------
      TABLE : INCLUREACCOMPAGNANT
----------------------------------------------------------------------------- */
create table INCLUREACCOMPAGNANT
(
     IDPARTICIPANT int not null,
     IDRESTAURATION int not null
)
go
/*      INDEX DE INCLUREACCOMPAGNANT      */
ALTER TABLE INCLUREACCOMPAGNANT ADD CONSTRAINT PK_INCLUREACCOMPAGNANT  PRIMARY KEY(IDPARTICIPANT, IDRESTAURATION)
go
/* -----------------------------------------------------------------------------
      REFRENCES SUR LES TABLES
----------------------------------------------------------------------------- */
ALTER TABLE PAIEMENT ADD CONSTRAINT FK_PAIEMENT_1 FOREIGN KEY (IDPARTICIPANT) REFERENCES PARTICIPANT (ID)
go
ALTER TABLE HOTELCHAMBREPRIX ADD CONSTRAINT FK_HOTELCHAMBREPRIX_1 FOREIGN KEY (CODEHOTEL)  REFERENCES HOTEL(CODEHOTEL)
go
ALTER TABLE HOTELCHAMBREPRIX ADD CONSTRAINT FK_HOTELCHAMBREPRIX_2 FOREIGN KEY (IDCATEGORIECHAMBRE)  REFERENCES CATEGORIECHAMBRE(ID)
go
ALTER TABLE ATELIER ADD CONSTRAINT FK_ATELIER_1 FOREIGN KEY (IDPARTICIPANT)  REFERENCES PARTICIPANT (ID)
go
ALTER TABLE DETAILHEBERGEMENT ADD CONSTRAINT FK_DETAILHEBERGEMENT_1 FOREIGN KEY (CODEHOTEL)  REFERENCES  HOTEL (CODEHOTEL)
go
ALTER TABLE DETAILHEBERGEMENT ADD CONSTRAINT FK_DETAILHEBERGEMENT_2 FOREIGN KEY (IDCATEGORIE)  REFERENCES CATEGORIECHAMBRE(ID)
go
ALTER TABLE DETAILHEBERGEMENT ADD CONSTRAINT FK_DETAILHEBERGEMENT_3 FOREIGN KEY (IDDATENUITEE)  REFERENCES DATENUITEE(ID)
go
ALTER TABLE DETAILHEBERGEMENT ADD CONSTRAINT FK_DETAILHEBERGEMENT_4 FOREIGN KEY (IDPARTICIPANT)  REFERENCES PARTICIPANT(ID)
go
ALTER TABLE PARTICIPANT ADD CONSTRAINT FK_PARTICIPANT_1 FOREIGN KEY (IDATELIERINTERVENANT)  REFERENCES ATELIER(ID)
go
ALTER TABLE PARTICIPANT ADD CONSTRAINT FK_PARTICIPANT_2 FOREIGN KEY (IDQUALITELICENCIE)  REFERENCES QUALITE(ID)
go
ALTER TABLE PARTICIPANT ADD CONSTRAINT FK_STATUT_1 FOREIGN KEY (IDSTATUT)  REFERENCES STATUT(ID)
go
ALTER TABLE VACATION ADD CONSTRAINT FK_VACATION_1 FOREIGN KEY (IDATELIER)  REFERENCES ATELIER(ID)
go
ALTER TABLE THEME ADD CONSTRAINT FK_THEME_1 FOREIGN KEY (IDATELIER)  REFERENCES ATELIER(ID)
go
ALTER TABLE INSCRIRE ADD CONSTRAINT FK_INSCRIRE_1 FOREIGN KEY (IDATELIER)  REFERENCES ATELIER (ID)
go
ALTER TABLE INSCRIRE ADD CONSTRAINT FK_INSCRIRE_2 FOREIGN KEY (IDPARTICIPANT)  REFERENCES PARTICIPANT(ID)
go
ALTER TABLE PARTICIPER ADD CONSTRAINT FK_PARTICIPER_1 FOREIGN KEY (IDATELIER, IDVACATION)  REFERENCES VACATION (IDATELIER, IDVACATION)
go
ALTER TABLE PARTICIPER ADD CONSTRAINT FK_PARTICIPER_2 FOREIGN KEY (IDATELIER, IDPARTICIPANT)  REFERENCES INSCRIRE (IDATELIER, IDPARTICIPANT)
go
ALTER TABLE PROPOSER ADD CONSTRAINT FK_PROPOSER_1 FOREIGN KEY (CODEHOTEL)  REFERENCES HOTEL (CODEHOTEL)
go
ALTER TABLE PROPOSER ADD CONSTRAINT FK_PROPOSER_2 FOREIGN KEY (IDCATEGORIE)  REFERENCES CATEGORIECHAMBRE (ID)
go
ALTER TABLE ETREPRESENT ADD CONSTRAINT FK_ETREPRESENT_1 FOREIGN KEY (IDPARTICIPANT)  REFERENCES PARTICIPANT (ID)
go
ALTER TABLE ETREPRESENT ADD CONSTRAINT FK_ETREPRESENT_2 FOREIGN KEY (IDDATEBENEVOLAT)  REFERENCES DATEBENEVOLAT(ID)
go
ALTER TABLE INCLUREACCOMPAGNANT ADD CONSTRAINT FK_INCLUREACCOMPAGNANT_1 FOREIGN KEY (IDPARTICIPANT)  REFERENCES PARTICIPANT(ID)
go
ALTER TABLE INCLUREACCOMPAGNANT ADD CONSTRAINT FK_INCLUREACCOMPAGNANT_2 FOREIGN KEY (IDRESTAURATION)  REFERENCES RESTAURATION(IDRESTAURATION)
go
/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/
/****** Création de la procédure stockée GetMaxNumOrdre    Script Date: 8/03/2015 10:02:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaxNumOrdre]
   @idparticipant INT,
   @nummax INT OUTPUT
AS
BEGIN
   SELECT @nummax = MAX(NUMORDRE)
   FROM DETAILHEBERGEMENT
   WHERE IDPARTICIPANT = @idparticipant
END

go
-- -----------------------------------------------------------------------------
--                LES VUES
-- -----------------------------------------------------------------------------
-- Cette vue vqualite01 va permettre d'avoir un résultat trié dans les combobox
create view VQUALITE01 as
select ID, LIBELLEQUALITE as LIBELLE
from qualite
go

--
-- Cette vue VATELIER01 va permettre de remplir la combo Atelier pour l'intervenant
create view VATELIER01 as
select ID , LIBELLEATELIER as LIBELLE
from atelier;
go
create view VATELIER02 as
select ID, LIBELLEATELIER,  rank() over (ORDER BY ID) as NUMORDRE from atelier;
go
--
---- Cette vue VDATENUITEE01 va permettre de choisir les dates où un participant peut arriver à l'hotel
--create view VDATENUITEE01 as
--select id, to_char(DATEARRIVEENUITEE, 'Day dd Month YYYY','NLS_DATE_LANGUAGE = FRENCH')as libelle
--from DATENUITEE;
--go
-- Cette vue VDATENUITEE02 est une alternative à VDATENUITEE01 elle va renvoyer la date au format date
create view VDATENUITEE02 as
select ID, DATEARRIVEENUITEE
from DATENUITEE;
go
--
-- Cette vue VHOTEL01 va permettre de remplir la combobox du choix d'hotel du composant nuité

create view VHOTEL01 as
select CODEHOTEL as ID, NOMHOTEL as LIBELLE
from HOTEL;
go
--
-- Cette vue VCATEGORIECHAMBRE01 va permettre de remplir la combobox du choix de la catégorie de la chambre du composant nuité
create view VCATEGORIECHAMBRE01 as
select ID , LIBELLECATEGORIE as LIBELLE
from CATEGORIECHAMBRE;
go
--
-- Cette vue VDATEBENEVOLAT01 va permettre de choisir les dates où un bénévole est disponible
create view VDATEBENEVOLAT01 as
select ID,DATEBENEVOLAT as LIBELLE
from DATEBENEVOLAT;
go

-- ----------------------------------------------------------------------------------
--                                VUES CUSTOM
-- ----------------------------------------------------------------------------------

--
-- Cette vue VATELIERVACATIONOCCUPES permet de connaître de nombre de place disponible pour une vacation
CREATE VIEW VATELIERVACATIONOCCUPES AS 
SELECT v.IDATELIER, v.IDVACATION, a.NBPLACESMAXI, COUNT(p.IDPARTICIPANT) AS NBPLACESOCCUPES 
FROM  VACATION v
INNER JOIN ATELIER a ON v.IDATELIER = a.ID
LEFT JOIN PARTICIPER p ON p.IDATELIER = v.IDATELIER AND p.IDVACATION = v.IDVACATION
GROUP BY v.IDATELIER, v.IDVACATION, a.NBPLACESMAXI
go

--
-- Cette vue VTARIFINSCRIPTION permet de connaître les info d'inscription
CREATE VIEW VTARIFINSCRIPTION AS 
SELECT TARIFINSCRIPTION, TARIFREPASACCOMPAGNANT
FROM  PARAMETRES
go

-- ----------------------------------------------------------------------------------
--                                PROCEDURE STOCKE
-- ----------------------------------------------------------------------------------
use PPE_M2L 
go

/*
  Création d'une procédure privée qui va permetre d'insérer une ligne dans la table participant
  Cette procédure est appelée par les procédures :
  -nouveaubenevole,
  -nouveaulicencié,
  -nouveauintervenant
  - le paramètre newid est un paramètre out pour renvoyer à la procédure appelante 
  l'id du participant créé. (à compléter)
*/
/* procédure insérant un intervenant et retournant un paramètre @erreur = 1 si erreur à l'insertion, 0 sinon */
create procedure PSnouvelintervenant
  @pNom varchar(50),
  @pPrenom varchar(50),
  @pAdr1 varchar(50),
  @pAdr2 varchar(50),
  @pCp varchar(5),
  @pVille varchar(50),
  @pTel varchar(15),
  @pMail varchar(50),
  @ptype varchar(1),
  @pidatelierintervenant int,
  @pIdStatut varchar(3)
 /* @newId int output*/
  as  
  BEGIN 
  SET NOCOUNT ON     /*  indique à SQL Server de ne pas retourner le nombre de lignes affectées par la requête INSERT*/
        insert into PARTICIPANT(nom, prenom, adresse1, adresse2,cp, ville,tel, mail,typeparticipant, DATEINSCRIPTION,IDATELIERINTERVENANT,IDSTATUT)
        values (@pNom,@pPrenom,@pAdr1,@pAdr2,@pCp,@pVille,@pTel,@pMail,@ptype,GETDATE(),@pidatelierintervenant,@pIdStatut)
        end
/*  SET @newId = @@identity*/
/* il faudra aussi mettre à jour idparticipant avec @newId dans la table Atelier */
GO


-- ----------------------------------------------------------------------------------
--                                Les utilisateurs ( à tester)
-- ----------------------------------------------------------------------------------
/*
  Création d'une procédure privée qui va permetre d'insérer une ligne dans la table participant
  Cette procédure est appelée par les procédures :
  -nouveaubenevole,
  -nouveaulicencié,
  -nouveauintervenant
  - le paramètre newid est un paramètre out pour renvoyer à la procédure appelante 
  l'id du participant créé. (à compléter)
*/

/*
USE master; 
IF EXISTS (SELECT * FROM sys.syslogins WHERE name = N'employemdl1') DROP LOGIN [employemdl1];
CREATE LOGIN employemdl1 WITH PASSWORD = 'employemdl1'; 
USE PPE_M2L;
IF EXISTS (SELECT * FROM sys.syslogins WHERE name = N'employemdl1') DROP LOGIN [employemdl1];
CREATE LOGIN employemdl1 WITH PASSWORD = 'employemdl1'; 
GO
grant execute to employemdl1;
go
*/

-- Creates the login employemdl1 with password 'employemdl1'.


-- Creates a database user for the login created above.




/*
use master;
CREATE LOGIN mdl1 WITH PASSWORD = 'mdl1';
USE PPE_M2L; 
CREATE USER mdl1 FOR LOGIN md1l;
use master;
CREATE LOGIN employemdl1 WITH PASSWORD = 'employemdl1';
USE PPE_M2L; 
CREATE USER employemdl1 FOR LOGIN employemd1l;
use master;
CREATE LOGIN benevolemdl1 WITH PASSWORD = 'benevolemdl1';
USE PPE_M2L; 
CREATE USER benevolemdl1 FOR LOGIN benevolemd1l;
grant execute to employemdl1;
go
grant excecute to benevolemdl1;
go
*/
--create user mdl identified by mdl  ;
---- Droits ... il faudra en rajouter certainement
--GRANT RESOURCE,CONNECT TO MDL;
--grant create view to mdl;

--create user employemdl identified by employemdl 
--grant execute on mdl.pckparticipant to applimdl; -- autorisation d'exécuter toutes les procédures et fonctions publiques du package
--grant select on mdl.VRESTAURATION01  to applimdl;
--grant select on mdl.VQUALITE01  to applimdl;
--grant select on mdl.VDATEBENEVOLAT01  to applimdl;
--grant select on mdl.VDATENUITE01  to applimdl;
--grant select on mdl.VDATENUITE02  to applimdl;
--grant select on mdl.VHOTEL01  to applimdl;
--grant select on mdl.VCATEGORIECHAMBRE01  to applimdl;
--grant select on mdl.VSTATUT01  to applimdl;
--grant select on mdl.VATELIER01  to applimdl;
--grant select on mdl.VATELIER02  to applimdl;
--grant execute on mdl.pckatelier to applimdl;
--grant execute on mdl.fonctionsdiverses to applimdl;

