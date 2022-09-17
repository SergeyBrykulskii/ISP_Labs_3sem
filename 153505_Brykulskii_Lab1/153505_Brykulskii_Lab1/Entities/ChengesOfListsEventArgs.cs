class ChengesOfListsEventArgs : EventArgs
{
    public string Message { get; }
    public ChengesOfListsEventArgs(string message)
    {
        Message = message;
    }
}

