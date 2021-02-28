namespace UnitTestDemo.WebApp.Models
{
    public class HelloServiceModel
    {
        public string UserName { get; set; }

        public string HelloMessage { get; set; }

        public HelloServiceModel()
        {
            UserName = string.Empty;
            HelloMessage = string.Empty;
        }
    }
}
