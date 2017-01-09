using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            var startPrint = @"t:开始测试        e:退出";
            Console.WriteLine(startPrint);
            Console.ForegroundColor = ConsoleColor.White;

            var inputKey ="";
            while(true)
            {
                inputKey = Console.ReadLine();
                
                switch(inputKey.ToString()){
                    case "e":
                        //退出
                        Environment.Exit(0);
                        break;
                    case "t":
                        //开始测试
                        Console.ForegroundColor = ConsoleColor.Green;
                        StartTest();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("命令："+inputKey+"无效");
                        break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                
            }
            
        }

        private static void StartTest()
        {
            Console.WriteLine("测试开始......");
            try
            {
                //Json Test
                Console.WriteLine("测试开始JsonHandler");
                JsonHandlerTest.Test();

                //SendCloud Test
                Console.WriteLine("测试开始SendCloudMail");
                SendCloudMailTest.Test();


            }catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("测试失败："+e.Message);
                return;

            }
            Console.WriteLine("全部测试完成，测试成功！");

            
        }
    }

   
}
