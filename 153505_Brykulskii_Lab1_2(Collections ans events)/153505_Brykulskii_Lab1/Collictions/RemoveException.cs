class RemoveException : ArgumentException
{
    public int Value { get; }
    public RemoveException(string message, int value) : base(message)
    {
        Value = value;
    }
}