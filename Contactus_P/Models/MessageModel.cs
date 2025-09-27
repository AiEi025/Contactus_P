using System.Collections.Generic;

namespace Contactus_P.Models
{
    public class MessageModel
    {
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string PhoneNumber { get; set; }
        public string MessageBody { get; set; }
        
    }
    public class LMessage
    {
        public List<MessageModel> listmessagemodel { get; set; } = new List<MessageModel>();
    }
}
