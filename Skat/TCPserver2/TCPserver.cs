using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Skat;

namespace TCPEchoServer
{
    class TCPEchoServer
    {

        public static void Main(string[] args)
        {

            IPAddress ip = IPAddress.Parse("127.0.0.1");


            TcpListener serverSocket = new TcpListener(ip, 6789);


            serverSocket.Start();
            Console.WriteLine("Server started");

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;


            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {

                Console.WriteLine("Client: " + message);
                if(message=="Bil" || message == "bil")
                {
                answer = "Indtast pris på den pågældende bil.";
                sw.WriteLine(answer);
                message = sr.ReadLine();
                int pris = Convert.ToInt32(message); //her koverteres string til int så vi ved hvad prisen er 

                string Udregnet = Afgift.BilAfgift(pris).ToString();

                    answer = "Afgiften er så ledes: " + Udregnet;
                    sw.WriteLine(answer);
                }

                if (message == "Elbil" || message == "elbil")
                {
                    answer = "Indtast pris på den pågældende bil";
                    sw.WriteLine(answer);
                    message = sr.ReadLine();
                    int pris = Convert.ToInt32(message);

                    string udregnet = Afgift.ElBilAfgift(pris).ToString();

                    answer = "Afgiften er så leds: " + udregnet;
                    sw.WriteLine(answer);

                }

                message = sr.ReadLine();
                

             
            }

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();

        }
    }

}
