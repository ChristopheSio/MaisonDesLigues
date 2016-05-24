/*
  Création d'une procédure privée qui va permetre d'insérer une ligne dans la table participant
  Cette procédure est appelée par les procédures :
  -nouveaubenevole,
  -nouveaulicencié,
  -nouveauintervenant
  - le paramètre newid est un paramètre out pour renvoyer à la procédure appelante 
  l'id du participant créé. (à compléter)
*/
use PPE_M2L 
go
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

