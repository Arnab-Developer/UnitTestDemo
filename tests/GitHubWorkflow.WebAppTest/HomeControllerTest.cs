using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestDemo.Lib;
using UnitTestDemo.WebApp.Controllers;
using UnitTestDemo.WebApp.Models;
using Xunit;

namespace UnitTestDemo.WebAppTest
{
    public class HomeControllerTest
    {
        private readonly Mock<IHelloService> _helloServiceMock;
        private HomeController? _homeController;
        private const string _viewName = "Index";
        private const string _userName = "test user 2";
        private const string _helloMessage = "hello test user 2";

        public HomeControllerTest()
        {
            _helloServiceMock = new Mock<IHelloService>();
        }

        [Fact]
        public void IndexViewNameTest()
        {
            Setup();
            ViewResult? viewResult = Action();

            Assert.NotNull(viewResult);
            Assert.Equal(_viewName, viewResult!.ViewName);
        }

        [Fact]
        public void IndexModelTest()
        {
            Setup();
            ViewResult? viewResult = Action();

            Assert.NotNull(viewResult);
            Assert.IsType<HelloServiceModel>(viewResult!.Model);

            HelloServiceModel? helloServiceModel = viewResult.Model as HelloServiceModel;
            Assert.NotNull(helloServiceModel);
            Assert.Equal("test user 2", helloServiceModel!.UserName);
            Assert.Equal("hello test user 2", helloServiceModel.HelloMessage);
        }

        private void Setup()
        {
            _helloServiceMock.Setup(m => m.UserName).Returns(_userName);
            _helloServiceMock.Setup(m => m.GetHelloMessage()).Returns(_helloMessage);
            _homeController = new HomeController(_helloServiceMock.Object);
        }

        private ViewResult? Action()
        {
            if (_homeController == null)
            {
                _homeController = new HomeController(_helloServiceMock.Object);
            }
            IActionResult actionResult = _homeController.Index();
            ViewResult? viewResult = actionResult as ViewResult;
            return viewResult;
        }
    }
}
