using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EbestTradeBot.Client.Services.OpenApi.Responses
{
    public class T1302Response
    {
        [JsonPropertyName("t1302OutBlock")]
        public T1302OutBlock T1302OutBlock { get; set; } = new();
        [JsonPropertyName("t1302OutBlock1")]
        public List<T1302OutBlock1> T1302OutBlock1 { get; set; } = [];
    }

    public class T1302OutBlock
    {
    }

    public class T1302OutBlock1
    {
        [JsonPropertyName("open")]
        public int Open { get; set; } = int.MinValue;
        [JsonPropertyName("high")]
        public int High { get; set; } = int.MinValue;
        [JsonPropertyName("low")]
        public int Low { get; set; } = int.MinValue;
        [JsonPropertyName("close")]
        public int Close { get; set; } = int.MinValue;
        [JsonPropertyName("diff")]
        public string Diff { get; set; } = string.Empty; // 정의서에는 Number인데 왜 문자열로 넘어오니 
    }
}
