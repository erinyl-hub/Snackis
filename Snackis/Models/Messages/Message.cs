using Snackis.Areas.Identity.Data;

namespace Snackis.Models.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public string UserMessage { get; set; }
        public DateTime MessageSentAt { get; set; }


        public SnackisUser UserSender { get; set; }
        public string UserSenderId { get; set; }

        public SnackisUser UserReceiver { get; set; }
        public string UserReceiverId { get; set; }
    }
}
