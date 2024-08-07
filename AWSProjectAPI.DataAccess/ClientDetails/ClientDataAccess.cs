﻿using AWSProjectAPI.Core.Client;
using AWSProjectAPI.Core.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ResourceType = AWSProjectAPI.Core.Client.ResourceType;

namespace AWSProjectAPI.DataAccess.ClientDetails
{
    public class ClientDataAccess : IClientDataAccess
    {
        #region Private Properties
        protected string AWSDBConnectionString { get; set; }
        protected string AWS_CLIENT_DBConnectionString { get; set; }
        protected string AWS_ACCOUNT_DBString { get; set; }
        #endregion

        // Constructor
        public ClientDataAccess(IConfiguration configurationString)
        {
            // Intantiating the object
            AWSDBConnectionString = configurationString.GetConnectionString("AWSDBString");
            AWS_CLIENT_DBConnectionString = configurationString.GetConnectionString("AWS_CLIENT_DBString");
            AWS_ACCOUNT_DBString = configurationString.GetConnectionString("AWS_ACCOUNT_DBString");
        }

        // GetDisplayClientDetails
        /// <summary>
        /// Get Display client details
        /// </summary>
        /// <returns>
        /// DisplayClientDetails object list value of the Id
        /// </returns>
        /// <remarks>
        /// filter -> Filter object
        /// companyId -> number
        /// </remarks>
        public List<DisplayClientDetails> GetDisplayClientDetails(Filter filter, ConnectionString connectionString)
        {
            // Declare the value list
            List<DisplayClientDetails> displayClients = new List<DisplayClientDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientCustomer_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter SearchQueryParameter = sqlCommandToken.Parameters.Add("@SearchQuery", SqlDbType.VarChar);
                        SearchQueryParameter.Value = filter.SearchQuery;
                        SqlParameter ClientTypeParameter = sqlCommandToken.Parameters.Add("@ClientType", SqlDbType.VarChar);
                        ClientTypeParameter.Value = filter.Param1;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$DSP";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            displayClients.Add(new DisplayClientDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                BillingAddress = resultToken["BillingAddress"].ToString(),
                                CreatedBy = resultToken["CreatedBy"].ToString(),
                                CreatedDate = Convert.ToDateTime(resultToken["CreatedDate"].ToString()),
                                ExpenseAccount = resultToken["ExpenseAccount"].ToString(),
                                FinancialNotes = resultToken["FinancialNotes"].ToString(),
                                FullName = resultToken["FullName"].ToString(),
                                PaymentTerm = resultToken["PaymentTerm"].ToString(),
                                Contacts = new List<Contact>(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetDisplayClientDetails ! :" + ex);
            }

            // Return the values
            return displayClients;
        }

        // GetAllContactList
        /// <summary>
        /// Get all the contact list
        /// </summary>
        /// <returns>
        /// Contact object list value of the Id
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>

