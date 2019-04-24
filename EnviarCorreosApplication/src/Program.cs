using EnviarCorreosApplication.Components.HttpClient;
using EnviarCorreosApplication.Model;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;

namespace EnviarCorreosApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string userName = appSettings.Get("Username");
            string password = appSettings.Get("Password");
            string ruta = ConfigurationManager.AppSettings["rutaEverisEnviarCorreos"];
            var client = new HttpClient();                       
            var user = new UserViewModel()
            {
                Username = userName,
                Password = password
            };

            try
            {
                Console.WriteLine("Ejecutando servicio de correos...");
                var response = HttpClientGlobal.client.PostAsJsonAsync(ruta, user).GetAwaiter().GetResult();//Con GetAwaiter podemos realizar nuestra llamada de forma sínscrona.
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                agregarALogTexto(result);                    
            }
            catch(Exception ex)
            {
                agregarALogTexto(ex.Message);
                
            }
            

        }

        private static void agregarALogTexto(string texto)
        {
            texto = texto + "\t " + DateTime.Now;
            const string nombreFicheroLog = "LogEnvios.txt";
            string rutaFicheroLog = string.Concat(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "\\", nombreFicheroLog);

            rutaFicheroLog = rutaFicheroLog.Replace("file:", "").Remove(0, 1);

            //si hay un fichero log del mes pasado se elimina
            if (File.Exists(rutaFicheroLog) && File.GetCreationTime(@rutaFicheroLog).Month < DateTime.Now.Month)
            {
                File.Delete(rutaFicheroLog);

            }

            StreamWriter WriteReportFile = File.AppendText(@rutaFicheroLog);
            WriteReportFile.WriteLine(texto);
            WriteReportFile.Close();



        }


    }
}
