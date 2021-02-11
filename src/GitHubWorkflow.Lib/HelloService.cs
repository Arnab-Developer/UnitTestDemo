namespace UnitTestDemo.Lib
{
    public class HelloService : IHelloService
    {
        public string UserName { get; set; }

        public HelloService(string userName)
        {
            UserName = userName;
        }

        public string GetHelloMessage()
        {
            return $"hello {UserName}";
        }
    }
}
