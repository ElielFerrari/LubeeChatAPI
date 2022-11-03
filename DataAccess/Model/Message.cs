namespace DataAccess.Model
{
    public class Message
    {
        public int MessageId { get; set; }
        public int Sender { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
