using System.Text.Json;
using System.Text.Json.Serialization;
using BlockChain.Application.Responses;
using BlockChain.Application.Responses.BaseResponse;

namespace BlockChain.Infrastructure.Extensions
{


    public class BlockHistoryConverter : JsonConverter<Application.Responses.BaseResponse.BlockHistoryBaseResponse>
    {
        private static readonly Dictionary<string, Type> _discriminatorMap = new()
    {
        { "ETH.main", typeof(EtheriumBlockHistoryResponse) }
    };

        public override Application.Responses.BaseResponse.BlockHistoryBaseResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            if (root.TryGetProperty("name", out var nameProp) && nameProp.ValueKind == JsonValueKind.String)
            {
                var disc = nameProp.GetString();
                if (disc != null && _discriminatorMap.TryGetValue(disc, out var targetType))
                {
                    return (BlockHistoryBaseResponse)JsonSerializer.Deserialize(root.GetRawText(), targetType, options)!;
                }
            }

            if (root.TryGetProperty("medium_gas_price", out _))
            {
                return JsonSerializer.Deserialize<EtheriumBlockHistoryResponse>(root.GetRawText(), options)!;
            }
            if(root.TryGetProperty("low_fee_per_kb", out _))
            {
                return JsonSerializer.Deserialize<DefaultBlockHistoryResponse>(root.GetRawText(), options)!;
            }

            throw new NotSupportedException($"The {typeToConvert.Name} type is not supported.");
        }

        public override void Write(Utf8JsonWriter writer, Application.Responses.BaseResponse.BlockHistoryBaseResponse value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object?)value, value.GetType(), options);
        }
    }
}
