using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;  // bibliothèque pour les expressions régulières
using MaisonDesLigues;

using System.Configuration;


namespace MaisonDesLigues
{
    

    static class Modele
    {
        //
        // propriétés membres
        //
        private static SqlConnection DataBaseConnection = null;

        /*private SqlCommand UneSqlCommand;
        private SqlDataAdapter UnSqlDataAdapter;
        private DataTable UneDataTable;
        private SqlTransaction UneSqlTransaction;*/

        //
        // méthodes public static
        //

        /// <summary>permet de se connecter</summary>
        /// <param name="leLogin">login utilisateur</param>
        /// <param name="leMotDePasse">mot de passe utilisateur</param>
        static public void seConnecter(String leLogin, String leMotDePasse)
        {
            // <remarks>on commence par récupérer dans CnString les informations contenues dans le fichier app.config 
            // pour la connectionString de nom StrConnMdl </remarks>
            ConnectionStringSettings ConnectionStr = ConfigurationManager.ConnectionStrings["MaConnection"];
            try {
                ///<remarks>on va remplacer dans la chaine de connexion les paramètres par le login et le pwd saisis dans les zones de texte. Pour ça on va utiliser la méthode Format de la classe String.</remarks>
                String ConnexionStr = string.Format(ConnectionStr.ConnectionString, leLogin, leMotDePasse);
                //DialogResult res = MessageBox.Show("Connexion String :\n\n" + ConnexionStr, "ConnexionStr", MessageBoxButtons.OK);
                //
                DataBaseConnection = new SqlConnection(ConnexionStr);
                DataBaseConnection.Open();
            } catch (SqlException e) {
                throw new Exception("Erreur à la connexion : " + e.Message + "\n\n(info:" + ConnectionStr.ConnectionString + ")");
            }
            
        }

        /// <summary>Méthode permettant de fermer la connexion</summary>
        static public void seDeconecter()
        {
            DataBaseConnection.Close();
        }

        /// <summary>Méthode permettant de savoir ou en est la connexion</summary>
        static public bool estConecter()
        {
            if (DataBaseConnection == null)
                return false;
            else {
                return DataBaseConnection.State != ConnectionState.Closed;
            }
        }

        /// <summary>permet de récupérer le contenu d'une table ou d'une vue.</summary>
        /// <param name="UneTableOuVue"> nom de la table ou la vue dont on veut récupérer le contenu</param>
        /// <returns>un objet de type datatable contenant les données récupérées</returns>
        static public DataTable ObtenirDonnees(String UneTableOuVue)
        {
            SqlCommand command = new SqlCommand("select * from "+UneTableOuVue, DataBaseConnection);
            SqlDataAdapter adaptater = new SqlDataAdapter();
            adaptater.SelectCommand = command;
            DataTable datatable = new DataTable();
            adaptater.Fill(datatable);
            return datatable;
        }


