using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;


namespace MyAuroraProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //create web client
            WebClient client = new WebClient();

            //download string
            string value = client.DownloadString("http://www.aurora-service.net/aurora-forecast/");

            //find forecast in the string
            string data = getInfoBetween(value, "3 day forecast", "Why do we use UTC?");

            //use regex to remove html tags from the data string
            string pattern = @"(</?[^>]*>)";
            data = Regex.Replace(data, pattern, "");
            Console.WriteLine(data);

            //send email
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("my.aurora.reminder@gmail.com", "1AuroraMy1"),
                EnableSsl = true
            };
            smtpClient.Send("my.aurora.reminder@gmail.com", "cornelia_schulz@hotmail.com", "Aurora Forecast", data);
            Console.WriteLine("Email sent successfully.");
            Console.ReadLine();

            //write string to file
            File.WriteAllText(@"C:\Users\Dave\AppData\Local\MyAurora\aurora.txt", data);

            
        }
        //search info in between two strings
        public static string getInfoBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "No info found today";
            }
        }

    }
}
