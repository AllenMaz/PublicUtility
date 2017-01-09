using PublicModel;
using PublicUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SendCloudMailTest
    {
        public static void Test()
        {
            var apiUser = "xiamenip";
            var apiKey = "vcxHk2Jcquzs4W66";
            var sendMailUrl = "http://api.sendcloud.net/apiv2/mail/send";

            SendCloud sendCloud = new SendCloud(apiUser, apiKey);
            Mail mail = new Mail();
            mail.From = "mzp@padmate.cn";
            mail.To = "2727954462@qq.com";
            mail.Subject = "测试邮件";
            mail.Body = "测试邮件";

            var message = SendCloud.SendMail(sendMailUrl, mail);
            if (!message.Success)
                throw new Exception(message.Content);
        }
        
    }
}
