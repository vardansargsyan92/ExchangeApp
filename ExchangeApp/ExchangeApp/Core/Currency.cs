using Newtonsoft.Json;

namespace ExchangeApp.Core
{
    public class Currency
    {
        [JsonProperty("currency")] public string CurrencyString { get; set; }

        [JsonProperty("value")] public double Value { get; set; }
    }
}