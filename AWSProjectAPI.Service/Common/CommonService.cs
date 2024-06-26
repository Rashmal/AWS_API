using AWSProjectAPI.Core.Authentication;
using AWSProjectAPI.Core.Common;
using AWSProjectAPI.DataAccess.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Service.Common
{
    public class CommonService : ICommonService
    {
        #region Private Properties
        private readonly ICommonDataAccess iCommonDataAccess;
        #endregion

        // Constructor
        public CommonService(ICommonDataAccess iCommonDataAccess)
        {
            this.iCommonDataAccess = iCommonDataAccess;
        }

        // CheckEmailExists
        /// <summary>
        /// Check if the email exists
        /// </summary>
        /// <returns>
        /// boolean value
        /// </returns>
        /// <remarks>
        /// userEmail -> string
        /// </remarks>
        public bool CheckEmailExists(string userEmail)
        {
            return iCommonDataAccess.CheckEmailExists(userEmail);
        }

        // GetPriorityList
        /// <summary>
        /// Getting the priority list
        /// </summary>
        /// <returns>
        /// Priority object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Priority> GetPriorityList(int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return iCommonDataAccess.GetPriorityList(connectionString);
        }

        // GetStatusList
        /// <summary>
        /// Getting the status list
        /// </summary>
        /// <returns>
        /// Status object list value
        /// </returns>
        /// <remarks>
        /// moduleCode -> string value
        /// </remarks>
        public List<Status> GetStatusList(string moduleCode, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return iCommonDataAccess.GetStatusList(moduleCode, connectionString);
        }

        // GetModuleList
        /// <summary>
        /// Getting the module list
        /// </summary>
        /// <returns>
        /// Module object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetModuleList(int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return iCommonDataAccess.GetModuleList(connectionString);
        }

        // GetAllStaffList
        /// <summary>
        /// Getting all the staff list
        /// </summary>
        /// <returns>
        /// BasicUserDetails object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<BasicUserDetails> GetAllStaffList(int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            return iCommonDataAccess.GetAllStaffList(connectionString);
        }

        // TotalGlobalNotes
        /// <summary>
        /// Getting the total of global notes
        /// </summary>
        /// <returns>
        /// Int value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public int TotalGlobalNotes(string tabSection, string userId, int companyId)
        {
            // Declare the count
            int totalCount = 0;

            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");

            // Check the tab section
            switch (tabSection.ToUpper())
            {
                case "TOTAL":
                    totalCount = iCommonDataAccess.TotalGlobalNotes(userId, connectionString);
                    break;
                case "SE":
                    totalCount = iCommonDataAccess.TotalSE(userId, connectionString);
                    break;
                case "BGF":
                    totalCount = iCommonDataAccess.TotalBG(userId, connectionString);
                    break;
            }
            // End of Check the tab section

            // Return the count
            return totalCount;
        }

        // SendEmailLocally
        /// <summary>
        /// Sending the emails 
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public string SendEmailLocally(EmailBodyDetails emailDetails)
        {
            string returnValue = "FAIL";

            try
            {
                // ---------------- smtp gmail info ----------------------
                // -- Email: iitcglobalmail@gmail.com
                // -- Pass: iitc@963#
                // ---------------- End of smtp gmail info ----------------------
                // Declaring the smtp client
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("iitcglobalmail@gmail.com", "bbhs nvtm kohf kwhm"),
                    EnableSsl = true
                };


                // Declaring the mail message
                MailMessage _mail = new MailMessage();

                // Setting the mail from
                _mail.From = new MailAddress(emailDetails.FromAddress.Address, emailDetails.FromAddress.Name);

                // Looping the to list
                for (int i = 0; i < emailDetails.ToAddressList.Count; i++)
                {
                    // Adding to the mail
                    if (emailDetails.ToAddressList[i].Address != null)
                    {
                        _mail.To.Add(emailDetails.ToAddressList[i].Address);
                    }
                    // End of Adding to the mail
                }
                // End of Looping the to list

                // Looping the cc list
                for (int i = 0; i < emailDetails.CCAddressList.Count; i++)
                {
                    // Adding to the mail
                    if (emailDetails.CCAddressList[i].Address != null)
                    {
                        _mail.CC.Add(emailDetails.CCAddressList[i].Address);
                    }
                    // End of Adding to the mail
                }
                // End of Looping the cc list

                // Looping the bcc list
                for (int i = 0; i < emailDetails.BCCAddressList.Count; i++)
                {
                    // Adding to the mail
                    if (emailDetails.BCCAddressList[i].Address != null)
                    {
                        _mail.Bcc.Add(emailDetails.BCCAddressList[i].Address);
                    }
                    // End of Adding to the mail
                }
                // End of Looping the bcc list

                // Setting the email subject
                _mail.Subject = (emailDetails.Subject == null) ? "Default Subject" : emailDetails.Subject;

                // Setting the body content
                _mail.Body = emailDetails.Content;

                _mail.IsBodyHtml = true;

                // Setting the attachments
                for (int i = 0; i < emailDetails.AttachmentPath.Count; i++)
                {
                    Attachment attachment = new Attachment(emailDetails.AttachmentPath[i]);
                    _mail.Attachments.Add(attachment);
                }

                _smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                string userState = "test message1";

                // Sending the email
                _smtpClient.SendAsync(_mail, userState);

                returnValue = "OK";

            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
                throw new Exception("Error in GetBasicUserDetails ! :" + ex);
            }

            return returnValue;
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
        }


        // SendEmail
        /// <summary>
        /// Sending the emails 
        /// </summary>
        /// <returns>
        /// string value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public string SendEmail(EmailBodyDetails internelEmailObject)
        {
            string emailResponse = "";
            //Sent email
            string email = JsonConvert.SerializeObject(internelEmailObject);
            var stringContent = new StringContent(email, UnicodeEncoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            //var response = client.PostAsync("http://myemail.expertential.net/SMTP/api/Email/SendMail", stringContent).Result;
            //var response = client.PostAsync("http://192.168.31.110:8082/BulkEmailWAPI/api/Email/SendMail", stringContent).Result;
            var response = client.PostAsync("https://localhost:7194/api/Email/SendMail", stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                string str = response.Content.ReadAsStringAsync().Result;

                emailResponse = str.ToString();

                if (str.ToString() == "Successfully Sent")
                {
                    //LogError.LogErrorDetails(str.ToString(), 2);
                    Console.WriteLine(str.ToString());
                }
                else
                {
                    //LogError.LogErrorDetails(str.ToString(), 2);
                    Console.WriteLine(str.ToString());
                }

            }
            else
            {
                // LogError.LogErrorDetails(response.ReasonPhrase.ToString(), 1);
                Console.WriteLine(response.ReasonPhrase.ToString());
            }
            client.Dispose();

            return emailResponse;
        }

        // GetModuleListBasedUserRole
        /// <summary>
        /// Getting the module list based on user role
        /// </summary>
        /// <returns>
        /// Module object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetModuleListBasedUserRole(string userRole, bool isStatic, int companyId, string userId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            // Getting the module list based on the role code
            List<Module> modulesList = iCommonDataAccess.GetModuleListBasedUserRole(userRole, isStatic, connectionString);
            // Getting the module for the user ID
            List<Module> modulesListByUser = iCommonDataAccess.GetAllModulesByUserId(userId, connectionString);
            // Declaring the list
            List<Module> returnignList = new List<Module>();
            // Loop through the modules list
            for (int i = 0; i < modulesList.Count; i++)
            {
                // Check if the module exists
                int moduleIndex = modulesListByUser.FindIndex(obj => obj.ModuleCode.ToUpper() == modulesList[i].ModuleCode.ToUpper());
                // Check if the index is not -1
                if (moduleIndex != -1)
                {
                    returnignList.Add(modulesList[i]);
                }
                // End of Check if the index is not -1
            }
            // End of Loop through the modules list

            // Return the list
            return returnignList;
        }

        // GetAccessListBasedUserRole
        /// <summary>
        /// Getting all the access list based on the user role
        /// </summary>
        /// <returns>
        /// UserRoleAccessDetail object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<UserRoleAccessDetail> GetAccessListBasedUserRole(string userRole, int companyId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            return iCommonDataAccess.GetAccessListBasedUserRole(userRole, connectionString);
        }

        // Getting all the access list based on the user role for view
        /// <summary>
        /// Getting the module list based on user role
        /// </summary>
        /// <returns>
        /// Module object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Module> GetViewAccessListBasedUserRole(string userRole, int companyId, string userId)
        {
            // Getting the Connection string
            ConnectionString connectionString = iCommonDataAccess.GetConnectionString(companyId, "AWS");
            // Getting the module list based on the role code
            List<Module> modulesList = iCommonDataAccess.GetViewAccessListBasedUserRole(userRole, connectionString);
            // Getting the module for the user ID
            List<Module> modulesListByUser = iCommonDataAccess.GetAllModulesByUserId(userId, connectionString);
            // Declaring the list
            List<Module> returnignList = new List<Module>();
            // Loop through the modules list
            for (int i = 0; i < modulesList.Count; i++)
            {
                // Check if the module exists
                int moduleIndex = modulesListByUser.FindIndex(obj => obj.ModuleCode.ToUpper() == modulesList[i].ModuleCode.ToUpper());
                // Check if the index is not -1
                if (moduleIndex != -1)
                {
                    returnignList.Add(modulesList[i]);
                }
                // End of Check if the index is not -1
            }
            // End of Loop through the modules list

            // Return the list
            return returnignList;
        }

        // GetAccountDetails
        /// <summary>
        /// Getting all the account details
        /// </summary>
        /// <returns>
        /// AccountDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<AccountDetails> GetAccountDetails(Filter filter)
        {
            return iCommonDataAccess.GetAccountDetails(filter);
        }

        // GetAllBusinessNumberTypes
        /// <summary>
        /// Getting all the business number type details
        /// </summary>
        /// <returns>
        /// BusinessNumberType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<BusinessNumberType> GetAllBusinessNumberTypes()
        {
            return iCommonDataAccess.GetAllBusinessNumberTypes();
        }

        // GetAllClientSizes
        /// <summary>
        /// Getting all the client size details
        /// </summary>
        /// <returns>
        /// ClientSize object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ClientSize> GetAllClientSizes()
        {
            return iCommonDataAccess.GetAllClientSizes();
        }

        // GetAllContactTypes
        /// <summary>
        /// Getting all the contact type details
        /// </summary>
        /// <returns>
        /// ContactType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ContactType> GetAllContactTypes()
        {
            return iCommonDataAccess.GetAllContactTypes();
        }

        // GetAllCountries
        /// <summary>
        /// Getting all the country details
        /// </summary>
        /// <returns>
        /// Country object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<Country> GetAllCountries()
        {
            return iCommonDataAccess.GetAllCountries();
        }

        // GetAllDays
        /// <summary>
        /// Getting all the day details
        /// </summary>
        /// <returns>
        /// DayDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<DayDetails> GetAllDays()
        {
            return iCommonDataAccess.GetAllDays();
        }

        // GetAllPriceClassifications
        /// <summary>
        /// Getting all the price classfication details
        /// </summary>
        /// <returns>
        /// PriceClassification object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<PriceClassification> GetAllPriceClassifications()
        {
            return iCommonDataAccess.GetAllPriceClassifications();
        }

        // GetAllRatings
        /// <summary>
        /// Getting all the rating details
        /// </summary>
        /// <returns>
        /// RatingDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<RatingDetails> GetAllRatings()
        {
            return iCommonDataAccess.GetAllRatings();
        }

        // GetAllSocialMediaTypes
        /// <summary>
        /// Getting all the social media type details
        /// </summary>
        /// <returns>
        /// SocialMediaType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<SocialMediaType> GetAllSocialMediaTypes()
        {
            return iCommonDataAccess.GetAllSocialMediaTypes();
        }

        // GetAllTermTypes
        /// <summary>
        /// Getting all the term type details
        /// </summary>
        /// <returns>
        /// TermType object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<TermType> GetAllTermTypes()
        {
            return iCommonDataAccess.GetAllTermTypes();
        }

        // GetAllRoleDetails
        /// <summary>
        /// Getting all the role details
        /// </summary>
        /// <returns>
        /// RoleDetails object List value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<RoleDetails> GetAllRoleDetails()
        {
            return iCommonDataAccess.GetAllRoleDetails();
        }

        // GetConnectionString
        /// <summary>
        /// Getting all the connection details
        /// </summary>
        /// <returns>
        /// ConnectionString object value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public ConnectionString GetConnectionString(int parentGroupId, string moduleCode)
        {
            return iCommonDataAccess.GetConnectionString(parentGroupId, moduleCode);
        }

        // GetAllParentGroupsDetailsByEmail
        /// <summary>
        /// Getting all the parent groups by email
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ParentGroup> GetAllParentGroupsDetailsByEmail(string email)
        {
            return iCommonDataAccess.GetAllParentGroupsDetailsByEmail(email);
        }

        // GetAllParentGroupsDetailsById
        /// <summary>
        /// Getting all the parent groups by id
        /// </summary>
        /// <returns>
        /// ParentGroup object list value
        /// </returns>
        /// <remarks>
        /// -
        /// </remarks>
        public List<ParentGroup> GetAllParentGroupsDetailsById(string userId)
        {
            return iCommonDataAccess.GetAllParentGroupsDetailsById(userId);
        }

       
    }
}
