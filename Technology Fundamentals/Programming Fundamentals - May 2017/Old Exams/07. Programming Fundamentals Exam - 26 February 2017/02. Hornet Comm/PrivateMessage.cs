namespace _02.Hornet_Comm
{
    public class PrivateMessage
    {
        public PrivateMessage(string recipientCode, string message)
        {
            this.RecipientCode = recipientCode;
            this.Message = message;
        }

        public string RecipientCode { get; set; }
        public string Message { get; set; }
    }
}