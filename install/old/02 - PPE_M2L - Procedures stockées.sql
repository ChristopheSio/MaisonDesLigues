/*
  Cr�ation d'une proc�dure priv�e qui va permetre d'ins�rer une ligne dans la table participant
  Cette proc�dure est appel�e par les proc�dures :
  -nouveaubenevole,
  -nouveaulicenci�,
  -nouveauintervenant
  - le param�tre newid est un param�tre out pour renvoyer � la proc�dure appelante 
  l'id du participant cr��. (� compl�ter)
*/
use PPE_M2L 
go
/* proc�dure ins�rant un intervenant et retournant un param�tre @erreur = 1 si erreur � l'insertion, 0 sinon */
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
  SET NOCOUNT ON     /*  indique � SQL Server de ne pas retourner le nombre de lignes affect�es par la requ�te INSERT*/
        insert into PARTICIPANT(nom, prenom, adresse1, adresse2,cp, ville,tel, mail,typeparticipant, DATEINSCRIPTION,IDATELIERINTERVENANT,IDSTATUT)
        values (@pNom,@pPrenom,@pAdr1,@pAdr2,@pCp,@pVille,@pTel,@pMail,@ptype,GETDATE(),@pidatelierintervenant,@pIdStatut)
        end
/*  SET @newId = @@identity*/
/* il faudra aussi mettre � jour idparticipant avec @newId dans la table Atelier */

GO

