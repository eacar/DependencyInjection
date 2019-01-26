using System;
using Moq;
using Web;
using Web.Controllers;
using Xunit;

namespace Test
{
    public class HomeControllerTest
    {
        private HomeController _homeController;
        private Mock<ISubscriptionManager> _subscribtionManager;

        public HomeControllerTest()
        {
            _subscribtionManager = new Mock<ISubscriptionManager>();
            _homeController = new HomeController(_subscribtionManager.Object);
        }

        [Fact]
        public void Index_Success()
        {
            _subscribtionManager.Setup(c => c.Subscribe(It.IsAny<Subscriber>())).Returns(true);
            _subscribtionManager.Setup(c => c.IsSubscriber(It.IsAny<int>())).Returns(true);

            _homeController.Index();


            _subscribtionManager.Verify(c => c.Subscribe(It.IsAny<Subscriber>()), Times.AtLeastOnce);
            _subscribtionManager.Verify(c => c.IsSubscriber(It.IsAny<int>()), Times.AtLeastOnce);
        }


        [Fact]
        public void Index_Success_2()
        {
            _subscribtionManager.Setup(c => c.Subscribe(It.IsAny<Subscriber>())).Returns(true);
            _subscribtionManager.Setup(c => c.IsSubscriber(It.IsAny<int>())).Returns(false);

            _homeController.Index();
        }


        [Fact]
        public void Index_ErrorWhenSubscribeFalse()
        {
            _subscribtionManager.Setup(c => c.Subscribe(It.IsAny<Subscriber>())).Returns(false);
            _subscribtionManager.Setup(c => c.IsSubscriber(It.IsAny<int>())).Returns(true);

            _homeController.Index();

            _subscribtionManager.Verify(c => c.Subscribe(It.IsAny<Subscriber>()), Times.AtLeastOnce);
            _subscribtionManager.Verify(c => c.IsSubscriber(It.IsAny<int>()), Times.Never);
        }
    }
}