        /// <summary>Procédure publique qui va appeler la procédure stockée permettant d'inscrire un nouvel intervenant</summary>
        /// <remarks> procédure qui va créer : 1- un enregistrement dans la table participant avec typeParticipant à 'I' en cas d'erreurSQL, appel à la méthode GetMessageSql dont le rôle est d'extraire uniquement le message renvoyé par une procédure ou un trigger SQLSERVER</remarks>
        static public void InscrireIntervenant(String pNom, String pPrenom, String pAdresse1, String pAdresse2, String pCp, String pVille, String pTel, String pMail, String pIdAtelier, String pIdStatut, out String outId)
        {
            outId = null; // Default Out
            String MessageErreur = "";
            //
            SqlTransaction transaction = DataBaseConnection.BeginTransaction();
            try {
                SqlCommand command = new SqlCommand("PS_InsererIntervenant", DataBaseConnection);
                command.CommandType = CommandType.StoredProcedure;  // début de la transaction SqlServer il vaut mieux gérer les transactions dans l'applicatif que dans la bd dans les procédures stockées.
                command.Transaction = transaction;       
                // on appelle la procédure ParamCommunsNouveauxParticipants pour charger les paramètres communs aux Participants
                ParamCommunsNouveauxParticipants(command, pNom, pPrenom, pAdresse1, pAdresse2, pCp, pVille, pTel, pMail);
                // on complète les paramètres spécifiques à l'intervenant
                command.Parameters.Add("@ptype", SqlDbType.VarChar).Value = "I";   // "I" pour le type du participant (Intervenant)
                command.Parameters.Add("@pIdAtelierIntervenant", SqlDbType.Int).Value = pIdAtelier;
                command.Parameters.Add("@pIdStatut", SqlDbType.VarChar).Value = pIdStatut;
                command.Parameters.Add("@outId", SqlDbType.Int).Direction = ParameterDirection.Output;
                //execution
                command.ExecuteNonQuery();
                // Recup du nouvelle ID
                outId = command.Parameters["@outId"].Value.ToString();
                // fin de la transaction. Si on arrive à ce point, c'est qu'aucune exception n'a été levée
                transaction.Commit();
            }
            catch (SqlException e) {
                MessageErreur = "Erreur SqlServer \n" + GetMessageSql(e.Message);
            }
            catch (Exception e) {
                MessageErreur = e.Message + "Autre Erreur, les informations n'ont pas été correctement saisies";
            }
            finally {
                if (MessageErreur.Length > 0) {
                    transaction.Rollback();             // annulation de la transaction
                    throw new Exception(MessageErreur); // Déclenchement de l'exception
                }
            }
        }


        /// <summary>Procédure publique qui va appeler la procédure stockée permettant d'inscrire un nouvel intervenant</summary>
        static public void InscrireLicencie(String pNom, String pPrenom, String pAdresse1, String pAdresse2, String pCp, String pVille, String pTel, String pMail, Int16 pIdAtelier, String pIdStatut, out String outId)
        {
            outId = null; // Default Out
            String MessageErreur = "";
            SqlTransaction transaction = DataBaseConnection.BeginTransaction();
            try {
                SqlCommand command = new SqlCommand("PS_InsererLicencie", DataBaseConnection);
                command.CommandType = CommandType.StoredProcedure;  // début de la transaction SqlServer il vaut mieux gérer les transactions dans l'applicatif que dans la bd dans les procédures stockées.
                command.Transaction = transaction;
                //
                ParamCommunsNouveauxParticipants(command, pNom, pPrenom, pAdresse1, pAdresse2, pCp, pVille, pTel, pMail); // params commun aux participant
                command.Parameters.Add("@pType", SqlDbType.VarChar).Value = "I";   // "I" pour Intervenant
                command.Parameters.Add("@pIdAtelierIntervenant", SqlDbType.Int).Value = pIdAtelier;
                command.Parameters.Add("@pIdStatut", SqlDbType.VarChar).Value = pIdStatut;
                command.Parameters.Add("@outId", SqlDbType.Int).Direction = ParameterDirection.Output;
                //
                command.ExecuteNonQuery();
                // Recup du nouvelle ID
                outId = command.Parameters["@outId"].Value.ToString();
                //
                transaction.Commit();
            }
            catch (SqlException e) {
                MessageErreur = "Erreur SqlServer \n" + GetMessageSql(e.Message);
            }
            catch (Exception e) {
                MessageErreur = e.Message + "Autre Erreur, les informations n'ont pas été correctement saisies";
            }
            finally {
                if (MessageErreur.Length > 0) {
                    transaction.Rollback();             // annulation de la transaction
                    throw new Exception(MessageErreur); // Déclenchement de l'exception
                }
            }
        }

