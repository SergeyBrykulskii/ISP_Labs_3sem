namespace _153505_Brykulskii_Lab3.Entities
{
    class Journal
    {
        private int NumberOfEvents { get; set; }
        public string[] EventsList { get; set; }

        public Journal()
        {
            NumberOfEvents = 0;
            EventsList = new string[1];
        }

        public void AddChangesInWorkersOrJobsList(object Sender, PayrollDepartmentEventArgs e)
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

        public void ShowRegisteredEvents()
        {
            for (int i = 0; i < NumberOfEvents; i++)
            {
                Console.WriteLine(EventsList[i]);
            }
        }
    }
}
