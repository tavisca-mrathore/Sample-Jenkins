using Xunit;

namespace HiHelloWebAPI.Controllers.Tests
{
    public class HiFixtures
    {
        [Fact]
        public void Hi_Controller_Checks()
        {
            HiHelloController HiControllerObject = new HiHelloController();

            Assert.Equal("append \"hi\" or \"hello\" in the url to get response",
                HiControllerObject.Get());
            Assert.Equal("error", HiControllerObject.Get(""));
            Assert.Equal("hello", HiControllerObject.Get("hi"));
        }
    }
}
