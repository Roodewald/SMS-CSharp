using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Для работы c MainSMS необходимо подключить библиотеку mainsms\
using MainSms;
using System.Net;
using System.IO;

namespace SmsApp
{
    namespace SmsSends
    {
        class Program
        {
            static void Main(string[] args)
            {
                string project_id = "SmsC";
                string api_key = "6c3885b2426e330188a5a7c842cdf0d9";

                string massage = "";
                string targetPhone;
                string a;

                SmsMessage sms = new SmsMessage(project_id, api_key);

                if (args.Length == 0)
                {
                    Console.WriteLine("Enter Arguments");
                    return;
                }

                targetPhone = args[0];
                while ((a = Console.In.ReadLine()) != null)
                {
                    massage += a;
                }
                Console.WriteLine(massage);

                ResponseSend responseSend = sms.sendSms("sendertest", targetPhone, massage);
                if (responseSend.status == "success")
                {
                    Console.WriteLine($"Частей в одной смс {responseSend.parts}, всего частей {responseSend.count}, стоимость отправки {responseSend.price}");
                }
                else
                {
                    Console.WriteLine("Error - " + responseSend.message);
                }
                ResponseBalance responseBalance = sms.getBalance();
                if (responseBalance.status == "success") Console.WriteLine(responseBalance.balance);
                else Console.WriteLine("Error - " + responseBalance.message);
            }
        }
    }
}