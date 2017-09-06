using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace HTTPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("server name");
            string server = Console.ReadLine();
            TcpClient client = new TcpClient(server, 80);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            sw.WriteLine("GET /RegneWcfService.svc/RESTjson/Add?a=1&b=1 HTTP/1.1");
            sw.WriteLine("Host: webservicedemo.datamatiker-skolen.dk\n\n");
            sw.Flush();

            int data = sr.Read();
            while (data != -1)
            {
                char c = (char)data;
                Console.Write(c);
                data = sr.Read();
            }
            //string data = sr.ReadToEnd();
            //while (data != null)
            //{
            //    Console.WriteLine("data");
            //    data = sr.ReadLine();
            //}
            Console.ReadKey();
            client.Close();
        }
    }
}
