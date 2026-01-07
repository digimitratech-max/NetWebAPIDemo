using Newtonsoft.Json;
using StudentRegistration.Business.Models;
using StudentRegistration.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BModel = StudentRegistration.Business.Models;

namespace StudentRegistration.Business.Services
{
    public class AccountService
    {

        private static readonly HttpClient client = new HttpClient();

        public static async Task<ApiResponse<List<BModel.UserProfile>>> GetUserProfileAsync(string apiUrl)
        {
            try
            {
                // Make the HTTP GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the JSON response content
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into the UserProfile object
                    var userProfile = JsonConvert.DeserializeObject<List<BModel.UserProfile>>(jsonResponse);

                    return new ApiResponse<List<BModel.UserProfile>>
                    {
                        Message = "User profile retrieved successfully.",
                        Success = true,
                        Data = userProfile
                    };
                }
                else
                {
                    return new ApiResponse<List<BModel.UserProfile>>
                    {
                        Message = "Error while fetching users data.",
                        Success = false,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<BModel.UserProfile>>
                {
                    Message = ex.Message,
                    Success = false,
                    Data = null
                };
            }
        }


    }
}
