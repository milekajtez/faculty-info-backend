namespace FacultyInfo.Domain.Mail
{
    public class MailRequest
    {
        public string TemplateId { get; set; }
        public string Receiver { get; set; }
        public object TemplateData { get; set; }
        public string SenderName { get; set; }

        public MailRequest(string templateId, string receiver, object templateData, string senderName)
        {
            TemplateId = templateId;
            Receiver = receiver;
            TemplateData = templateData;
            SenderName = senderName;
        }
    }
}
