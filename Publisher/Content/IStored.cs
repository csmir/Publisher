namespace Publisher
{
    public interface IStored
    {
        public ulong Id { get; }

        public void Save();
    }
}
