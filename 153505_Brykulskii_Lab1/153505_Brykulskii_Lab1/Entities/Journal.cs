class Journal
{
    private int NumberOfEvents { get; set; }
    public string[] EventsList { get; set; }

    public Journal(PayrollDepartment pd)
    {
        NumberOfEvents = 0;
        EventsList = new string[1];
        pd.ChengesOfLists += AddEvent;
    }

    public void AddEvent(object Sender, ChengesOfListsEventArgs e)
    {
        if (NumberOfEvents == EventsList.Length)
        {
            string[] temp = new string[EventsList.Length * 2];
            EventsList.CopyTo(temp, 0);
            EventsList = temp;
        }
        EventsList[NumberOfEvents] = e.Message;
        NumberOfEvents++;
    }

    public void ShowEvents()
    {
        for (int i = 0; i < NumberOfEvents; i++)
        {
            Console.WriteLine(EventsList[i]);
        }
    }
}