        /// <summary>Procédure publique qui va appeler la procédure stockée permettant d'inscrire un nouveau bénevole</summary>
        static public void InscrireBenevole(String pNom, String pPrenom, String pAdresse1, String pAdresse2, String pCp, String pVille, String pTel, String pMail, DateTime pDateNaissanceBenevole, String pNumeroLicence, out String outId)
        {
            outId = null; // Default Out
            String MessageErreur = "";
            SqlTransaction transaction = DataBaseConnection.BeginTransaction();
            try {
                SqlCommand command = new SqlCommand("PS_InsererBenevole", DataBaseConnection);
                command.CommandType = CommandType.StoredProcedure;  // début de la transaction SqlServer il vaut mieux gérer les transactions dans l'applicatif que dans la bd dans les procédures stockées.
                command.Transaction = transaction;
                // 
                ParamCommunsNouveauxParticipants(command, pNom, pPrenom, pAdresse1, pAdresse2, pCp, pVille, pTel, pMail);  // params commun aux participant
                command.Parameters.Add("@pType", SqlDbType.VarChar).Value = "B";   // "B" pour bénévole
                command.Parameters.Add("@pDateNaissanceBenevole", SqlDbType.Int).Value = pDateNaissanceBenevole;
                command.Parameters.Add("@pNumeroLicence", SqlDbType.VarChar).Value = pNumeroLicence;
                command.Parameters.Add("@outId", SqlDbType.Int).Direction = ParameterDirection.Output;
                //
                command.ExecuteNonQuery();
                // Recup du nouvelle ID
                outId = command.Parameters["@outId"].Value.ToString();
                //
                transaction.Commit();
            }
            catch (SqlException e) {
                MessageErreur = "Erreur SqlServer \n" + GetMessageSql(e.Message);
            }
            catch (Exception e) {
                MessageErreur = e.Message + "Autre Erreur, les informations n'ont pas été correctement saisies";
            }
            finally {
                if (MessageErreur.Length > 0)
                {
                    transaction.Rollback();             // annulation de la transaction
                    throw new Exception(MessageErreur); // Déclenchement de l'exception
                }
            }
        }

        /// <summary>Procédure publique qui va appeler la procédure stockée permettant d'ajouter une nuites</summary>
        static public void AjouterUneDateDeBenevolat(String pIdParticipant, String pIdDateBenevolat)
        {
            String MessageErreur = "";
            //
            SqlTransaction transaction = DataBaseConnection.BeginTransaction();
            try {
                SqlCommand command = new SqlCommand("PS_AjouterDateBenevolat", DataBaseConnection);
                command.CommandType = CommandType.StoredProcedure; 
                command.Transaction = transaction;
                //
                command.Parameters.Add("@pIdParticipant", SqlDbType.Int).Value = pIdParticipant; 
                command.Parameters.Add("@pIdDateBenevolat", SqlDbType.Int).Value = pIdDateBenevolat;
                //
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException e) {
                MessageErreur = "Erreur SqlServer \n" + GetMessageSql(e.Message);
            }
            catch (Exception e) {
                MessageErreur = e.Message + "Autre Erreur, les informations n'ont pas été correctement saisies";
            }
            finally {
                if (MessageErreur.Length > 0) {
                    transaction.Rollback(); 
                    throw new Exception(MessageErreur);
                }
            }

        }


        /// <summary>Procédure publique qui va appeler la procédure stockée permettant d'ajouter une nuites</summary>
        static public void AjouterUneNuite(String pIdParticipant, String pIdNuite, String pHotel, String pCategorieChmabre)
        {
            String MessageErreur = "";
            //
            SqlTransaction transaction = DataBaseConnection.BeginTransaction();
            try {
                SqlCommand command = new SqlCommand("PS_AjouterNuite", DataBaseConnection);
                command.CommandType = CommandType.StoredProcedure; 
                command.Transaction = transaction;
                //
                command.Parameters.Add("@pIdParticipant", SqlDbType.Int).Value = pIdParticipant; 
                command.Parameters.Add("@pIdNuite", SqlDbType.Int).Value = pIdNuite;
                command.Parameters.Add("@pIdHotel", SqlDbType.Int).Value = pHotel;
                command.Parameters.Add("@pIdCategorieChambre", SqlDbType.Int).Value = pCategorieChmabre;
                //
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException e) {
                MessageErreur = "Erreur SqlServer \n" + GetMessageSql(e.Message);
            }
            catch (Exception e) {
                MessageErreur = e.Message + "Autre Erreur, les informations n'ont pas été correctement saisies";
            }
            finally {
                if (MessageErreur.Length > 0) {
                    transaction.Rollback(); 
                    throw new Exception(MessageErreur);
                }
            }

        }










