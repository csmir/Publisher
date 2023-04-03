using Disqord;
using System.Text.Json.Serialization;

namespace Publisher
{
    public record Guild : IStored
    {
        [JsonPropertyName("guild")]
        public ulong Id { get; }

        [JsonPropertyName("channels")]
        public List<ulong> PubChannels { get; set; }

        public Guild(ulong id)
        {
            Id = id;
            PubChannels = new();
        }

        public static Content<Guild> Get(Snowflake? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (Storage<Guild>.Values.TryGetValue(id.Value, out var guild))
                return new(guild);
            else
            {
                var newGuild = new Guild(id.Value);
                Storage<Guild>.Values.Add(id.Value, newGuild);
                return new(newGuild);
            }
        }

        public void Save()
        {
            Storage<Guild>.Save(this);
        }
    }
}
