using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ISubscriptionManager _subscriptionManager;

        public HomeController(ISubscriptionManager subscriptionManager)
        {
            _subscriptionManager = subscriptionManager;
        }

        public IActionResult Index()
        {
            var result = _subscriptionManager.Subscribe(new Subscriber { Id = 1, Name = "Michael" });
            var isSubscriptionProcessCompleted = result;

            if (isSubscriptionProcessCompleted)
            {
                var isSubscribed = _subscriptionManager.IsSubscriber(1);
            }

            return View();
        }
    }
}
