using ProgByte.OpenAI.ChatDemo.Server.Models;
using ProgByte.OpenAI.ChatDemo.Server.Services;

namespace ProgByte.OpenAI.ChatDemo.Server.Extensions.Configuration
{
    public static class AddApplicationExtension
    {
        /// <summary>
        /// Add application services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddApplication(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddHttpContextAccessor();

            services.Configure<OpenAISettings>(configuration.GetSection("OpenAISettings"));
            services.AddSingleton<OpenAIService>();
        }
    }
}
