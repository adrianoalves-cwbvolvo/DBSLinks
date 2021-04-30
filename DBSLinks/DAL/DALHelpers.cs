using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Links.Model;
using Links.Properties;
using LinksForm.Controller;
using LinksForm.Model;
using LinksForms.Model;

namespace LinksForm.DAL
{
    class DALHelpers
    {

        #region "DB CONNECTION"

        //OPENING THE LOCAL DB CONNECTION
        private static OleDbConnection OpenLocalDBConnection()
        {
            string localDBConnectionString;

            try
            {
                localDBConnectionString = Settings.Default["localDatabaseConnectionString"].ToString();
                OleDbConnection connection = new OleDbConnection();

                //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=//vcn.ds.volvo.net/it-cta/ITPROJ02/002378/DESENV/DBS/AUTOMATOR/LINKS FORM/Database/Links.accdb; Persist Security Info=False;";
                connection.ConnectionString = @localDBConnectionString;
                connection.Open();
                return connection;
            }
            catch
            {
                throw;
            }
        }

        //OPENING THE NETWORK CONNECTION
        private static OleDbConnection OpenNetworkDBConnection()
        {
            string networkDBConnectionString;

            try
            {
                networkDBConnectionString = Settings.Default["networkDatabaseConnectionString"].ToString();
                OleDbConnection connection = new OleDbConnection();

                connection.ConnectionString = @networkDBConnectionString;
                connection.Open();
                return connection;
            }
            catch
            {
                throw;
            }
        }
        //CLOSING THE DB CONNECTION
        private static void CloseDBConnection(OleDbConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region "APP SESSION"
        //public static AppSession GetAppSession()
        //{
        //    try
        //    {
        //        OleDbConnection connection = new OleDbConnection();
        //        connection = OpenLocalDBConnection();

        //        OleDbCommand command = new OleDbCommand();
        //        command.Connection = connection;

        //        command.CommandText = "SELECT TOP 1 LatestVersion, UpdateDate FROM AppSessions ORDER BY UpdateDate DESC";
        //        OleDbDataReader reader = command.ExecuteReader();

        //        AppSession appSession = new AppSession();

        //        while (reader.Read())
        //        {
        //            appVersion.VersionId = Convert.ToInt32(reader["VersionId"].ToString());
        //            appVersion.LatestVersion = reader["LatestVersion"].ToString();
        //            appVersion.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
        //        }

        //        CloseDBConnection(connection);

        //        return appVersion;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public static bool AddAppSession(AppSession appSession)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "INSERT INTO AppSessions (ComputerName, LastLoginDate, UserId, IsAppUpdateAvailable, IsDataUpdateAvailable, AppVersion) VALUES(@computerName, @lastLoginDate, @userId, @isAppUpdateAvailable, @isDataUpdateAvailable, @appVersion)";
                command.Parameters.AddWithValue("@computerName", appSession.AppSessionId);
                command.Parameters.AddWithValue("@lastLoginDate", appSession.ComputerName);
                command.Parameters.AddWithValue("@userId", appSession.UserId);
                command.Parameters.AddWithValue("@isAppUpdateAvailable", appSession.IsAppUpdateAvailable);
                command.Parameters.AddWithValue("@isDataUpdateAvailable", appSession.IsDataUpdateAvailable);
                command.Parameters.AddWithValue("@appVersion", appSession.AppVersion);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public static bool updateAppSession(AppSession appSession)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "UPDATE AppSessions SET LastLoginDate = @LastLoginDate, UserId = @userId, IsAppUpdateAvailable = @isAppUpdateAvailable, IsDataUpdateAvailable = @isDataUpdateAvailable, AppVersion = @appVersion WHERE AppSessionId = @appSessionId)";
                command.Parameters.AddWithValue("@lastLoginDate", appSession.ComputerName);
                command.Parameters.AddWithValue("@userId", appSession.UserId);
                command.Parameters.AddWithValue("@isAppUpdateAvailable", appSession.IsAppUpdateAvailable);
                command.Parameters.AddWithValue("@isDataUpdateAvailable", appSession.IsDataUpdateAvailable);
                command.Parameters.AddWithValue("@appVersion", appSession.AppVersion);
                command.Parameters.AddWithValue("@AppSessionId", appSession.AppSessionId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);
                return true;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region "CONTACTS"

        //RETRIEVING ALL THE CONTACTS FROM DB
        public static List<Contact> GetContacts()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT c.ContactId, c.Name, c.Phone, c.CellPhone, c.ComputerName, c.TeamId, t.TeamName FROM Contacts c INNER JOIN Teams t ON c.TeamId = t.TeamId";
                OleDbDataReader reader = command.ExecuteReader();

                var contactList = new List<Contact>();
                contactList.Clear();

                while (reader.Read())
                {
                    Contact contact = new Contact();

                    contact.Id = reader["ContactId"].ToString();
                    contact.Name = reader["Name"].ToString();
                    contact.Phone = reader["Phone"].ToString();
                    contact.CellPhone = reader["CellPhone"].ToString();
                    contact.Computer = reader["ComputerName"].ToString();
                    contact.TeamId = Convert.ToInt32(reader["TeamId"].ToString());
                    contact.TeamName = reader["TeamName"].ToString();

                    contactList.Add(contact);
                }

                CloseDBConnection(connection);

                return contactList;
            }
            catch
            {
                throw;
            }
        }
        public static List<Contact> GetContactById(string Id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Contacts WHERE ContactId = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                OleDbDataReader reader = command.ExecuteReader();

                var contactList = new List<Contact>();

                while (reader.Read())
                {
                    Contact contact = new Contact();

                    contact.Id = reader["ContactId"].ToString();
                    contact.Name = reader["Name"].ToString();
                    contact.Phone = reader["Phone"].ToString();
                    contact.Computer = reader["ComputerName"].ToString();

                    contactList.Add(contact);
                }

                CloseDBConnection(connection);

                return contactList;
            }
            catch
            {
                throw;
            }
        }
        public static bool AddContact(Contact contact)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenNetworkDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Contacts (ContactId, Name, CellPhone, Phone, ComputerName, TeamId) VALUES(@Id, @Name, @CellPhone, @Phone, @ComputerName, @TeamId)";
                command.Parameters.AddWithValue("@Id", contact.Id);
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@CellPhone", contact.CellPhone);
                command.Parameters.AddWithValue("@Phone", contact.Phone);
                command.Parameters.AddWithValue("@ComputerName", contact.Computer);
                command.Parameters.AddWithValue("@TeamId", contact.TeamId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateContact(Contact contact)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenNetworkDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "UPDATE Contacts SET Name = @name, Phone = @phone, CellPhone = @cellPhone, ComputerName = @computerName, TeamId = @teamid WHERE ContactId = @id";
                command.Parameters.AddWithValue("@name", contact.Name);
                command.Parameters.AddWithValue("@phone", contact.Phone);
                command.Parameters.AddWithValue("@cellPhone", contact.CellPhone);
                command.Parameters.AddWithValue("@computerName", contact.Computer);
                command.Parameters.AddWithValue("@teamid", contact.TeamId);
                command.Parameters.AddWithValue("@id", contact.Id);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteContact(string ID)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenNetworkDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "DELETE FROM Contacts WHERE ContactId=@ID";
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch (Exception)
            {
               
                return false;
            }
        }

        #endregion

        #region "CATEGORIES"
        public static List<Category> GetCategories()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM AppCategory";
                OleDbDataReader reader = command.ExecuteReader();

                var categoryList = new List<Category>();
                categoryList.Clear();

                while (reader.Read())
                {
                    Category category = new Category();

                    category.CategoryId = Convert.ToInt32(reader["AppCategoryId"].ToString());
                    category.CategoryName = reader["AppCategoryName"].ToString();

                    categoryList.Add(category);
                }

                CloseDBConnection(connection);

                return categoryList;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region "COUNTRIES"

        public static Country GetCountryById(int Id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Countries WHERE CountryId = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                OleDbDataReader reader = command.ExecuteReader();

                Country country = new Country();

                while (reader.Read())
                {
                    country.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                    country.CountryName = reader["CountryName"].ToString();
                }

                CloseDBConnection(connection);

                return country;
            }
            catch
            {
                throw;
            }
        }
        public static Country GetCountryByName(string Name)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Countries WHERE CountryName = @countryName";
                command.Parameters.AddWithValue("@countryName", Name);
                OleDbDataReader reader = command.ExecuteReader();

                Country country = new Country();

                while (reader.Read())
                {
                    country.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                    country.CountryName = reader["CountryName"].ToString();
                }

                CloseDBConnection(connection);

                return country;
            }
            catch
            {
                throw;
            }
        }
        public static List<Country> GetCountries()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Countries";
                OleDbDataReader reader = command.ExecuteReader();

                var countryList = new List<Country>();
                countryList.Clear();

                while (reader.Read())
                {
                    Country country = new Country();

                    country.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                    country.CountryName = reader["CountryName"].ToString();

                    countryList.Add(country);
                }

                CloseDBConnection(connection);

                return countryList;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region "CREDENTIALS"

        public static List<Credential> GetCredentials()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Credentials";
                OleDbDataReader reader = command.ExecuteReader();

                var credentialList = new List<Credential>();

                credentialList.Clear();

                while (reader.Read())
                {
                    Credential credential = new Credential();

                    credential.CredentialId = Convert.ToInt32(reader["CredentialId"].ToString());
                    credential.Username = reader["Username"].ToString();
                    credential.Password = reader["Password"].ToString();
                    credential.CredentialDescription = reader["CredentialDescription"].ToString();

                    credentialList.Add(credential);
                }

                CloseDBConnection(connection);

                return credentialList;
            }
            catch
            {
                throw;
            }
        }
        public static bool AddCredential(Credential credential)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Credentials (Username, [Password], CredentialDescription) VALUES (@username, @password, @credentialDescription)";
                //command.CommandText = "INSERT INTO Credentials (CredentialId, Username, [Password]) VALUES (@credentialId, @username, @password)";
                //command.Parameters.AddWithValue("@credentialId", Convert.ToInt32(credential.CredentialId));
                command.Parameters.AddWithValue("@username", credential.Username);
                command.Parameters.AddWithValue("@password", credential.Password);
                command.Parameters.AddWithValue("@credentialDescription", credential.CredentialDescription);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateCredential(Credential credential)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "UPDATE Credentials SET Username = @username, [Password] = @password, CredentialDescription = @credentialDescription WHERE CredentialId = @ID";
                command.Parameters.AddWithValue("@username", credential.Username);
                command.Parameters.AddWithValue("@password", Encryption.Encrypt(credential.Password.ToString()));
                command.Parameters.AddWithValue("@credentialDescription", credential.CredentialDescription);
                command.Parameters.AddWithValue("@ID", credential.CredentialId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch (Exception caughtEx)
            {
                throw new Exception("Unknown Exception Thrown: "
                                    + "\n  Type:    " + caughtEx.GetType().Name
                                    + "\n  Message: " + caughtEx.Message);
            }
            //catch
            //{
            //    return false;
            //}
        }
        public static List<Credential> GetCredentialByUsername(string username)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Credentials WHERE Username = @Username";
                command.Parameters.AddWithValue("@Username", username);
                OleDbDataReader reader = command.ExecuteReader();

                var credentialList = new List<Credential>();

                while (reader.Read())
                {
                    Credential credential = new Credential();

                    credential.CredentialId = Convert.ToInt32(reader["CredentialId"].ToString());
                    credential.Username = reader["Username"].ToString();
                    credential.Password = Encryption.Decrypt(reader["Password"].ToString());
                    credential.CredentialDescription = reader["CredentialDescription"].ToString();

                    credentialList.Add(credential);
                }

                CloseDBConnection(connection);

                return credentialList;
            }
            catch
            {
                throw;
            }
        }
        public static Credential GetCredentialById(int CredentialId)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Credentials WHERE CredentialId = @credentialId";
                command.Parameters.AddWithValue("@credentialId", CredentialId);
                OleDbDataReader reader = command.ExecuteReader();

                Credential credential = new Credential();

                while (reader.Read())
                {
                    credential.CredentialId = Convert.ToInt32(reader["CredentialId"].ToString());
                    credential.Username = reader["Username"].ToString();
                    credential.Password = Encryption.Decrypt(reader["Password"].ToString());
                    credential.CredentialDescription = reader["CredentialDescription"].ToString();
                }

                CloseDBConnection(connection);

                return credential;
            }
            catch
            {
                throw;
            }
        }
        public static bool DeleteCredential(int ID)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.Connection = OpenLocalDBConnection();

                command.CommandText = "DELETE FROM Credentials WHERE CredentialId=@ID";
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "DEALERS"

        public static List<Dealer> GetDealersByCountry(int CountryId)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT DealerId, DealerName, CountryId FROM Dealer WHERE CountryId = @countryid";
                command.Parameters.AddWithValue("@countryid", CountryId);
                OleDbDataReader reader = command.ExecuteReader();

                var dealerList = new List<Dealer>();

                while (reader.Read())
                {
                    Dealer dealer = new Dealer();

                    dealer.DealerId = Convert.ToInt32(reader["DealerId"]);
                    dealer.DealerName = reader["DealerName"].ToString();
                    dealer.CountryId = Convert.ToInt32(reader["CountryId"]);

                    dealerList.Add(dealer);
                }

                CloseDBConnection(connection);

                return dealerList;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region "DEALER BRANCHS"

        public static List<DealerBranch> GetDealerBranchs()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT " +
                                        "B.DealerBranchId, " +
                                        "D.DealerId, " +
                                        "B.Branch, " +
                                        "B.CountryId, " +
                                        "B.CTDI, " +
                                        "B.PhoneNumber, " +
                                        "B.BaldoPartner, " +
                                        "D.DealerName, " +
                                        "C.CountryName " +
                                        "FROM (DealerBranch B " +
                                        "INNER JOIN Dealer D " +
                                        "ON B.DealerId = D.DealerId) " +
                                        "INNER JOIN Countries C " +
                                        "ON B.CountryId = C.CountryId ";

                OleDbDataReader reader = command.ExecuteReader();

                var dealerList = new List<DealerBranch>();

                var columns = new List<string>();

                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    columns.Add(reader.GetName(i));
                //}

                while (reader.Read())
                {

                    DealerBranch dealer = new DealerBranch();

                    dealer.DealerBranchId = Convert.ToInt32(reader["DealerBranchId"]);
                    dealer.DealerId = Convert.ToInt32(reader["DealerId"]);
                    dealer.BranchName = reader["Branch"].ToString();
                    dealer.CountryId = Convert.ToInt32(reader["CountryId"]);
                    dealer.DealerName = reader["DealerName"].ToString();
                    dealer.CTDI = Convert.ToInt32(reader["CTDI"].ToString());
                    dealer.PhoneNumber = reader["PhoneNumber"].ToString();
                    dealer.BaldoPartner = reader["BaldoPartner"].ToString();
                    dealer.DealerName = reader["DealerName"].ToString();
                    dealer.CountryName = reader["CountryName"].ToString();
                   
                    //dealer.MainDealerId = Convert.ToInt32(reader["MaiDealerId"]);
                    dealer.BaldoPartner = reader["BaldoPartner"].ToString();

                    dealerList.Add(dealer);
                }

                CloseDBConnection(connection);

                return dealerList;
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateDealerBranch(DealerBranch dealerBranch)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenNetworkDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                                        //UPDATE Contacts SET Name = @name, Phone = @phone, CellPhone = @cellPhone, ComputerName = @computerName, TeamId = @teamid WHERE ContactId = @id
                command.CommandText = "UPDATE DealerBranch SET DealerId = @dealerId, Branch = @branch, CountryId = @countryId, CTDI = @ctdi, PhoneNumber = @phoneNumber, BaldoPartner = @baldoPartner WHERE DealerBranchId = @id";
                command.Parameters.AddWithValue("@dealerId", dealerBranch.DealerId);
                command.Parameters.AddWithValue("@branch", dealerBranch.BranchName);
                command.Parameters.AddWithValue("@countryId", dealerBranch.CountryId);
                command.Parameters.AddWithValue("@ctdi", dealerBranch.CTDI);
                command.Parameters.AddWithValue("@phoneNumber", dealerBranch.PhoneNumber);
                command.Parameters.AddWithValue("@baldoPartner", dealerBranch.BaldoPartner);
                command.Parameters.AddWithValue("@id", dealerBranch.DealerBranchId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddDealerBranch(DealerBranch dealerBranch)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenNetworkDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                                        //INSERT INTO Contacts (ContactId, Name, CellPhone, Phone, ComputerName, TeamId) VALUES(@Id, @Name, @CellPhone, @Phone, @ComputerName, @TeamId)
                command.CommandText = "INSERT INTO DealerBranch (DealerId, Branch, CountryId, CTDI, PhoneNumber, BaldoPartner) VALUES (@dealerId, @branch, @countryId, @ctdi, @phoneNumber, @baldoPartner)";
                command.Parameters.AddWithValue("@dealerId", dealerBranch.DealerId);
                command.Parameters.AddWithValue("@branch", dealerBranch.BranchName);
                command.Parameters.AddWithValue("@countryId", dealerBranch.CountryId);
                command.Parameters.AddWithValue("@ctdi", dealerBranch.CTDI);
                command.Parameters.AddWithValue("@phoneNumber", dealerBranch.PhoneNumber);
                command.Parameters.AddWithValue("@baldoPartner", dealerBranch.BaldoPartner);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteDealerBranch(int ID)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenNetworkDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "DELETE FROM DealerBranch WHERE DealerBranchId=@ID";
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "DEALER CONTACTS"

        public static List<DealerContact> GetDealerContacts()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT DISTINCT dc.DealerContactId, dc.MainDealerId, dc.Description, dc.Phone, dc.CellPhone, dc.Email, dc.Department, d.DealerName, c.CountryId, c.CountryName FROM (DealerContacts dc INNER JOIN DealerBranch d ON dc.MainDealerId = d.MainDealerId) INNER JOIN Countries c ON d.CountryId = c.CountryId";
                OleDbDataReader reader = command.ExecuteReader();

                var dealerContactList = new List<DealerContact>();

                while (reader.Read())
                {
                    DealerContact dealerContact = new DealerContact();

                    dealerContact.DealerContactId = Convert.ToInt32(reader["DealerContactId"].ToString());
                    dealerContact.MainDealerId = Convert.ToInt32(reader["MainDealerId"].ToString());
                    dealerContact.Name = reader["Description"].ToString();
                    dealerContact.Phone = reader["Phone"].ToString();
                    dealerContact.CellPhone = reader["CellPhone"].ToString();
                    dealerContact.Email = reader["Email"].ToString();
                    dealerContact.Department = reader["Department"].ToString();
                    dealerContact.DealerName = reader["DealerName"].ToString();
                    dealerContact.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                    dealerContact.Country = reader["CountryName"].ToString();

                    dealerContactList.Add(dealerContact);
                }

                CloseDBConnection(connection);

                return dealerContactList;
            }
            catch
            {
                throw;
            }
        }
        public static List<DealerContact> GetDealerContactByDealerId(int Id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM DealerContacts WHERE MainDealerId = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                OleDbDataReader reader = command.ExecuteReader();

                var dealerContactList = new List<DealerContact>();

                while (reader.Read())
                {
                    DealerContact dealerContact = new DealerContact();

                    dealerContact.DealerContactId = Convert.ToInt32(reader["DealerContactId"].ToString());
                    dealerContact.MainDealerId = Convert.ToInt32(reader["MainDealerId"].ToString());
                    dealerContact.Name = reader["Description"].ToString();
                    dealerContact.Department = reader["Department"].ToString();
                    dealerContact.Phone = reader["Phone"].ToString();
                    dealerContact.CellPhone = reader["CellPhone"].ToString();
                    dealerContact.Email = reader["Email"].ToString();

                    dealerContactList.Add(dealerContact);
                }

                CloseDBConnection(connection);

                return dealerContactList;
            }
            catch
            {
                throw;
            }
        }
        public static List<DealerContact> GetDealerContactByMainDealerId(int Id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM DealerContacts WHERE MainDealerId = @ID";
                command.Parameters.AddWithValue("@ID", Id);
                OleDbDataReader reader = command.ExecuteReader();

                var dealerContactList = new List<DealerContact>();

                while (reader.Read())
                {
                    DealerContact dealerContact = new DealerContact();

                    dealerContact.DealerContactId = Convert.ToInt32(reader["DealerContactId"].ToString());
                    dealerContact.MainDealerId = Convert.ToInt32(reader["MainDealerId"].ToString());
                    dealerContact.Name = reader["Description"].ToString();
                    dealerContact.Department = reader["Department"].ToString();
                    dealerContact.Phone = reader["Phone"].ToString();
                    dealerContact.CellPhone = reader["CellPhone"].ToString();
                    dealerContact.Email = reader["Email"].ToString();

                    dealerContactList.Add(dealerContact);
                }

                CloseDBConnection(connection);

                return dealerContactList;
            }
            catch
            {
                throw;
            }
        }
        public static bool AddDealerContact(DealerContact dealerContact)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "INSERT INTO DealerContacts (MainDealerId, Description, Department, Phone, CellPhone, Email) VALUES(@mainDealerid, @description, @department, @phone, @cellPhone, @email)";
                command.Parameters.AddWithValue("@mainDealerid", dealerContact.MainDealerId);
                command.Parameters.AddWithValue("@description", dealerContact.Name);
                command.Parameters.AddWithValue("@department", dealerContact.Department);
                command.Parameters.AddWithValue("@phone", dealerContact.Phone);
                command.Parameters.AddWithValue("@cellPhone", dealerContact.CellPhone);
                command.Parameters.AddWithValue("@email", dealerContact.Email);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateDealerContact(DealerContact dealerContact)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "UPDATE DealerContacts SET Description = @description, Department = @department, Phone = @phone, CellPhone = @cellphone, Email = @email WHERE DealerContactId = @id";
                command.Parameters.AddWithValue("@description", dealerContact.Name);
                command.Parameters.AddWithValue("@department", dealerContact.Department);
                command.Parameters.AddWithValue("@phone", dealerContact.Phone);
                command.Parameters.AddWithValue("@cellPhone", dealerContact.CellPhone);
                command.Parameters.AddWithValue("@email", dealerContact.Email);
                command.Parameters.AddWithValue("@id", dealerContact.DealerContactId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteDealerContact(int Id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.Connection = OpenLocalDBConnection();

                command.CommandText = "DELETE FROM DealerContacts WHERE DealerContactId=@ID";
                command.Parameters.AddWithValue("@ID", Id);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "APPLICATIONS"

        public static bool AddApplication(App application)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Applications (ApplicationName) VALUES(@applicationName)";
                command.Parameters.AddWithValue("@applicationName", application.ApplicationName);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);
                return true;
            }
            catch
            {
                throw;
            }
        }
        public static List<App> GetApplications()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Applications";
                OleDbDataReader reader = command.ExecuteReader();

                var appList = new List<App>();

                while (reader.Read())
                {
                    App app = new App();

                    app.ApplicationId = Convert.ToInt32(reader["ApplicationId"]);
                    app.ApplicationName = reader["ApplicationName"].ToString();
                    appList.Add(app);
                }

                CloseDBConnection(connection);

                return appList;
            }
            catch
            {
                throw;
            }
        }
        public static List<App> GetApplicationByID(int ApplicationId)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Applications WHERE ApplicationId = @ID";
                command.Parameters.AddWithValue("@ID", ApplicationId);
                OleDbDataReader reader = command.ExecuteReader();

                var appList = new List<App>();

                while (reader.Read())
                {
                    App app = new App();

                    app.ApplicationId = Convert.ToInt32(reader["ApplicationId"]);
                    app.ApplicationName = reader["ApplicationName"].ToString();
                    appList.Add(app);
                }

                CloseDBConnection(connection);

                return appList;
            }
            catch
            {
                throw;
            }
        }
        public static bool DeleteApplication(int ApplicationId)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "DELETE FROM Applications WHERE ApplicationId = @ID";
                command.Parameters.AddWithValue("@ID", ApplicationId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateApplication(App application)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "UPDATE Applications SET ApplicationName = @applicationName WHERE ApplicationId = @ID";
                command.Parameters.AddWithValue("@applicationName", application.ApplicationName);
                command.Parameters.AddWithValue("@ID", application.ApplicationId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region "APPLINKS"

        public static List<AppLinks> GetAppLinkByDescription(string description)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT " +
                        "a.ListId," +
                        //"a.EnvironmentId," +
                        //"ae.AppEnvironmentName,"+
                        "a.AppCategoryId," +
                        "ac.AppCategoryName," +
                        "a.ApplicationId," +
                        "ap.ApplicationName," +
                        //"a.ApplicationNodeId," +
                        //"an.AppNodeName,"+
                        "a.CountryId," +
                        "c.CountryName," +
                        "a.Description," +
                        "a.Link, " +
                        "a.CredentialId," +
                        "cr.CredentialDescription," +
                        "cr.Username," +
                        "cr.Password " +
                        "FROM (((AppLinks a " +
                        "INNER JOIN Countries c " +
                        "ON a.CountryId = c.CountryId) " +
                        "LEFT JOIN Applications ap " +
                        "ON a.ApplicationId = ap.ApplicationId) " +
                        "LEFT JOIN AppCategory ac " +
                        "ON a.AppCategoryId = ac.AppCategoryId) " +
                        "LEFT JOIN Credentials cr " +
                        "ON a.CredentialId = cr.CredentialId " +
                        "WHERE a.Description LIKE '%' + @description + '%'" +
                        "ORDER BY a.Description";
                command.Parameters.AddWithValue("@description", description);
                OleDbDataReader reader = command.ExecuteReader();

                var appLinksList = new List<AppLinks>();

                while (reader.Read())
                {
                    AppLinks appLinks = new AppLinks();

                    appLinks.ListId = Convert.ToInt32(reader["ListId"]);
                    appLinks.ApplicationId = Convert.ToInt32(reader["ApplicationId"]);
                    appLinks.ApplicationName = (reader["ApplicationName"].ToString());
                    appLinks.AppCategoryId = Convert.ToInt32(reader["AppCategoryId"]);
                    appLinks.AppCategoryName = (reader["AppCategoryName"].ToString());
                    appLinks.CountryId = Convert.ToInt32(reader["CountryId"]);
                    appLinks.CountryName = (reader["CountryName"].ToString());
                    appLinks.Description = (reader["Description"].ToString());
                    appLinks.Link = (reader["Link"].ToString());

                    string _credentialId;
                    _credentialId = reader["CredentialId"].ToString();

                    if (!string.IsNullOrEmpty(_credentialId))
                    {
                        appLinks.CredentialId = Convert.ToInt32(reader["CredentialId"]);
                    }
                    else
                    {
                        appLinks.CredentialId = 0;
                    }

                    appLinks.CredentialDescription = (reader["CredentialDescription"].ToString());
                    appLinks.Username = (reader["Username"].ToString());
                    appLinks.Password = (reader["Password"].ToString());
                    appLinksList.Add(appLinks);
                }


                CloseDBConnection(connection);

                return appLinksList;
            }
            catch
            {
                throw;
            }
        }
        public static List<AppLinks> GetAppLinkById(int Id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT " +
                        "a.ListId," +
                        //"a.EnvironmentId," +
                        //"ae.AppEnvironmentName,"+
                        "a.AppCategoryId," +
                        "ac.AppCategoryName," +
                        "a.ApplicationId," +
                        "ap.ApplicationName," +
                        //"a.ApplicationNodeId," +
                        //"an.AppNodeName,"+
                        "a.CountryId," +
                        "c.CountryName," +
                        "a.Description," +
                        "a.Link, " +
                        "a.CredentialId," +
                        "cr.CredentialDescription," +
                        "cr.Username," +
                        "cr.Password " +
                        "FROM (((AppLinks a " +
                        "INNER JOIN Countries c " +
                        "ON a.CountryId = c.CountryId) " +
                        "LEFT JOIN Applications ap " +
                        "ON a.ApplicationId = ap.ApplicationId) " +
                        "LEFT JOIN AppCategory ac " +
                        "ON a.AppCategoryId = ac.AppCategoryId) " +
                        "LEFT JOIN Credentials cr " +
                        "ON a.CredentialId = cr.CredentialId " +
                        "WHERE a.ApplicationId = @ID " +
                        "ORDER BY a.CountryId,a.Description";
                command.Parameters.AddWithValue("@ID", Id);
                OleDbDataReader reader = command.ExecuteReader();

                var appLinksList = new List<AppLinks>();

                while (reader.Read())
                {
                    AppLinks appLinks = new AppLinks();

                    appLinks.ListId = Convert.ToInt32(reader["ListId"]);
                    appLinks.ApplicationId = Convert.ToInt32(reader["ApplicationId"]);
                    appLinks.ApplicationName = (reader["ApplicationName"].ToString());
                    appLinks.AppCategoryId = Convert.ToInt32(reader["AppCategoryId"]);
                    appLinks.AppCategoryName = (reader["AppCategoryName"].ToString());
                    appLinks.CountryId = Convert.ToInt32(reader["CountryId"]);
                    appLinks.CountryName = (reader["CountryName"].ToString());
                    appLinks.Description = (reader["Description"].ToString());
                    appLinks.Link = (reader["Link"].ToString());

                    string _credentialId;
                    _credentialId = reader["CredentialId"].ToString();

                    if (!string.IsNullOrEmpty(_credentialId))
                    {
                        appLinks.CredentialId = Convert.ToInt32(reader["CredentialId"]);
                    }
                    else
                    {
                        appLinks.CredentialId = 0;
                    }

                    appLinks.CredentialDescription = (reader["CredentialDescription"].ToString());
                    appLinks.Username = (reader["Username"].ToString());
                    appLinks.Password = (reader["Password"].ToString());
                    appLinksList.Add(appLinks);
                }


                CloseDBConnection(connection);

                return appLinksList;
            }
            catch
            {
                throw;
            }
        }
        public static List<AppLinks> GetAppLinks()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT " +
                        "a.ListId," +
                        //"a.EnvironmentId," +
                        //"ae.AppEnvironmentName,"+
                        "a.AppCategoryId," +
                        "ac.AppCategoryName," +
                        "a.ApplicationId," +
                        "ap.ApplicationName," +
                        //"a.ApplicationNodeId," +
                        //"an.AppNodeName,"+
                        "a.CountryId," +
                        "c.CountryName," +
                        "a.Description," +
                        "a.Link, " +
                        "a.CredentialId," +
                        "cr.CredentialDescription," +
                        "cr.Username," +
                        "cr.Password " +
                        "FROM (((AppLinks a " +
                        "INNER JOIN Countries c " +
                        "ON a.CountryId = c.CountryId) " +
                        "LEFT JOIN Applications ap " +
                        "ON a.ApplicationId = ap.ApplicationId) " +
                        "LEFT JOIN AppCategory ac " +
                        "ON a.AppCategoryId = ac.AppCategoryId) " +
                        "LEFT JOIN Credentials cr " +
                        "ON a.CredentialId = cr.CredentialId " +
                        //"WHERE a.ApplicationId = @ID " +
                        "ORDER BY a.CountryId,a.Description";

                OleDbDataReader reader = command.ExecuteReader();

                var appLinksList = new List<AppLinks>();

                while (reader.Read())
                {
                    AppLinks appLinks = new AppLinks();

                    appLinks.ListId = Convert.ToInt32(reader["ListId"]);
                    appLinks.ApplicationId = Convert.ToInt32(reader["ApplicationId"]);
                    appLinks.ApplicationName = (reader["ApplicationName"].ToString());
                    appLinks.AppCategoryId = Convert.ToInt32(reader["AppCategoryId"]);
                    appLinks.AppCategoryName = (reader["AppCategoryName"].ToString());
                    appLinks.CountryId = Convert.ToInt32(reader["CountryId"]);
                    appLinks.CountryName = (reader["CountryName"].ToString());
                    appLinks.Description = (reader["Description"].ToString());
                    appLinks.Link = (reader["Link"].ToString());

                    string _credentialId;
                    _credentialId = reader["CredentialId"].ToString();

                    if (!string.IsNullOrEmpty(_credentialId))
                    {
                        appLinks.CredentialId = Convert.ToInt32(reader["CredentialId"]);
                    }
                    else
                    {
                        appLinks.CredentialId = 0;
                    }

                    appLinks.CredentialDescription = (reader["CredentialDescription"].ToString());
                    appLinks.Username = (reader["Username"].ToString());
                    appLinks.Password = (reader["Password"].ToString());
                    appLinks.SearchString = appLinks.ApplicationName + appLinks.AppCategoryName + appLinks.CountryName + appLinks.Description+ appLinks.Link+ appLinks.Username;
                    appLinksList.Add(appLinks);
                }

                CloseDBConnection(connection);

                return appLinksList;
            }
            catch
            {
                throw;
            }
        }
        public static List<AppLinks> GetAppLinkToSearch()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT " +
                        "a.ListId," +
                        //"a.EnvironmentId," +
                        //"ae.AppEnvironmentName,"+
                        "a.AppCategoryId," +
                        "ac.AppCategoryName," +
                        "a.ApplicationId," +
                        "ap.ApplicationName," +
                        //"a.ApplicationNodeId," +
                        //"an.AppNodeName,"+
                        "a.CountryId," +
                        "c.CountryName," +
                        "a.Description," +
                        "a.Link, " +
                        "a.CredentialId," +
                        "cr.CredentialDescription," +
                        "cr.Username," +
                        "cr.Password " +
                        "FROM (((AppLinks a " +
                        "INNER JOIN Countries c " +
                        "ON a.CountryId = c.CountryId) " +
                        "LEFT JOIN Applications ap " +
                        "ON a.ApplicationId = ap.ApplicationId) " +
                        "LEFT JOIN AppCategory ac " +
                        "ON a.AppCategoryId = ac.AppCategoryId) " +
                        "LEFT JOIN Credentials cr " +
                        "ON a.CredentialId = cr.CredentialId " +
                        //"WHERE a.ApplicationId = @ID " +
                        "ORDER BY a.CountryId,a.Description";

                OleDbDataReader reader = command.ExecuteReader();

                var appLinksList = new List<AppLinks>();

                while (reader.Read())
                {
                    AppLinks appLinks = new AppLinks();

                    appLinks.ListId = Convert.ToInt32(reader["ListId"]);
                    appLinks.ApplicationId = Convert.ToInt32(reader["ApplicationId"]);
                    appLinks.ApplicationName = (reader["ApplicationName"].ToString());
                    appLinks.AppCategoryId = Convert.ToInt32(reader["AppCategoryId"]);
                    appLinks.AppCategoryName = (reader["AppCategoryName"].ToString());
                    appLinks.CountryId = Convert.ToInt32(reader["CountryId"]);
                    appLinks.CountryName = (reader["CountryName"].ToString());
                    appLinks.Description = (reader["Description"].ToString());
                    appLinks.Link = (reader["Link"].ToString());
                    appLinks.SearchString = (reader["CountryName"].ToString() + reader["ApplicationName"].ToString() + reader["Description"].ToString());

                    string _credentialId;
                    _credentialId = reader["CredentialId"].ToString();

                    if (!string.IsNullOrEmpty(_credentialId))
                    {
                        appLinks.CredentialId = Convert.ToInt32(reader["CredentialId"]);
                    }
                    else
                    {
                        appLinks.CredentialId = 0;
                    }

                    appLinks.CredentialDescription = (reader["CredentialDescription"].ToString());
                    appLinks.Username = (reader["Username"].ToString());
                    appLinks.Password = (reader["Password"].ToString());
                    appLinksList.Add(appLinks);
                }

                CloseDBConnection(connection);

                return appLinksList;
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateAppLink(AppLinks appLinks)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "UPDATE AppLinks SET AppCategoryId = @categoryId, ApplicationId = @applicationId, CountryId = @countryId, Description = @description, Link = @link, CredentialId = @credentialid WHERE ListId = @id";
                command.Parameters.AddWithValue("@categoryId", appLinks.AppCategoryId);
                command.Parameters.AddWithValue("@applicationId", appLinks.ApplicationId);
                command.Parameters.AddWithValue("@countryId", appLinks.CountryId);
                command.Parameters.AddWithValue("@description", appLinks.Description);
                command.Parameters.AddWithValue("@link", appLinks.Link);
                command.Parameters.AddWithValue("@credentialid", appLinks.CredentialId);
                command.Parameters.AddWithValue("@id", appLinks.ListId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddAppLink(AppLinks appLinks)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "INSERT INTO AppLinks (AppCategoryId, ApplicationId, CountryId, Description, Link, CredentialId) VALUES (@categoryId, @applicationId, @countryId, @description, @link, @credentialid)";
                command.Parameters.AddWithValue("@categoryId", appLinks.AppCategoryId);
                command.Parameters.AddWithValue("@applicationId", appLinks.ApplicationId);
                command.Parameters.AddWithValue("@countryId", appLinks.CountryId);
                command.Parameters.AddWithValue("@description", appLinks.Description);
                command.Parameters.AddWithValue("@link", appLinks.Link);
                command.Parameters.AddWithValue("@credentialid", appLinks.CredentialId);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool DeleteAppLink(int ID)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.Connection = OpenLocalDBConnection();

                command.CommandText = "DELETE FROM AppLinks WHERE ListId=@ID";
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteNonQuery();

                CloseDBConnection(connection);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region "TEAMS"
        public static List<Team> GetTeams()
        {
            try
            {
                OleDbConnection connection = new OleDbConnection();
                connection = OpenLocalDBConnection();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Teams";
                OleDbDataReader reader = command.ExecuteReader();

                var teamList = new List<Team>();
                teamList.Clear();

                while (reader.Read())
                {
                    Team team = new Team();

                    team.TeamId = Convert.ToInt32(reader["TeamId"].ToString());
                    team.TeamName = reader["TeamName"].ToString();

                    teamList.Add(team);
                }

                CloseDBConnection(connection);

                return teamList;
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