        public List<Contact> GetAllContactListNew(Filter filter, int clientId, ConnectionString connectionString) {
            // Declare the value list
            List<Contact> contactList = new List<Contact>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            contactList.Add(new Contact()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                ContactDetails = new List<ContactDetails>(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllContactListNew ! :" + ex);
            }

            // Return the values
            return contactList;
        }


        public List<ContactDetails> GetAllContactDetailsListNew(Filter filter, int contactId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ContactDetails> contactList = new List<ContactDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Details_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = contactId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            contactList.Add(new ContactDetails()
                            {

                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                ContactValue = resultToken["ContactValue"].ToString(),
                                ContactType = new ContactType()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_ContactTypesId"].ToString()),
                                    Name = resultToken["ContactType"].ToString(),
                                    Code = resultToken["ContactTypeCode"].ToString()
                                }
                                
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllContactListNew ! :" + ex);
            }

            // Return the values
            return contactList;
        }

        // SetClientCustomer
        /// <summary>
        /// Setting the client customer
        /// </summary>
        /// <returns>
        /// int new Id
        /// </returns>
        /// <remarks>
        /// clientCustomer -> ClientCustomer object
        /// companyId -> number
        /// </remarks>
        public int SetClientCustomer(ClientCustomer clientCustomer, string staffId, string actionType, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientCustomer_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BusinessNameParameter = sqlCommandToken.Parameters.Add("@BusinessName", SqlDbType.VarChar);
                        BusinessNameParameter.Value = clientCustomer.BusinessName;
                        SqlParameter FirstNameParameter = sqlCommandToken.Parameters.Add("@FirstName", SqlDbType.VarChar);
                        FirstNameParameter.Value = clientCustomer.FirstName;
                        SqlParameter MiddleInitialParameter = sqlCommandToken.Parameters.Add("@MiddleInitial", SqlDbType.VarChar);
                        MiddleInitialParameter.Value = clientCustomer.MiddleInitial;
                        SqlParameter BusinessNumberParameter = sqlCommandToken.Parameters.Add("@BusinessNumber", SqlDbType.VarChar);
                        BusinessNumberParameter.Value = clientCustomer.BusinessNumber;
                        SqlParameter BusinessNumberTypeParameter = sqlCommandToken.Parameters.Add("@BusinessNumberType", SqlDbType.Int);
                        BusinessNumberTypeParameter.Value = clientCustomer.BusinessNumberType.Id;
                        SqlParameter AddedUserIdParameter = sqlCommandToken.Parameters.Add("@AddedUserId", SqlDbType.VarChar);
                        AddedUserIdParameter.Value = staffId;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = clientCustomer.Id;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = (actionType == "NEW") ? "SET$NEW" : (actionType == "RMV") ? "RMV" : "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetClientCustomer ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetClientCustomer
        /// <summary>
        /// Getting the client customer
        /// </summary>
        /// <returns>
        /// ClientCustomer object
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        public ClientCustomer GetClientCustomer(int clientId, ConnectionString connectionString)
        {
            // Declare the value list
            ClientCustomer clientCustomer = new ClientCustomer();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientCustomer_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = clientId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            clientCustomer = new ClientCustomer()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                BusinessName = resultToken["BusinessName"].ToString(),
                                FirstName = resultToken["FirstName"].ToString(),
                                MiddleInitial = resultToken["MiddleInitial"].ToString(),
                                BusinessNumber = resultToken["BusinessNumber"].ToString(),
                                BusinessNumberType = new BusinessNumberType()
                                {
                                    Id = Convert.ToInt32(resultToken["BusinessTypeId"].ToString()),
                                    Name = resultToken["BusinessTypeName"].ToString(),
                                    Code = resultToken["BusinessTypeCode"].ToString()
                                }
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetClientCustomer ! :" + ex);
            }

            // Return the values
            return clientCustomer;
        }

        // SetBillingAddress
        /// <summary>
        /// Setting the billing address
        /// </summary>
        /// <returns>
        /// int new Id
        /// </returns>
        /// <remarks>
        /// businessAddress -> BusinessAddress object
        /// actionType -> string
        /// companyId -> number
        /// </remarks>
        public int SetBillingAddress(BusinessAddress businessAddress, string actionType, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_BillingAddress_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter BuildingNameParameter = sqlCommandToken.Parameters.Add("@BuildingName", SqlDbType.VarChar);
                        BuildingNameParameter.Value = businessAddress.BuildingName;
                        SqlParameter StreetNameParameter = sqlCommandToken.Parameters.Add("@StreetName", SqlDbType.VarChar);
                        StreetNameParameter.Value = businessAddress.StreetName;
                        SqlParameter SuburbParameter = sqlCommandToken.Parameters.Add("@Suburb", SqlDbType.VarChar);
                        SuburbParameter.Value = businessAddress.Suburb;
                        SqlParameter PostalCodeParameter = sqlCommandToken.Parameters.Add("@PostalCode", SqlDbType.VarChar);
                        PostalCodeParameter.Value = businessAddress.PostalCode;
                        SqlParameter StateParameter = sqlCommandToken.Parameters.Add("@State", SqlDbType.VarChar);
                        StateParameter.Value = businessAddress.State;
                        SqlParameter CountryIdParameter = sqlCommandToken.Parameters.Add("@CountryId", SqlDbType.Int);
                        CountryIdParameter.Value = businessAddress.Country.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = businessAddress.Id;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = (actionType == "NEW") ? "SET$NEW" : "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetBillingAddress ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetBillingAddress
        /// <summary>
        /// Getting the billing address
        /// </summary>
        /// <returns>
        /// BusinessAddress object
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        public BusinessAddress GetBillingAddress(int clientId, ConnectionString connectionString)
        {
            // Declare the value list
            BusinessAddress businessAddress = new BusinessAddress();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_BillingAddress_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = clientId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            businessAddress = new BusinessAddress()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                BuildingName = resultToken["BuildingName"].ToString(),
                                StreetName = resultToken["StreetName"].ToString(),
                                Suburb = resultToken["Suburb"].ToString(),
                                State = resultToken["State"].ToString(),
                                PostalCode = resultToken["PostalCode"].ToString(),
                                Country = new Country()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_CountryId"].ToString()),
                                    Code = "",
                                    FlagIcon = "",
                                    Name = ""
                                }
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetBillingAddress ! :" + ex);
            }

            // Return the values
            return businessAddress;
        }

        // SetNewContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contact -> Contact object
        /// </remarks>
        public int SetNewContact(Contact contact, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = contact.Id;
                        SqlParameter NameParameter = sqlCommandToken.Parameters.Add("@Name", SqlDbType.VarChar);
                        NameParameter.Value = contact.Name;
                        //SqlParameter ContactValueParameter = sqlCommandToken.Parameters.Add("@ContactValue", SqlDbType.VarChar);
                        //ContactValueParameter.Value = contact.ContactValue;
                        //SqlParameter ContactTypeParameter = sqlCommandToken.Parameters.Add("@ContactType", SqlDbType.Int);
                        //ContactTypeParameter.Value = contact.ContactType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewContactDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }


        public int SetNewContactDetails(ContactDetails contactDet, int contactId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Details_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = contactDet.Id;
                        SqlParameter ContactValueParameter = sqlCommandToken.Parameters.Add("@ContactValue", SqlDbType.VarChar);
                        ContactValueParameter.Value = contactDet.ContactValue;
                        SqlParameter ContactTypeParameter = sqlCommandToken.Parameters.Add("@ContactType", SqlDbType.Int);
                        ContactTypeParameter.Value = contactDet.ContactType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@ContactId", SqlDbType.Int);
                        CustomerIdParameter.Value = contactId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewContactDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetUpdateContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contact -> Contact object
        /// </remarks>
        public int SetUpdateContact(Contact contact, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = contact.Id;
                        SqlParameter NameParameter = sqlCommandToken.Parameters.Add("@Name", SqlDbType.VarChar);
                        NameParameter.Value = contact.Name;
                        //SqlParameter ContactValueParameter = sqlCommandToken.Parameters.Add("@ContactValue", SqlDbType.VarChar);
                        //ContactValueParameter.Value = contact.ContactValue;
                        //SqlParameter ContactTypeParameter = sqlCommandToken.Parameters.Add("@ContactType", SqlDbType.Int);
                        //ContactTypeParameter.Value = contact.ContactType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = contact.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateContactDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        public int SetUpdateContactDetails(ContactDetails contactDet, int contactId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Details_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = contactDet.Id;
                        SqlParameter ContactValueParameter = sqlCommandToken.Parameters.Add("@ContactValue", SqlDbType.VarChar);
                        ContactValueParameter.Value = contactDet.ContactValue;
                        SqlParameter ContactTypeParameter = sqlCommandToken.Parameters.Add("@ContactType", SqlDbType.Int);
                        ContactTypeParameter.Value = contactDet.ContactType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@ContactId", SqlDbType.Int);
                        CustomerIdParameter.Value = contactId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = contactDet.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateContactDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetRemoveContactDetails
        /// <summary>
        /// Setting the Contact details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// contactId -> number
        /// </remarks>
        public int SetRemoveContact(int contactId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = contactId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = contactId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveContactDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        public int SetRemoveContactDetails(int contactDetId, int contactId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Details_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = contactDetId;
           
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = contactDetId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveContactDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetContactListDetails
        /// <summary>
        /// Getting the Contact list details
        /// </summary>
        /// <returns>
        /// Contact list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        public List<Contact> GetContactListDetailsNew(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<Contact> contacts = new List<Contact>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contact_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            contacts.Add(new Contact()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Name = resultToken["Name"].ToString(),
                                ContactDetails = new List<ContactDetails>(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetContactListDetails ! :" + ex);
            }

            // Return the values
            return contacts;
        }
        
        // SetNewSocialMediaDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// SocialMedia -> SocialMedia object
        /// </remarks>
        public int SetNewSocialMediaDetails(SocialMedia socialMedia, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_SocialMedias_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = socialMedia.Id;
                        SqlParameter SettingParameter = sqlCommandToken.Parameters.Add("@Setting", SqlDbType.VarChar);
                        SettingParameter.Value = socialMedia.Setting;
                        SqlParameter SocialMediaTypeIdParameter = sqlCommandToken.Parameters.Add("@SocialMediaTypeId", SqlDbType.Int);
                        SocialMediaTypeIdParameter.Value = socialMedia.SocialMediaType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewSocialMediaDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetUpdateSocialMediaDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public int SetUpdateSocialMediaDetails(SocialMedia socialMedia, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_SocialMedias_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = socialMedia.Id;
                        SqlParameter SettingParameter = sqlCommandToken.Parameters.Add("@Setting", SqlDbType.VarChar);
                        SettingParameter.Value = socialMedia.Setting;
                        SqlParameter SocialMediaTypeIdParameter = sqlCommandToken.Parameters.Add("@SocialMediaTypeId", SqlDbType.Int);
                        SocialMediaTypeIdParameter.Value = socialMedia.SocialMediaType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = socialMedia.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateSocialMediaDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetRemoveSocialMediaDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// sociamMediaId -> number
        /// </remarks>
        public int SetRemoveSocialMediaDetails(int sociamMediaId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_SocialMedias_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = sociamMediaId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = sociamMediaId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveSocialMediaDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetSocialMediaListDetails
        /// <summary>
        /// Getting the Social media list details
        /// </summary>
        /// <returns>
        /// SocialMedia list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        public List<SocialMedia> GetSocialMediaListDetails(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<SocialMedia> socialMediaList = new List<SocialMedia>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_Contacts_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            socialMediaList.Add(new SocialMedia()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                SocialMediaType = new SocialMediaType()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_SocialMediaTypesId"].ToString()),
                                    Code = resultToken["SocialMediaCode"].ToString(),
                                    Name = resultToken["SocialMediaName"].ToString(),
                                },
                                Setting = resultToken["Setting"].ToString(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetSocialMediaListDetails ! :" + ex);
            }

            // Return the values
            return socialMediaList;
        }

        // SetRelationshipDetails
        /// <summary>
        /// Setting the relationship details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// relationshipDetails -> RelationshipDetails object
        /// </remarks>
        public int SetRelationshipDetails(RelationshipDetails relationshipDetails, string actionType, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_RelationshipDetails_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = relationshipDetails.Id;
                        SqlParameter OfficeJobParameter = sqlCommandToken.Parameters.Add("@OfficeJob", SqlDbType.Decimal);
                        OfficeJobParameter.Value = relationshipDetails.OfficeJob;
                        SqlParameter WorkCreditParameter = sqlCommandToken.Parameters.Add("@WorkCredit", SqlDbType.Decimal);
                        WorkCreditParameter.Value = relationshipDetails.WorkCredit;
                        SqlParameter PriceClassficationIdParameter = sqlCommandToken.Parameters.Add("@PriceClassficationId", SqlDbType.Int);
                        PriceClassficationIdParameter.Value = relationshipDetails.PriceClassification.Id;
                        SqlParameter ClientSizeIdParameter = sqlCommandToken.Parameters.Add("@ClientSizeId", SqlDbType.Int);
                        ClientSizeIdParameter.Value = relationshipDetails.ClientSize.Id;
                        SqlParameter ClientTermTypesIdParameter = sqlCommandToken.Parameters.Add("@ClientTermTypesId", SqlDbType.Int);
                        ClientTermTypesIdParameter.Value = relationshipDetails.ClientTermType.Id;
                        SqlParameter ClientTermsParameter = sqlCommandToken.Parameters.Add("@ClientTerms", SqlDbType.Int);
                        ClientTermsParameter.Value = relationshipDetails.ClientTerms;
                        SqlParameter DefaultDepositParameter = sqlCommandToken.Parameters.Add("@DefaultDeposit", SqlDbType.Decimal);
                        DefaultDepositParameter.Value = relationshipDetails.DefaultDeposit;
                        SqlParameter MonthDayAlertParameter = sqlCommandToken.Parameters.Add("@MonthDayAlert", SqlDbType.Int);
                        MonthDayAlertParameter.Value = relationshipDetails.MonthDayAlert;
                        SqlParameter FinancialNotesParameter = sqlCommandToken.Parameters.Add("@FinancialNotes", SqlDbType.VarChar);
                        FinancialNotesParameter.Value = relationshipDetails.FinancialNotes;
                        SqlParameter SupplierTermTypeIdParameter = sqlCommandToken.Parameters.Add("@SupplierTermTypeId", SqlDbType.Int);
                        SupplierTermTypeIdParameter.Value = relationshipDetails.SupplierTermType.Id;
                        SqlParameter SupplierTermsParameter = sqlCommandToken.Parameters.Add("@SupplierTerms", SqlDbType.Int);
                        SupplierTermsParameter.Value = relationshipDetails.SupplierTerms;
                        SqlParameter IsSupplierParameter = sqlCommandToken.Parameters.Add("@IsSupplier", SqlDbType.Bit);
                        IsSupplierParameter.Value = relationshipDetails.IsSupplier;
                        SqlParameter IsSubcontractorParameter = sqlCommandToken.Parameters.Add("@IsSubcontractor", SqlDbType.Bit);
                        IsSubcontractorParameter.Value = relationshipDetails.IsSubcontractor;
                        SqlParameter IsClientParameter = sqlCommandToken.Parameters.Add("@IsClient", SqlDbType.Bit);
                        IsClientParameter.Value = relationshipDetails.IsClient;
                        SqlParameter IsAutoProgressReportParameter = sqlCommandToken.Parameters.Add("@IsAutoProgressReport", SqlDbType.Bit);
                        IsAutoProgressReportParameter.Value = relationshipDetails.IsAutoProgressReport;
                        SqlParameter DaysIdParameter = sqlCommandToken.Parameters.Add("@DaysId", SqlDbType.Int);
                        DaysIdParameter.Value = relationshipDetails.DayDetails.Id;
                        SqlParameter NextReportDateParameter = sqlCommandToken.Parameters.Add("@NextReportDate", SqlDbType.DateTime);
                        NextReportDateParameter.Value = relationshipDetails.NextReportDateTime;
                        SqlParameter ClientRatingIdParameter = sqlCommandToken.Parameters.Add("@ClientRatingId", SqlDbType.Int);
                        ClientRatingIdParameter.Value = relationshipDetails.RatingDetails.Id;
                        SqlParameter ExpenseAccountIdParameter = sqlCommandToken.Parameters.Add("@ExpenseAccountId", SqlDbType.Int);
                        ExpenseAccountIdParameter.Value = relationshipDetails.ExpenseAccount.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = (actionType == "NEW") ? "SET$NEW" : "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRelationshipDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetRelationshipDetails
        /// <summary>
        /// Getting the relationship details
        /// </summary>
        /// <returns>
        /// RelationshipDetails value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public RelationshipDetails GetRelationshipDetails(int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            RelationshipDetails relationshipDetails = new RelationshipDetails();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_RelationshipDetails_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            relationshipDetails = new RelationshipDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                OfficeJob = Convert.ToDouble(resultToken["OfficeJob"].ToString()),
                                WorkCredit = Convert.ToDouble(resultToken["WorkCredit"].ToString()),
                                PriceClassification = new PriceClassification()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_PriceClassificationsId"].ToString()),
                                    Name = "",
                                    Code = ""
                                },
                                ClientSize = new ClientSize()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_ClientSizesId"].ToString()),
                                    Code = "",
                                    Name = ""
                                },
                                ClientTermType = new TermType()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_Client_CM_TermTypesId"].ToString()),
                                    Code = "",
                                    Name = ""
                                },
                                ClientTerms = Convert.ToInt32(resultToken["ClientTerms"].ToString()),
                                DefaultDeposit = Convert.ToDouble(resultToken["DefaultDeposit"].ToString()),
                                MonthDayAlert = Convert.ToInt32(resultToken["MonthDayAlert"].ToString()),
                                FinancialNotes = resultToken["FinancialNotes"].ToString(),
                                SupplierTermType = new TermType()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_Supplier_CM_TermTypesId"].ToString()),
                                    Name = "",
                                    Code = ""
                                },
                                SupplierTerms = Convert.ToInt32(resultToken["SupplierTerms"].ToString()),
                                IsSupplier = Convert.ToBoolean(resultToken["IsSupplier"].ToString()),
                                IsSubcontractor = Convert.ToBoolean(resultToken["IsSubcontractor"].ToString()),
                                IsClient = Convert.ToBoolean(resultToken["IsClient"].ToString()),
                                IsAutoProgressReport = Convert.ToBoolean(resultToken["IsAutoProgressReport"].ToString()),
                                DayDetails = new DayDetails()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_DaysId"].ToString()),
                                    Code = "",
                                    Name = ""
                                },
                                NextReportDateTime = Convert.ToDateTime(resultToken["NextReportDateTime"].ToString()),
                                RatingDetails = new RatingDetails()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_Client_CM_Ratings"].ToString()),
                                    Code = "",
                                    Name = ""
                                },
                                ExpenseAccount = new AccountDetails()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_ExpenseAccount_CM_Account"].ToString()),
                                    Name = resultToken["AccountName"].ToString(),
                                    Total = 0
                                }
                            };
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetRelationshipDetails ! :" + ex);
            }

            // Return the values
            return relationshipDetails;
        }

        // SetNewHourlyOtherRatesDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// hourlyOtherRates -> HourlyOtherRates object
        /// </remarks>
        public int SetNewHourlyOtherRatesDetails(HourlyOtherRates hourlyOtherRates, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_HourlyOtherRates_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = hourlyOtherRates.Id;
                        SqlParameter RateNameParameter = sqlCommandToken.Parameters.Add("@RateName", SqlDbType.VarChar);
                        RateNameParameter.Value = hourlyOtherRates.RateName;
                        SqlParameter RateParameter = sqlCommandToken.Parameters.Add("@Rate", SqlDbType.Decimal);
                        RateParameter.Value = hourlyOtherRates.Rate;
                        SqlParameter RateTypeIdParameter = sqlCommandToken.Parameters.Add("@RateType", SqlDbType.VarChar);
                        RateTypeIdParameter.Value = hourlyOtherRates.RateType;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewHourlyOtherRatesDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetUpdateHourlyOtherRatesDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// hourlyOtherRates -> HourlyOtherRates object
        /// </remarks>
        public int SetUpdateHourlyOtherRatesDetails(HourlyOtherRates hourlyOtherRates, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_HourlyOtherRates_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = hourlyOtherRates.Id;
                        SqlParameter RateNameParameter = sqlCommandToken.Parameters.Add("@RateName", SqlDbType.VarChar);
                        RateNameParameter.Value = hourlyOtherRates.RateName;
                        SqlParameter RateParameter = sqlCommandToken.Parameters.Add("@Rate", SqlDbType.Decimal);
                        RateParameter.Value = hourlyOtherRates.Rate;
                        SqlParameter RateTypeIdParameter = sqlCommandToken.Parameters.Add("@RateType", SqlDbType.VarChar);
                        RateTypeIdParameter.Value = hourlyOtherRates.RateType;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = hourlyOtherRates.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateHourlyOtherRatesDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetRemoveHourlyOtherRatesDetails
        /// <summary>
        /// Setting the Social Media details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// sociamMediaId -> number
        /// </remarks>
        public int SetRemoveHourlyOtherRatesDetails(int hourlyOtherRatesId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_HourlyOtherRates_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = hourlyOtherRatesId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = hourlyOtherRatesId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveHourlyOtherRatesDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetHourlyOtherRateListDetails
        /// <summary>
        /// Getting the Social media list details
        /// </summary>
        /// <returns>
        /// SocialMedia list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        public List<HourlyOtherRates> GetHourlyOtherRateListDetails(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<HourlyOtherRates> hourlyOtherRatesList = new List<HourlyOtherRates>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_HourlyOtherRates_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            hourlyOtherRatesList.Add(new HourlyOtherRates()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                RateType = resultToken["RateType"].ToString(),
                                Rate = Convert.ToDouble(resultToken["Rate"].ToString()),
                                RateName = resultToken["RateName"].ToString(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetHourlyOtherRateListDetails ! :" + ex);
            }

            // Return the values
            return hourlyOtherRatesList;
        }

        // GetAllFilesList
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter object
        /// </remarks>
        public List<GlobalFileDetails> GetAllFilesList(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<GlobalFileDetails> globalFileDetailsList = new List<GlobalFileDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalFiles_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            globalFileDetailsList.Add(new GlobalFileDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                FileName = resultToken["FileName"].ToString(),
                                FileUrl = resultToken["FileUrl"].ToString(),
                                FileType = resultToken["FileType"].ToString(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString()),
                                LocalPath = resultToken["LocalPath"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetAllFilesList ! :" + ex);
            }

            // Return the values
            return globalFileDetailsList;
        }

        // RemoveGlobalFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// globalFileId -> number
        /// </remarks>
        public int RemoveGlobalFile(int globalFileId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = globalFileId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = globalFileId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_RemoveGlobalFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetGlobalFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// fileName -> string
        /// fileUrl -> string
        /// fileType -> string
        /// companyId -> number
        /// </remarks>
        public int SetGlobalFile(string fileName, string fileUrl, string fileType, ConnectionString connectionString, string localPath)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter FileNameParameter = sqlCommandToken.Parameters.Add("@FileName", SqlDbType.VarChar);
                        FileNameParameter.Value = fileName;
                        SqlParameter FileUrlParameter = sqlCommandToken.Parameters.Add("@FileUrl", SqlDbType.VarChar);
                        FileUrlParameter.Value = fileUrl;
                        SqlParameter FileTypeParameter = sqlCommandToken.Parameters.Add("@FileType", SqlDbType.VarChar);
                        FileTypeParameter.Value = fileType;
                        SqlParameter LocalPathParameter = sqlCommandToken.Parameters.Add("@LocalPath", SqlDbType.VarChar);
                        LocalPathParameter.Value = localPath;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetGlobalFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetAllResourceFiles
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public List<ResourceType> GetAllResourceFiles(int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ResourceType> resourceTypeList = new List<ResourceType>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ResourceTypes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            resourceTypeList.Add(new ResourceType()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Code = resultToken["Code"].ToString(),
                                Name = resultToken["Name"].ToString(),
                                TotalRecords = 0
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetAllResourceFiles ! :" + ex);
            }

            // Return the values
            return resourceTypeList;
        }

        // GetAllResourceFilesWithPagination
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// </remarks>
        public List<ResourceType> GetAllResourceFilesWithPagination(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ResourceType> resourceTypeList = new List<ResourceType>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ResourceTypes_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "ALL$WP";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            resourceTypeList.Add(new ResourceType()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Code = resultToken["Code"].ToString(),
                                Name = resultToken["Name"].ToString(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetAllResourceFiles ! :" + ex);
            }

            // Return the values
            return resourceTypeList;
        }

        // SetNewResourceDetails
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        public int SetNewResourceDetails(ResourceType resourceType, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ResourceTypes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter ResourceNameParameter = sqlCommandToken.Parameters.Add("@ResourceName", SqlDbType.VarChar);
                        ResourceNameParameter.Value = resourceType.Name;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewResourceDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetUpdateResourceDetails
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        public int SetUpdateResourceDetails(ResourceType resourceType, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ResourceTypes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter ResourceNameParameter = sqlCommandToken.Parameters.Add("@ResourceName", SqlDbType.VarChar);
                        ResourceNameParameter.Value = resourceType.Name;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = resourceType.Id;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = resourceType.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateResourceDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetRemoveResourceDetails
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// sociamMediaId -> number
        /// </remarks>
        public int SetRemoveResourceDetails(int resourceId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CM_ResourceTypes_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = resourceId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = resourceId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveResourceDetails ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetImageDocFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> string
        /// companyId -> string
        /// imageFiles -> ImageFiles Object
        /// </remarks>
        public int SetImageDocFile(ImageFiles imageFiles, int customerId, ConnectionString connectionString, string staffId)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ImageFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CaptionParameter = sqlCommandToken.Parameters.Add("@Caption", SqlDbType.VarChar);
                        CaptionParameter.Value = imageFiles.Caption;
                        SqlParameter ResourceFileParameter = sqlCommandToken.Parameters.Add("@ResourceFile", SqlDbType.VarChar);
                        ResourceFileParameter.Value = imageFiles.ResourceFile;
                        SqlParameter InternalNotesParameter = sqlCommandToken.Parameters.Add("@InternalNotes", SqlDbType.VarChar);
                        InternalNotesParameter.Value = imageFiles.InternalNotes;
                        SqlParameter ResourceTypeIdParameter = sqlCommandToken.Parameters.Add("@ResourceTypeId", SqlDbType.Int);
                        ResourceTypeIdParameter.Value = imageFiles.ResourceType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter StaffIdParameter = sqlCommandToken.Parameters.Add("@StaffId", SqlDbType.VarChar);
                        StaffIdParameter.Value = staffId;
                        SqlParameter LocalPathParameter = sqlCommandToken.Parameters.Add("@LocalPath", SqlDbType.VarChar);
                        LocalPathParameter.Value = imageFiles.LocalPath;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetImageDocFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetUpdateImageDocFile
        /// <summary>
        /// Getting all the global files
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> string
        /// companyId -> string
        /// imageFiles -> ImageFiles Object
        /// </remarks>
        public int SetUpdateImageDocFile(ImageFiles imageFiles, int customerId, ConnectionString connectionString, string staffId)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ImageFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CaptionParameter = sqlCommandToken.Parameters.Add("@Caption", SqlDbType.VarChar);
                        CaptionParameter.Value = imageFiles.Caption;
                        SqlParameter ResourceFileParameter = sqlCommandToken.Parameters.Add("@ResourceFile", SqlDbType.VarChar);
                        ResourceFileParameter.Value = imageFiles.ResourceFile;
                        SqlParameter InternalNotesParameter = sqlCommandToken.Parameters.Add("@InternalNotes", SqlDbType.VarChar);
                        InternalNotesParameter.Value = imageFiles.InternalNotes;
                        SqlParameter ResourceTypeIdParameter = sqlCommandToken.Parameters.Add("@ResourceTypeId", SqlDbType.Int);
                        ResourceTypeIdParameter.Value = imageFiles.ResourceType.Id;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = imageFiles.Id;
                        SqlParameter RotateXYParameter = sqlCommandToken.Parameters.Add("@RotateXY", SqlDbType.Int);
                        RotateXYParameter.Value = imageFiles.RotateXY;
                        SqlParameter StaffIdParameter = sqlCommandToken.Parameters.Add("@StaffId", SqlDbType.VarChar);
                        StaffIdParameter.Value = staffId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = imageFiles.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateImageDocFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // RemoveImageDocFile
        /// <summary>
        /// Removing the file
        /// </summary>
        /// <returns>
        /// GlobalFileDetails list value
        /// </returns>
        /// <remarks>
        /// customerId -> string
        /// companyId -> string
        /// imageFiles -> ImageFiles Object
        /// </remarks>
        public int RemoveImageDocFile(int imageFilesId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ImageFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        IdParameter.Value = imageFilesId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = imageFilesId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_RemoveImageDocFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetAllImageDocFiles
        /// <summary>
        /// Getting all the resource files
        /// </summary>
        /// <returns>
        /// ResourceType List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// filter -> Filter
        /// </remarks>
        public List<ImageFiles> GetAllImageDocFiles(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ImageFiles> imageFilesList = new List<ImageFiles>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ImageFiles_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter ResourceTypeIdParameter = sqlCommandToken.Parameters.Add("@ResourceTypeId", SqlDbType.Int);
                        ResourceTypeIdParameter.Value = filter.StatusId;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            imageFilesList.Add(new ImageFiles()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Caption = resultToken["Caption"].ToString(),
                                InternalNotes = resultToken["InternalNotes"].ToString(),
                                ResourceFile = resultToken["ResourceFile"].ToString(),
                                ResourceType = new ResourceType()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_ResourceTypesId"].ToString()),
                                    Code = resultToken["Code"].ToString(),
                                    Name = resultToken["Name"].ToString(),
                                    TotalRecords = 0
                                },
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString()),
                                RotateXY = Convert.ToInt32(resultToken["RotateXY"].ToString()),
                                CreatedByFullName = resultToken["CreatedByName"].ToString(),
                                AddedDate = Convert.ToDateTime(resultToken["AddedDate"].ToString()),
                                LocalPath = resultToken["LocalPath"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetAllImageDocFiles ! :" + ex);
            }

            // Return the values
            return imageFilesList;
        }

        // SetNewClientRequirement
        /// <summary>
        /// Setting the client requirement details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        public int SetNewClientRequirement(ClientRequirement clientRequirement, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirement.Id;
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar);
                        TitleParameter.Value = clientRequirement.Title;
                        SqlParameter AdditionalDataParameter = sqlCommandToken.Parameters.Add("@AdditionalData", SqlDbType.VarChar);
                        AdditionalDataParameter.Value = clientRequirement.AdditionalData;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewClientRequirement ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetUpdateClientRequirement
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        public int SetUpdateClientRequirement(ClientRequirement clientRequirement, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirement.Id;
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar);
                        TitleParameter.Value = clientRequirement.Title;
                        SqlParameter AdditionalDataParameter = sqlCommandToken.Parameters.Add("@AdditionalData", SqlDbType.VarChar);
                        AdditionalDataParameter.Value = clientRequirement.AdditionalData;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$UPD";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirement.Id;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetUpdateClientRequirement ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetRemoveClientRequirement
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        public int SetRemoveClientRequirement(int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirementId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV$CR";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveClientRequirement ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetClientRequirementFile
        /// <summary>
        /// Setting the client requirement details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        public int SetClientRequirementFile(string fileName, string fileUrl, string fileType, int clientRequirementId, ConnectionString connectionString, string localPath)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirementFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirementId;
                        SqlParameter FileNameParameter = sqlCommandToken.Parameters.Add("@FileName", SqlDbType.VarChar);
                        FileNameParameter.Value = fileName;
                        SqlParameter FileUrlParameter = sqlCommandToken.Parameters.Add("@FileUrl", SqlDbType.VarChar);
                        FileUrlParameter.Value = fileUrl;
                        SqlParameter FileTypeParameter = sqlCommandToken.Parameters.Add("@FileType", SqlDbType.VarChar);
                        FileTypeParameter.Value = fileType;
                        SqlParameter LocalPathParameter = sqlCommandToken.Parameters.Add("@LocalPath", SqlDbType.VarChar);
                        LocalPathParameter.Value = localPath;
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.Int);
                        ClientRequirementIdParameter.Value = clientRequirementId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetClientRequirementFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // RemoveClientRequirementFile
        /// <summary>
        /// Removing the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public int RemoveClientRequirementFile(int clientRequirementFileId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirementFiles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirementFileId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementFileId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_RemoveClientRequirementFile ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // UpdateClientRequirementRanking
        /// <summary>
        /// Updating the client requirement ranking
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public int UpdateClientRequirementRanking(int clientRequirementId, string moveDirection, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirementId;
                        SqlParameter RankDirectionParameter = sqlCommandToken.Parameters.Add("@RankDirection", SqlDbType.VarChar);
                        RankDirectionParameter.Value = moveDirection;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "UPD$RK";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementId;
                    }


                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_UpdateClientRequirementRanking ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetNewGlobalClientRequirement
        /// <summary>
        /// Setting the client requirement details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// resourceType -> ResourceType object
        /// </remarks>
        public int SetNewGlobalClientRequirement(ClientRequirement clientRequirement, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalClientRequirements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter TitleParameter = sqlCommandToken.Parameters.Add("@Title", SqlDbType.VarChar);
                        TitleParameter.Value = clientRequirement.Title;
                        SqlParameter AdditionalDataParameter = sqlCommandToken.Parameters.Add("@AdditionalData", SqlDbType.VarChar);
                        AdditionalDataParameter.Value = clientRequirement.AdditionalData;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }


                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetNewGlobalClientRequirement ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetRemoveGlobalClientRequirement
        /// <summary>
        /// Setting the Resource details
        /// </summary>
        /// <returns>
        /// int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        public int SetRemoveGlobalClientRequirement(int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalClientRequirements_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = clientRequirementId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetRemoveGlobalClientRequirement ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetGlobalClientRequirement
        /// <summary>
        /// Setting the client requirement
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public List<ClientRequirement> GetGlobalClientRequirement(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ClientRequirement> clientRequirementList = new List<ClientRequirement>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalClientRequirements_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            clientRequirementList.Add(new ClientRequirement()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                AdditionalData = resultToken["AdditionalData"].ToString(),
                                Title = resultToken["Title"].ToString(),
                                ClientRequirementFiles = new List<ClientRequirementFile>(),
                                RoleDetails = new List<RoleDetails>(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetGlobalClientRequirement ! :" + ex);
            }

            // Return the values
            return clientRequirementList;
        }

        // GetClientRequirement
        /// <summary>
        /// Setting the client requirement
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public List<ClientRequirement> GetClientRequirement(Filter filter, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ClientRequirement> clientRequirementList = new List<ClientRequirement>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirements_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter RecordsPerPageParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageParameter.Value = filter.RecordsPerPage;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            clientRequirementList.Add(new ClientRequirement()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                AdditionalData = resultToken["AdditionalData"].ToString(),
                                Title = resultToken["Title"].ToString(),
                                ClientRequirementFiles = new List<ClientRequirementFile>(),
                                RoleDetails = new List<RoleDetails>(),
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetClientRequirement ! :" + ex);
            }

            // Return the values
            return clientRequirementList;
        }

        // GetClientRequirement
        /// <summary>
        /// Setting the client requirement
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public List<ClientRequirementFile> GetClientRequirementFiles(int clientRequirementId, ConnectionString connectionString)
        {
            // Declare the value list
            List<ClientRequirementFile> clientRequirementFileList = new List<ClientRequirementFile>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirementFiles_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@Id", SqlDbType.BigInt);
                        CustomerIdParameter.Value = clientRequirementId;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET$CRF";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            clientRequirementFileList.Add(new ClientRequirementFile()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                FileName = resultToken["FileName"].ToString(),
                                FileType = resultToken["FileType"].ToString(),
                                FileUrl = resultToken["FileUrl"].ToString(),
                                LocalPath = resultToken["LocalPath"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetClientRequirementFiles ! :" + ex);
            }

            // Return the values
            return clientRequirementFileList;
        }

        // SetClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public int SetClientRequirementRole(int roleId, int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirementRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.Int);
                        ClientRequirementIdParameter.Value = clientRequirementId;
                        SqlParameter RoleIdParameter = sqlCommandToken.Parameters.Add("@RoleId", SqlDbType.Int);
                        RoleIdParameter.Value = roleId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetClientRequirementRole ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // SetClientRequiSetGlobalClientRequirementRolerementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public int SetGlobalClientRequirementRole(int roleId, int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalClientRequirementRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.Int);
                        ClientRequirementIdParameter.Value = clientRequirementId;
                        SqlParameter RoleIdParameter = sqlCommandToken.Parameters.Add("@RoleId", SqlDbType.Int);
                        RoleIdParameter.Value = roleId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "SET$NEW";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            newId = Convert.ToInt32(resultToken["NewId"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_SetGlobalClientRequirementRole ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // RemoveClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public int RemoveClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirementRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.Int);
                        ClientRequirementIdParameter.Value = clientRequirementId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV$ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_RemoveClientRequirementRole ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // RemoveGlobalClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// actionType -> string
        /// clientRequirement -> ClientRequirement
        /// </remarks>
        public int RemoveGlobalClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            int newId = 0;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalClientRequirementRoles_Set", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.Int);
                        ClientRequirementIdParameter.Value = clientRequirementId;
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "RMV$ALL";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        newId = clientRequirementId;
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_RemoveGlobalClientRequirementRole ! :" + ex);
            }

            // Return the values
            return newId;
        }

        // GetClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// RoleDetails List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        public List<RoleDetails> GetClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<RoleDetails> roleDetailsList = new List<RoleDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_ClientRequirementRoles_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.BigInt);
                        ClientRequirementIdParameter.Value = clientRequirementId;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            roleDetailsList.Add(new RoleDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Code = resultToken["Code"].ToString(),
                                Name = resultToken["Name"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetClientRequirementRole ! :" + ex);
            }

            // Return the values
            return roleDetailsList;
        }

        // GetGlobalClientRequirementRole
        /// <summary>
        /// Setting the client requirement file
        /// </summary>
        /// <returns>
        /// RoleDetails List value
        /// </returns>
        /// <remarks>
        /// customerId -> number
        /// companyId -> number
        /// clientRequirementId -> number
        /// </remarks>
        public List<RoleDetails> GetGlobalClientRequirementRole(int clientRequirementId, int customerId, ConnectionString connectionString)
        {
            // Declare the value list
            List<RoleDetails> roleDetailsList = new List<RoleDetails>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_GlobalClientRequirementRoles_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter CustomerIdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.BigInt);
                        CustomerIdParameter.Value = customerId;
                        SqlParameter ClientRequirementIdParameter = sqlCommandToken.Parameters.Add("@ClientRequirementId", SqlDbType.BigInt);
                        ClientRequirementIdParameter.Value = clientRequirementId;

                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            roleDetailsList.Add(new RoleDetails()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Code = resultToken["Code"].ToString(),
                                Name = resultToken["Name"].ToString()
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetGlobalClientRequirementRole ! :" + ex);
            }

            // Return the values
            return roleDetailsList;
        }

        // GetAllSocialMediaList
        /// <summary>
        /// Get all the SocialMedia list
        /// </summary>
        /// <returns>
        /// SocialMedia object list
        /// </returns>
        /// <remarks>
        /// clientId -> number
        /// companyId -> number
        /// </remarks>
        public List<SocialMedia> GetAllSocialMediaList(Filter filter, int clientId, ConnectionString connectionString)
        {
            // Declare the value list
            List<SocialMedia> socialMediaList = new List<SocialMedia>();

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("CL_SocialMedias_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter IdParameter = sqlCommandToken.Parameters.Add("@CustomerId", SqlDbType.Int);
                        IdParameter.Value = clientId;
                        SqlParameter CurrentPageParameter = sqlCommandToken.Parameters.Add("@CurrentPage", SqlDbType.Int);
                        CurrentPageParameter.Value = filter.CurrentPage;
                        SqlParameter RecordsPerPageValueParameter = sqlCommandToken.Parameters.Add("@RecordsPerPage", SqlDbType.Int);
                        RecordsPerPageValueParameter.Value = filter.RecordsPerPage;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "GET";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            socialMediaList.Add(new SocialMedia()
                            {
                                Id = Convert.ToInt32(resultToken["Id"].ToString()),
                                Setting = resultToken["Setting"].ToString(),
                                SocialMediaType = new SocialMediaType()
                                {
                                    Id = Convert.ToInt32(resultToken["FK_CM_SocialMediaTypesId"].ToString()),
                                    Name = resultToken["SocialMediaName"].ToString(),
                                    Code = resultToken["SocialMediaCode"].ToString()
                                },
                                TotalRecords = Convert.ToInt32(resultToken["TotalRecords"].ToString())
                            });
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in ClientDataAccess_GetAllSocialMediaList ! :" + ex);
            }

            // Return the values
            return socialMediaList;
        }

        // CheckEmailExists
        /// <summary>
        /// 
        /// Check if the email exists
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// userEmail -> string
        /// </remarks>
        public bool CheckEmailExists(string userEmail, ConnectionString connectionString)
        {
            // Declare the token
            bool status = false;

            try
            {
                //Setting the SQL connection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString.DatabaseConfig))
                {
                    // Openning the connection
                    connection.Open();

                    // Check Token expired
                    using (SqlCommand sqlCommandToken = new SqlCommand("User_Get", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter EmailParameter = sqlCommandToken.Parameters.Add("@Email", SqlDbType.VarChar, 500);
                        EmailParameter.Value = userEmail;
                        // Adding stored procedure parameters
                        SqlParameter UserParameter = sqlCommandToken.Parameters.Add("@Action", SqlDbType.VarChar, 50);
                        UserParameter.Value = "EML$EXS";

                        // Executing the sql SP command
                        var resultToken = sqlCommandToken.ExecuteReader();

                        while (resultToken.Read())
                        {
                            status = Convert.ToBoolean(resultToken["Valid"].ToString());
                        }
                    }

                    // Closing the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in CommonDataAccess_CheckEmailExists ! :" + ex);
            }

            // Return the token
            return status;
        }

    }
}
