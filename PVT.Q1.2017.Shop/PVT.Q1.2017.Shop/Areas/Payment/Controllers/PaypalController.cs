

namespace PVT.Q1._2017.Shop.Areas.Payment.Controllers
{
    using System;
    using System.Web.Mvc;
    using App_Start;
    using PVT.Q1._2017.Shop.Controllers;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.ViewModels;

    [ShopAuthorize]
    public class PaypalController : BaseController
    {
        public PaypalController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        /// <summary>
        /// Метод реакции на успешный статус оплаты
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public RedirectToRouteResult Success()
        {
            return RedirectToAction("AcceptTransaction", "PaymentTransaction", new { Area = "Payment" });
        }

        /// <summary>
        /// Метод реакции на неуспешный статус оплаты
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ViewResult Failure()
        {
            return View();
        }
        
        /// <summary>
        /// Метод вызывает диалог оплаты для пользователя на стороне PayPal
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult PaymentWithPaypal(CartViewModel cart)
        {
            cart = (CartViewModel)TempData["cart"];

            if (cart == null)
            {
                return RedirectToAction("Failure");
            }

            var paymentService = ServiceFactory.GetPaymentService();
            var status = paymentService.PaymentWithPaypal(Request, Session, cart);

            if (status.StartsWith("http"))
            {
                return Redirect(status);
            }
            if(String.Compare(status,"Success", StringComparison.OrdinalIgnoreCase)==0)
            {
                this.Session.Add("IsAccepted", true);
                return RedirectToAction("Success", "Paypal", new { Area = "Payment" });
            }
            else
            {
                return RedirectToAction("Failure", "Paypal", new { Area = "Payment" });
            }
        }

        /// <summary>
        /// Метод обработки статуса платежа PayPal
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult PaymentWithPaypal()
        {
            var paymentService = ServiceFactory.GetPaymentService();
            var status = paymentService.PaymentWithPaypal(Request, Session);

            if (status.StartsWith("http"))
            {
                return Redirect(status);
            }
            else
            {
                if (String.Compare(status, "Success", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    this.Session.Add("IsAccepted", true);
                }
                return RedirectToAction(status, "Paypal", new { Area = "Payment" });
            }
        }
    }
}