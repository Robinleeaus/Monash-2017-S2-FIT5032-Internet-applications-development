using System.ComponentModel.DataAnnotations;
using System.Web;

namespace News_D_V1.Models
{
    public class EmailFormModel
    {
        [Display(Name = "Sender name")]
        public string FromName { get; set; }
        [Display(Name = "Sender email")]
        public string FromEmail { get; set; }
        [Display(Name = "Receiver name")]
        public string ToName { get; set; }
        [Required, Display(Name = "Receiver email"), EmailAddress]
        public string ToEmail { get; set; }
        [Required, Display(Name = "Subject"), EmailAddress]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }
    }
}