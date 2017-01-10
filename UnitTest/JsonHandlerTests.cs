using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PublicUtility.Tests
{
    [TestClass()]
    public class JsonHandlerTests
    {
        [TestMethod()]
        public void UnJsonTest()
        {
            TestModel model = new TestModel();
            model.UserName = "Test";
            model.Email = "12222@qq.com";
            var json = "{\"Email\":\"12222@qq.com\",\"UserName\":\"Test\"}";

            var jsonStr = JsonHandler.ToJson(model);

            Assert.AreEqual(jsonStr, json);
        }

        [TestMethod()]
        public void ToJsonTest()
        {
            var jsonStr = "{\"Email\":\"12222@qq.com\",\"UserName\":\"Test\"}";
            var jsonModel = JsonHandler.UnJson<TestModel>(jsonStr);

            Assert.IsInstanceOfType(jsonModel,typeof(TestModel));
        }
    }

    public class TestModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
