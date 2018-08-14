using News_D_V1.Models;
using System.Net;
using System.Net.Mail;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;


namespace News_D_V1.Controllers
{
    public class HomeController : Controller
    {
        private NewsEntities2 db = new NewsEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            var articles = db.Articles.Include(a => a.Journalist);
            return View(articles.OrderByDescending(a => a.date).ToList());
        }

        // GET: Articles/Details/5
        public ActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        public ActionResult Documentation()
        {
            ViewBag.Message = "Your documentation page.";

            return View();
        }

        ////[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Send(EmailFormModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var body = "<p>Hi {2},</p><p>{5}</p>";
        //        var message = new MailMessage();
        //        message.To.Add(new MailAddress(model.ToEmail));  // replace with valid value 
        //        //message.To.Add(new MailAddress("slee0028@student.monash.edu"));  // replace with valid value 
        //        //message.From = new MailAddress("sender@outlook.com");  // replace with valid value
        //        //message.From = new MailAddress("slee0028@student.monash.edu");  // replace with valid value
        //        message.From = new MailAddress("admin@monash.edu");  // replace with valid value
        //        message.Subject = model.Subject;
        //        message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //        message.IsBodyHtml = true;
        //        if (model.Upload != null && model.Upload.ContentLength > 0)
        //        {
        //            message.Attachments.Add(new Attachment(model.Upload.InputStream, System.IO.Path.GetFileName(model.Upload.FileName)));
        //        }
        //        using (var smtp = new SmtpClient())
        //        {
        //            var credential = new NetworkCredential
        //            {
        //                //UserName = "sender@outlook.com",  // replace with valid value
        //                //UserName = "slee0028@student.monash.edu",  // replace with valid value
        //                UserName = "robinleeaus@outlook.com",  // replace with valid value
        //                Password = "Aa1234567890"  // replace with valid value, not necessary for monash mail
        //            };
        //            smtp.Credentials = credential;
        //            smtp.Host = "smtp-mail.outlook.com";
        //            //smtp.Host = "smtp.monash.edu.au";
        //            smtp.Port = 587;  //not necessary for monash email
        //            smtp.EnableSsl = true;  //not necessary for monash email
        //            await smtp.SendMailAsync(message);
        //            return RedirectToAction("SentEmail");
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                //message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
                message.To.Add(new MailAddress("slee0028@student.monash.edu"));  // replace with valid value 
                //message.From = new MailAddress("sender@outlook.com");  // replace with valid value
                //message.From = new MailAddress("slee0028@student.monash.edu");  // replace with valid value
                message.From = new MailAddress("robinleeaus@outlook.com");  // replace with valid value
                message.Subject = "Email Test";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                //if (model.Upload != null && model.Upload.ContentLength > 0)
                //{
                //    message.Attachments.Add(new Attachment(model.Upload.InputStream, System.IO.Path.GetFileName(model.Upload.FileName)));
                //}
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        //UserName = "sender@outlook.com",  // replace with valid value
                        //UserName = "slee0028@student.monash.edu",  // replace with valid value
                        UserName = "robinleeaus@outlook.com",  // replace with valid value
                        Password = "Aa1234567890"  // replace with valid value, not necessary for monash mail
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    //smtp.Host = "smtp.monash.edu.au";
                    smtp.Port = 587;  //not necessary for monash email
                    smtp.EnableSsl = true;  //not necessary for monash email
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your documentation page.";

        //    return View();
        //}

        public ActionResult Sent()
        {
            return View();
        }
    }
}