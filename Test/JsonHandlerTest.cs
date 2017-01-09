using PublicUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class JsonHandlerTest
    {
        public static void Test()
        {
            TestModel model = new TestModel();
            model.UserName = "Test";
            model.Email = "12222@qq.com";

            var jsonStr = JsonHandler.ToJson(model);
            var jsonModel = JsonHandler.UnJson<TestModel>(jsonStr);
        }
    }

    public class TestModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
