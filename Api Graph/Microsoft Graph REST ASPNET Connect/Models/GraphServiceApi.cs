/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Microsoft_Graph_REST_ASPNET_Connect.Models
{
    public class GraphServiceApi
    {
        // Get the current user's email address from their profile.
        public async Task<string> GetMyEmailAddress(string accessToken)
        {

            // Get the current user. 
            // The app only needs the user's email address, so select the mail and userPrincipalName properties.
            // If the mail property isn't defined, userPrincipalName should map to the email for all account types. 
            string endpoint = "https://graph.microsoft.com/v1.0/me";
            //string endpoint = "https://graph.microsoft.com/v1.0/'users/mangeloa@everis.com'";

            string queryParameter = "?$select=mail,userPrincipalName";
            UserInfo me = new UserInfo();

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint + queryParameter))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    // This header has been added to identify our sample in the Microsoft Graph service. If extracting this code for your project please remove.
                    request.Headers.Add("SampleID", "aspnet-connect-rest-sample");

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                            me.Address = !string.IsNullOrEmpty(json.GetValue("mail").ToString()) ? json.GetValue("mail").ToString() : json.GetValue("userPrincipalName").ToString();
                        }
                        return me.Address?.Trim();
                    }
                }
            }
        }
    }
}