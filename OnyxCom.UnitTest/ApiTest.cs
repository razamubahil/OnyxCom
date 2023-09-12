using OnyxCom.BusinessApi.Controllers;

namespace OnyxCom.UnitTest
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public void GetAllProductsTest()
        {
            ProductController controller = new ProductController(null);
            var result = controller.GetProducts();

            Assert.IsTrue(result.Any());

        }

        [TestMethod]
        [DataRow("Red")]
        [DataRow("Pink")]
        public void GetAllProductsByColorTest(string Color)
        {
            ProductController controller = new ProductController(null);
            var result = controller.GetProductsByColor(Color);

            Assert.IsTrue(result.Any());

        }

        [TestMethod]
        [DataRow("NotAColor")]
        [DataRow("Invalid")]
        public void GetAllProductsByColor_WhenNotAColor_Test(string Color)
        {
            ProductController controller = new ProductController(null);
            var result = controller.GetProductsByColor(Color);

            Assert.IsTrue(!result.Any());

        }
    }
}