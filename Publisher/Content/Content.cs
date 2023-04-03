using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Publisher
{
    public readonly struct Content<T> : IDisposable
        where T : IStored
    {
        public T Value { get; }

        public Content(T value)
        {
            Value = value;
        }

        public void Dispose()
        {
            Value.Save();
        }
    }
}
