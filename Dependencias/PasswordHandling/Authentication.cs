using Azure;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Dependencias;

namespace Dependencias.PasswordHandling
{
    public class Authentication
    {
        private static string currentemail;

        public string ActiveEmail { get => currentemail; }

        HashCreator passwordhasher = new HashCreator();
        Regex EmailPattern = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");

        //Login Auth
        public bool SintaxVerifier(string string1, string string2)
        {
            if (!string1.IsNullOrEmpty() & !string2.IsNullOrEmpty())
            {
                return true;
            }
            return false;
        }


        public bool PasswordChecksum(string password)
        {
            if (password.Length >= 8)
            {
                return true;
            }
            return false;
        }

        //Register Auth
        public bool PasswordIsMatch(string password, string confPassword)
        {
            //Verifies if strings that passes thru are not null or empty
            if (SintaxVerifier(password, confPassword))
            {
                //Verifies if both Passwords comply to the "not less than 8 digits rule"
                if (PasswordChecksum(password) & PasswordChecksum(confPassword))
                {
                    //Verifies if both passwords are the same
                    if (password.Equals(confPassword))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EmailSintaxVerifier(string email)
        {

            if (EmailPattern.IsMatch(email))
            {
                return true;
            }
            return false;
        }

        //LOG IN CHECKSUMS

        public async Task<bool> LogInChechsum(string Username, string password)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    Uri APIUrl = new Uri($"https://localhost:7274/ApiTienda/Users/{Username}");
                    var Response = client.GetAsync(APIUrl).Result;


                    if (Response.IsSuccessStatusCode == true)
                    {
                        var output = Response.Content.ReadAsStringAsync().Result;
                        UserScheme DeserializedUser = JsonSerializer.Deserialize<UserScheme>(output);
                        currentemail = DeserializedUser.email;

                        if (passwordhasher.EncryptPassword(password))
                        {
                            return passwordhasher.CompareHash(passwordhasher.FinalHash, DeserializedUser.password);
                        }
                    }


                }
            }
            catch (Exception)
            {
                return false;

                throw;
            }



            return false;
        }

        //Register Checksums

        public async Task<bool> RegistrationChecksum(string Username, string Email, string Password, string confPassword)
        {
            HashCreator hasher = new HashCreator();
            Uri APIUrl = new Uri("https://localhost:7274/ApiTienda/Users/");
            if (SintaxVerifier(Username, Email))
            {
                if (EmailSintaxVerifier(Email) & PasswordIsMatch(Password, confPassword))
                {
                    if (hasher.EncryptPassword(confPassword))
                    {
                        //Proceding with User Registration.
                        using (HttpClient client = new HttpClient())
                        {

                            try
                            {
                                var string2 = JsonSerializer.Serialize(new UserScheme
                                {
                                    userName = Username,
                                    email = Email,
                                    password = hasher.FinalHash

                                });
                                var content = new StringContent(string2, Encoding.UTF8, "application/json");

                                var Response = client.PostAsync(APIUrl, content).Result;

                                if (Response.IsSuccessStatusCode == true)
                                {
                                    currentemail = Email;
                                    return true;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error de respuesta en la API");
                                throw;
                            }

                        }
                    }

                }

            }
            return false;
        }

    }
}