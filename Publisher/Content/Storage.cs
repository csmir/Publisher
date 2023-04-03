using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Publisher
{
    public static class Storage<T>
    where T : IStored
    {
        private static readonly string _path;

        public static Dictionary<ulong, T> Values { get; }

        static Storage()
        {
            _path = Path.Combine("files", $"{typeof(T).Name.ToLowerInvariant()}s.json");

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
