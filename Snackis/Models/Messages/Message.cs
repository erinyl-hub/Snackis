using Snackis.Areas.Identity.Data;

namespace Snackis.Models.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public string UserMessage { get; set; }
        public DateTime MessageSentAt { get; set; }


        public string ReceiverId { get; set; }
        public SnackisUser Receiver { get; set; }

        public string SenderId { get; set; }
        public SnackisUser Sender { get; set; }
    }
}
