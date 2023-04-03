using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    public interface IStored
    {
        public ulong Id { get; }

        public void Save();
    }
}
