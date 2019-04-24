namespace RecruitingWeb.Components.HttpClient
{
    public static class HttpClientGlobal
    {
         public static System.Net.Http.HttpClient client { get; set; }

        static HttpClientGlobal()
        {
            client = new System.Net.Http.HttpClient();
        }
    }
}