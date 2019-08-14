using System.Net.Http;
using NUnit.Framework;

namespace RA.Tests
{
    [TestFixture]
    public class InvalidCallTest
    {
        [Test]
        public void BadAddressShouldFail()
        {
            Assert.Throws<System.ArgumentException>(() =>
            {
                var ec = new RestAssured()
                           .Given()
                           .Name("Bad Call")
                           .When()
                           .Get("http://www.fake-2-address.com");
                try
                {
                    ec.Then();
                } catch(System.ArgumentException e)
                {
                    Assert.IsTrue(e.ParamName.Contains("text/html"));
                    throw e;
                }
            });
        }
    }
}