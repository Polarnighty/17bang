using System.Collections.Generic;
using System.Web.Mvc;
using SRV.ProdService;
using SRV.ViewModel;
using System.Linq;
namespace MVC.Controllers
{
    public class MessageController : Controller
    {
        private MessageService messageService;
        private static int index;

        public MessageController(MessageService messageService)
        {
            this.messageService = messageService;
        }
        public ActionResult Index(int id = 1)
        {
            var model = messageService.GetMeesages(id);
            ViewBag.PageCount = messageService.GetCount();

            index = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(List<MessageModel> models, string submitType)
        {
            var ids = models.Where(m => m.Selected == true).Select(m => m.Id).ToArray();
            if (ids.Length == 0)
            {
                return RedirectToRoute(new { id = index });
            }
            if (submitType == "Read")
            {
                var UnReadId = models.Where(m => m.HasRead == false).Select(m => m.Id).ToArray();
                if (UnReadId.Length==0)
                {
                    return RedirectToRoute(new { id = index });
                }
                messageService.HasRead(UnReadId);
            }
            else
            {
                messageService.Delete(ids);
            }
            return RedirectToRoute(new { id = index });
        }

    }
}