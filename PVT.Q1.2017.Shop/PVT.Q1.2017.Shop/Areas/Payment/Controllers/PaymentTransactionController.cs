namespace PVT.Q1._2017.Shop.Areas.Payment.Controllers
{
    using System.Web.Mvc;
    using App_Start;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.DAL.Infrastruture;
    using PVT.Q1._2017.Shop.Controllers;
    using global::Shop.Common.ViewModels;
    using Helpers;
    using global::Shop.Infrastructure.Enums;
    using System.Web;

    [ShopAuthorize]
    public class PaymentTransactionController : BaseController
    {

        public PaymentTransactionController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// Action to view payment transactions
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        [Authorize]
        public ActionResult Index(int pageId = 1)
        {
            int countPerPage = 10;
            this.TempData["CurrentPage"] = pageId;
            if (CurrentUser.IsInRole(UserRoles.Admin))
            {
                var transactions = ServiceFactory.GetPaymentService().GetDataPerPage(null, pageId, countPerPage);
                return this.View(PaymentMapper.GetPaymentTransactionsToEdit(transactions));
            }
            else
            {
                var transactions = ServiceFactory.GetPaymentService().GetDataPerPage(CurrentUser.Id, pageId, countPerPage);
                return this.View(PaymentMapper.GetPaymentTransactionsToEdit(transactions));
            }
            
        }

        /// <summary>
        /// Action for watching details of payment transaction
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult Details(int? transactionID)
        {
            //TODO: реализовать просмотр деталей заказа
            if(transactionID==null)
            {
                return HttpNotFound();
            }
            
            return View();
        }

        /// <summary>
        /// Action for accepting payment transaction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AcceptTransaction()
        {
            var accept = false;
            if (Session["IsAccepted"] != null)
            {
                accept = (bool)Session["IsAccepted"];
                if (accept)
                {
                    CartViewModel cart = (CartViewModel)TempData["cart"];
                    if(cart!=null)
                    {
                        ServiceFactory.GetPaymentService().CreatePaymentTransaction(cart);
                    }
                }
            }
            return RedirectToAction("AcceptPayment", "Cart", new { Area = "Payment" });
        }

        /// <summary>
        /// Action for watching money results
        /// </summary>
        /// <returns></returns>
        [ShopAuthorize(UserRoles.Admin, UserRoles.Seller)]
        public ViewResult PayResult()
        {
            var pays = ServiceFactory.GetPaymentService().GetPaysForUser(CurrentUser, CurrentUserCurrency.Id);
            
            return View(pays);
        }
    }
}