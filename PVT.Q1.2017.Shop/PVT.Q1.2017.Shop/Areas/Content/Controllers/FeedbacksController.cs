namespace PVT.Q1._2017.Shop.Areas.Content.Controllers
{
    using System.Web.Mvc;
    using App_Start;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.ViewModels;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Enums;
    using Shop.Controllers;

    [ShopAuthorize(UserRoles.Buyer, UserRoles.Customer)]
    public class FeedbacksController : BaseController
    {
        public FeedbacksController(IRepositoryFactory repositoryFactory, IServiceFactory serviceFactory) : base(repositoryFactory, serviceFactory)
        {
        }

        [HttpGet]
        public ActionResult Details(int? trackid)
        {
            if (trackid == null)
            {
                return RedirectToAction("List", "Track", new { area = "Content" });
            }

            var feedbackService = ServiceFactory.GetFeedbackService();
            if (CurrentUser != null)
            {
                ViewBag.CurrentFeedback = feedbackService.GetTrackFeedback(trackid.Value, CurrentUser.UserProfileId);
            }

            var feedbacks = feedbackService.GetTrackFeedbacks(trackid.Value);
            return View(feedbacks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Include= "TrackId,Mark,Comments")]FeedbackViewModel feedback)
        {
            if (feedback == null)
            {
                return RedirectToAction("List", "Track", new { area = "Content" });
            }

            var feedbackService = ServiceFactory.GetFeedbackService();
            if (CurrentUser != null)
            {
                feedback.UserDataId = CurrentUser.UserProfileId;
                feedbackService.AddOrUpdateFeedback(feedback);
            }

            return RedirectToAction("Details", "Feedbacks", new { area = "Content", trackId = feedback.TrackId });
        }
    }
}