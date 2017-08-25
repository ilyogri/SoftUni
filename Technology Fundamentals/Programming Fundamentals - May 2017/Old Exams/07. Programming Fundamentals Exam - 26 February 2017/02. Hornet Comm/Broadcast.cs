namespace _02.Hornet_Comm
{
    public class Broadcast
    {
        public Broadcast(string message, string frequency)
        {
            this.Message = message;
            this.Frequency = frequency;
        }

        public string Message { get; set; }
        public string Frequency { get; set; }
    }
}