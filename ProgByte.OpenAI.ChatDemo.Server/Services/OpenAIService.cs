using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using ProgByte.OpenAI.ChatDemo.Server.Models;
using Microsoft.Extensions.Options;

namespace ProgByte.OpenAI.ChatDemo.Server.Services
{
    public class OpenAIService
    {
        private readonly OpenAISettings _settings;

        public OpenAIService(IOptions<OpenAISettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<string> GetCompletionAsync(List<string> conversationHistory)
        {
            var client = new AzureOpenAIClient(new Uri(_settings.Endpoint), new AzureKeyCredential(_settings.ApiKey));

            var chatClient = client.GetChatClient(_settings.DeploymentName);

            var chatHistory = new List<ChatMessage>();

            for(var i=0; i < conversationHistory.Count; i++)
            {
                chatHistory.Add(i % 2 == 0
                    ? new UserChatMessage(conversationHistory[i])
                    : new SystemChatMessage(conversationHistory[i]));
            }

            var completion = chatClient.CompleteChat(chatHistory);

            return completion.Value.Content[0].Text;
        }
    }
}
