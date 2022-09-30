namespace _153505_Brykulskii_Lab5.Domain.Entities
{
    [Serializable]
    public class LuggageCompartment
    {
        public int Capacity { get; set; }

        public bool IsFree { get; set; }

        public LuggageCompartment()
        {
            Capacity = 0;
            IsFree = true;
        }

        public LuggageCompartment(int capacity, bool isFree)
        {
            Capacity = capacity;
            IsFree = isFree;
        }
    }
}
