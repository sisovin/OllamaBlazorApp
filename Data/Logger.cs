namespace OllamaBlazorApp.Data
{
    using System;
    using System.IO;

    public class Logger
    {
        private readonly string logFilePath;
        private readonly string chatHistoryFilePath;

        public Logger(string logDirectory)
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            logFilePath = Path.Combine(logDirectory, "logregister.log");
            chatHistoryFilePath = Path.Combine(logDirectory, "chat_history.json");

            // Ensure log files exist
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Dispose();
            }

            if (!File.Exists(chatHistoryFilePath))
            {
                File.Create(chatHistoryFilePath).Dispose();
            }
        }

        public void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public void SaveChatHistory(string chatHistory)
        {
            using (StreamWriter writer = new StreamWriter(chatHistoryFilePath))
            {
                writer.Write(chatHistory);
            }
        }

        public string LoadChatHistory()
        {
            if (File.Exists(chatHistoryFilePath))
            {
                using (StreamReader reader = new StreamReader(chatHistoryFilePath))
                {
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }

}
