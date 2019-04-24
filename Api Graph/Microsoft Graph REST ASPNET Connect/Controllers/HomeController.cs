/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft_Graph_REST_ASPNET_Connect.Helpers;
using Microsoft_Graph_REST_ASPNET_Connect.Models;
using Resources;
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft_Graph_REST_ASPNET_Connect.Models.Messages;
using Microsoft_Graph_REST_ASPNET_Connect.Models.Messages.FindMeetingTimeRequest;
using Microsoft_Graph_REST_ASPNET_Connect.Models.Messages.FindMeetingTimeResponse;
using System.Text;
using Microsoft_Graph_REST_ASPNET_Connect.Models.Messages.FindRoomsListResponse;
using System.Web;
using Recruiting.Application.Graph.Services;

namespace Microsoft_Graph_REST_ASPNET_Connect.Controllers
{
    public class HomeController : Controller
    { 
        GraphServiceApi graphServiceApi = new GraphServiceApi();
        GraphService _graphService = new GraphService();    

        public ActionResult Index()
        {
            return View("Graph", new GraphModel()
            {
                Salas = new List<Sala>() { new Sala()
                {
                    Email = "", Name = "No hay salas cargadas"
                }
            }
            });
        }


        [Authorize]
        // Get the current user's email address from their profile.
        public async Task<ActionResult> GetMyEmailAddress()
        {
            try
            {

                // Get an access token.
                string accessToken = await SampleAuthProvider.Instance.GetUserAccessTokenAsync();                
                // Get the current user's email address. 
                var email = await graphServiceApi.GetMyEmailAddress(accessToken);
                _graphService.SaveToken(email, accessToken);

                ViewBag.Resultado = "Actualizado";
                
                
                return View("Graph", new GraphModel());

            }
            catch (Exception e)
            {
                if (e.Message == "Caller needs to authenticate.") return new EmptyResult();
                return RedirectToAction("Index", "Error", new { message = "Error in " + Request.RawUrl + ": " + e.Message });
            }
        }
        public string GetToken(UserCredentials user)
        {
            var usernameApi = System.Configuration.ConfigurationManager.AppSettings["username"];
            var passwordApi = System.Configuration.ConfigurationManager.AppSettings["password"];

            if (user.UserName == usernameApi && user.Password == passwordApi)
            {
                var token = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\nkt.txt");
                token = Base64Decode(token);
                return token;
            }

            return null;
        }


        public ActionResult About()
        {
            return View();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


    }
}