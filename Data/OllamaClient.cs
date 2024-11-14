namespace OllamaBlazorApp
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using OllamaBlazorApp.Data;


    public class OllamaClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _modelName;
        private readonly Logger _logger;

        public OllamaClient(string baseUrl, string modelName, Logger logger)
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5) // Increased timeout
            };
            _baseUrl = baseUrl;
            _modelName = modelName;
            _logger = logger;
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            try
            {
                _logger.Log("Starting GetChatResponseAsync");
                var requestUrl = $"{_baseUrl}/generate"; // Correct endpoint
                var payload = new { model = _modelName, prompt = prompt };

                _logger.Log($"Sending request to {requestUrl} with payload: {JObject.FromObject(payload)}");
                var content = new StringContent(JObject.FromObject(payload).ToString(), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(requestUrl, content);
                response.EnsureSuccessStatusCode();
                _logger.Log("Request sent successfully");

                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.Log($"Response received: {responseContent}");

                // Process response which could be in chunks
                var fullResponse = "";
                foreach (var line in responseContent.Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var jsonLine = JObject.Parse(line);
                        var messageContent = jsonLine["response"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(messageContent))
                        {
                            fullResponse += messageContent;
                        }
                    }
                }

                if (string.IsNullOrEmpty(fullResponse))
                {
                    throw new Exception("Received empty message content from the API.");
                }

                _logger.Log("GetChatResponseAsync completed successfully");
                return fullResponse;
            }
            catch (Exception ex)
            {
                _logger.Log($"Error in GetChatResponseAsync: {ex.Message}");
                throw;
            }
        }
    }
}
