using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using RestSharp;


namespace RequisicoesWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            Requestdefault();
          
        }
        
        public static void Requestdefault()
        {
            var client = new RestClient("https://accounts.zoho.com/oauth/v2/token?refresh_token=1000.0b035a7f72bd6f9fbfbfaf91dc0fed82.dc83ce0dd574093823e990755adc7ab4&client_id=1000.SNG0SRKGYG1637H919GEV80ZGGG1DB&client_secret=bd8ea95279038218b987174413b5be631b33b732da&redirect_uri=http://genesistelecom.com.br&grant_type=refresh_token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            var post = JsonConvert.DeserializeObject<Token>(response.Content);

                Console.WriteLine("accestoken= " + post.access_token);
            //Console.ReadLine();
            
            
            Random randNum = new Random();
            string callid = randNum.Next(999999).ToString();
            string date = DateTime.Now.AddHours(3).ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine(callid);
            Console.WriteLine(date);

            string to = "2730252728";
            string from = "27998949889";
            string zohouser = "35560727";
            //israel 35560727
            //isaac 738769770

            Console.ReadLine();
            //Console.WriteLine("callid= " + callid);
            NotifyRinging(post.access_token,callid,from,to,zohouser);
            Console.ReadLine();
            NotifyAnswered(post.access_token, callid, from, to,zohouser);
            Console.ReadLine();
            NotifyEnded(post.access_token, callid, from, to,date, zohouser);
            
            //NotifyMissed(post.access_token,callid,from,to,date,zohouser);
            Console.ReadLine();


        }

        public static void NotifyRinging (string token, string callid, string from, string to,string zohouser)
        {
            Console.WriteLine("start ringing");
            var client = new RestClient("https://www.zohoapis.com/phonebridge/v3/callnotify");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Zoho-oauthtoken "+ token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "857c6a127a=f2d7866062053cfcb3fef4ab952d0e35; _zcsr_tmp=82f3e6cb-002a-4889-bd9e-adb36ba94d69; phonebridgecsr=82f3e6cb-002a-4889-bd9e-adb36ba94d69");
            request.AddParameter("type", "received");
            request.AddParameter("state", "ringing");
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("id", callid);
            request.AddParameter("zohouser", zohouser);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine("finish ringing");
        }

        public static void NotifyAnswered(string token, string callid, string from, string to, string zohouser)
        {
            Console.WriteLine("start answered");
            var client = new RestClient("https://www.zohoapis.com/phonebridge/v3/callnotify");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "857c6a127a=f2d7866062053cfcb3fef4ab952d0e35; _zcsr_tmp=82f3e6cb-002a-4889-bd9e-adb36ba94d69; phonebridgecsr=82f3e6cb-002a-4889-bd9e-adb36ba94d69");
            request.AddParameter("type", "received");
            request.AddParameter("state", "answered");
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("id", callid);
            request.AddParameter("zohouser", zohouser);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine("finish answered");
        }

        public static void NotifyEnded(string token, string callid, string from, string to, string date, string zohouser)
        {
            Console.WriteLine("start ended");
            var client = new RestClient("https://www.zohoapis.com/phonebridge/v3/callnotify");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "857c6a127a=f2d7866062053cfcb3fef4ab952d0e35; _zcsr_tmp=82f3e6cb-002a-4889-bd9e-adb36ba94d69; phonebridgecsr=82f3e6cb-002a-4889-bd9e-adb36ba94d69");
            request.AddParameter("type", "received");
            request.AddParameter("state", "ended");
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("id", callid);
            request.AddParameter("zohouser", zohouser);
            request.AddParameter("duration", 10);
            request.AddParameter("start_time", date);
            request.AddParameter("voiceuri", "https://static.wixstatic.com/mp3/ef4303_e1625e3cf48f463eacc709ad29f2908a.mp3");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine("finish ended");
        }

        public static void NotifyMissed(string token, string callid, string from, string to, string date, string zohouser)
        {
            Console.WriteLine("start missed");
            var client = new RestClient("https://www.zohoapis.com/phonebridge/v3/callnotify");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "857c6a127a=f2d7866062053cfcb3fef4ab952d0e35; _zcsr_tmp=82f3e6cb-002a-4889-bd9e-adb36ba94d69; phonebridgecsr=82f3e6cb-002a-4889-bd9e-adb36ba94d69");
            request.AddParameter("type", "received");
            request.AddParameter("state", "missed");
            request.AddParameter("from", from);
            request.AddParameter("to", to);
            request.AddParameter("id", callid);
            request.AddParameter("zohouser", zohouser);
            request.AddParameter("start_time", date);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine("finish missed");

        }

    }
}
