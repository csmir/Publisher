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
