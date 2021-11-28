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

        public MessageController(MessageService messageService)
        {
            this.messageService = messageService;
        }
        public ActionResult Index()
        {
            var model = messageService.GetMeesages(1);
            ViewBag.PageCount = messageService.GetCount();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(List<MessageModel> model)
        {
            model.Select(m => m.HasRead )
            return View(model);
        }

    }
}