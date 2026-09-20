using System.Text.Json;

namespace BlockChain.Infrastructure.Extensions
{
    internal static class JsonOptionExtension
    {
        public static JsonSerializerOptions AddSnakeCaseNamingPolicyWithTypeResolveConverter()
        {
            var jsonOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            };
            jsonOption.Converters.Add(new BlockHistoryConverter());
            return jsonOption;
        }
    }
}