        /*
        
        /// <summary>procédure qui va se charger d'invoquer la procédure stockée qui ira inscrire un participant de type bénévole</summary>
        /// <param name="Cmd">nom de l'objet command concerné par les paramètres</param>
        /// <param name="pNom">nom du participant</param>
        /// <param name="pPrenom">prénom du participant</param>
        /// <param name="pAdresse1">adresse1 du participant</param>
        /// <param name="pAdresse2">adresse2 du participant</param>
        /// <param name="pCp">cp du participant</param>
        /// <param name="pVille">ville du participant</param>
        /// <param name="pTel">téléphone du participant</param>
        /// <param name="pMail">mail du participant</param>
        /// <param name="pDateNaissance">mail du bénévole</param>
        /// <param name="pNumeroLicence">numéro de licence du bénévole ou null</param>
        /// <param name="pDateBenevolat">collection des id des dates où le bénévole sera présent</param>
        static public void InscrireBenevole(String pNom, String pPrenom, String pAdresse1, String pAdresse2, String pCp, String pVille, String pTel, String pMail, DateTime pDateNaissance, Int64? pNumeroLicence, Collection<Int16> pDateBenevolat)
        {


        }
        */

        //
        // méthodes private static
        //

        /// <summary>méthode permettant de renvoyer un message d'erreur provenant de la bd après l'avoir formatté. On ne renvoie que le message, sans code erreur</summary>
        /// <param name="unMessage">message à formater</param>
        /// <returns>message formaté à afficher dans l'application</returns>
        static private String GetMessageSql(String unMessage)
        {
            String[] message = Regex.Split(unMessage, "SQLSERVER-");
            return (Regex.Split(message[1], ":"))[1];
        }
   
        

        /// <summary>méthode privée permettant de valoriser les paramètres d'un objet commmand communs aux licenciés, bénévoles et intervenants</summary>
        /// <param name="Cmd">nom de l'objet command concerné par les paramètres</param>
        /// <param name="pNom">nom du participant</param>
        /// <param name="pPrenom">prénom du participant</param>
        /// <param name="pAdresse1">adresse1 du participant</param>
        /// <param name="pAdresse2">adresse2 du participant</param>
        /// <param name="pCp">cp du participant</param>
        /// <param name="pVille">ville du participant</param>
        /// <param name="pTel">téléphone du participant</param>
        /// <param name="pMail">mail du participant</param>
        static private void ParamCommunsNouveauxParticipants(SqlCommand Cmd, String pNom, String pPrenom, String pAdresse1, String pAdresse2, String pCp, String pVille, String pTel, String pMail)
        {
            Cmd.Parameters.Add("@pNom", SqlDbType.VarChar).Value = pNom;
            Cmd.Parameters.Add("@pPrenom", SqlDbType.VarChar).Value = pPrenom;
            Cmd.Parameters.Add("@pAdr1", SqlDbType.VarChar).Value = pAdresse1;
            Cmd.Parameters.Add("@pAdr2", SqlDbType.VarChar).Value = pAdresse2;
            Cmd.Parameters.Add("@pCp", SqlDbType.VarChar).Value = pCp;
            Cmd.Parameters.Add("@pVille", SqlDbType.VarChar).Value = pVille;
            Cmd.Parameters.Add("@pTel", SqlDbType.VarChar).Value = pTel;
            Cmd.Parameters.Add("@pMail", SqlDbType.VarChar).Value = pMail;
        }

        /*
        /// <summary>
        /// fonction permettant de construire un dictionnaire dont l'id est l'id d'une nuité et le contenu une date
        /// sous la la forme : lundi 7 janvier 2014        /// 
        /// </summary>
        /// <returns>un dictionnaire dont l'id est l'id d'une nuité et le contenu une date</returns>
        static public Dictionary<Int16, String> ObtenirDatesNuitees() {
            Dictionary<Int16, String> LesDatesARetourner = new Dictionary<Int16, String>();
            DataTable LesDatesNuitees = ObtenirDonnees("V_DATENUITEE02");
            foreach (DataRow UneLigne in LesDatesNuitees.Rows) {
                LesDatesARetourner.Add(System.Convert.ToInt16(UneLigne["ID"]), UneLigne["DATEARRIVEENUITEE"].ToString());
            }
            return LesDatesARetourner;
        }
        */





    }
}
