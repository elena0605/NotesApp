using Newtonsoft.Json;
using NotesConsoleClient.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace NotesConsoleClient
{
    public class NotesAppService
    {
        private HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7143";
        private string? _token;

        public NotesAppService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task UserloginAsync(string username, string password)
        {
            var loginRequestDto =  new LoginRequest(username, password);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/users/login", loginRequestDto);

            if(response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                
                dynamic? jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);

                _token = jsonResponse?.token;
            }
            else
            {
                throw new Exception("\n\n\tInvalid login attempt!");
            }
        }

        public async Task GetNotesAsync()
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new Exception("Authentication Token is missing. Please log in first");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            HttpResponseMessage response = await _httpClient.GetAsync("/api/notes");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<NoteResponse>? notes = JsonConvert.DeserializeObject<List<NoteResponse>>(responseBody);

                notes?.PrintNotes();
            }
            else
            {
                throw new Exception("Notes request failed!");
            }
        }

    }
}
