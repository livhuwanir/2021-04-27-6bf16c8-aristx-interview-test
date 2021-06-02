using System.Collections.Generic;

using Newtonsoft.Json;

namespace Aris.ServerTest.Models
{
    // container for deserialization of json from Kore API
    public class KoreGames
    {
        [JsonProperty("games")]
        public List<KoreGame> Games { get; set; }
    }

    public class KoreGame
    {
        public const string PLAY_LINK = "play";
        public const string SELF_LINK = "_self";
        public const string FREE_SPIN = "free_spins";


        public KoreGame()
        {
            Actions = new Dictionary<string, KoreLink>();
            Links = new Dictionary<string, KoreLink>();
        }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("_actions")]
        public Dictionary<string, KoreLink> Actions { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, KoreLink> Links { get; set; }

        [JsonProperty("rules")]
        public string Rules { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("medal")]
        public KoreMedal Medal { get; set; }

        [JsonProperty("attributes")]
        public KoreAttribute Attributes { get; set; }
        

        public string PlayGameLink
        {
            get
            {
                if (this.Actions != null && 
                    this.Actions.ContainsKey(PLAY_LINK) &&
                    !string.IsNullOrEmpty(this.Actions[PLAY_LINK].Url))
                {
                    return this.Actions[PLAY_LINK].Url;
                }

                return null;
            }
        }

        public string GameDetailsLink
        {
            get
            {
                if (this.Links != null &&
                    this.Links.ContainsKey(SELF_LINK) &&
                    !string.IsNullOrEmpty(this.Links[SELF_LINK].Url))
                {
                    return this.Links[SELF_LINK].Url;
                }

                return null;
            }
        }

        public string FreeSpins
        {
            get
            {
                if (this.Attributes != null &&
                    this.Attributes.Lines != null &&
                    !string.IsNullOrEmpty(this.Attributes.Lines))
                {
                    return this.Attributes.Lines;
                }

                return null;
            }
        }

        // bit of a hack for the test
        public string Base64GameLink
        {
            get
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(this.GameDetailsLink);
                return System.Convert.ToBase64String(plainTextBytes);
            }
        }
    }
}
