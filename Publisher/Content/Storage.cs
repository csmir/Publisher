using System.Text.Json;

namespace Publisher
{
    public static class Storage<T>
        where T : IStored
    {
        private static readonly string _path;

        public static Dictionary<ulong, T> Values { get; }

        static Storage()
        {
            var innerPath = "files";

            if (!Directory.Exists(innerPath))
                Directory.CreateDirectory(innerPath);

            _path = Path.Combine(innerPath, $"{typeof(T).Name.ToLowerInvariant()}s.json");

            if (!File.Exists(_path))
            {
                Values = new();
                File.WriteAllText(_path, JsonSerializer.Serialize(Values));
            }
            else
                Values = JsonSerializer.Deserialize<Dictionary<ulong, T>>(File.ReadAllText(_path))!;
        }

        public static void Save(T value)
        {
            Values[value.Id] = value;
            File.WriteAllText(_path, JsonSerializer.Serialize(Values));
        }
    }
}
