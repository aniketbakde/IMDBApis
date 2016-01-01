using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IMDBApis
{
    public class ImdbClient
    {
        private const string ApiBaseUrl = "http://www.omdbapi.com/?t";

        public async Task<ImdbResponse> GetData(string movieTitle)
        {
            ImdbResponse imdbResponse = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(ApiBaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("?t=" + movieTitle);
                if (response.IsSuccessStatusCode)
                {
                    imdbResponse = await response.Content.ReadAsAsync<ImdbResponse>();
                }
            }
            return imdbResponse;
        }
    }

    public class ImdbResponse
    {
        public string Title;
        public string Year;
        public string ImdbRating;
        public string ImdbId;
        public bool Response;
    }
}
