using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JogoCartas.Models
{
    public class DeckResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("deck_id")]
        public string DeckId { get; set; }

        [JsonPropertyName("shuffled")]
        public bool Shuffled { get; set; }

        [JsonPropertyName("remaining")]
        public long Remaining { get; set; }
    }
    public partial class CardReponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("deck_id")]
        public string DeckId { get; set; }

        [JsonPropertyName("cards")]
        public List<Card> Cards { get; set; }

        [JsonPropertyName("remaining")]
        public long Remaining { get; set; }
    }
    public partial class Card
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("suit")]
        public string Suit { get; set; }
    }

    public partial class Images
    {
        [JsonPropertyName("svg")]
        public Uri Svg { get; set; }

        [JsonPropertyName("png")]
        public Uri Png { get; set; }
    }
}
