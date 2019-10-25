using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoClient
{
    class TCPEchoClient
    {
        static void Main(string[] args)
        {

            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Client ready");
            Console.WriteLine("Her kan du udregne afgiften på en bil. Indtast 'Elbil' eller 'Bil', alt efter hvilken slags du vil udregne på");


            Stream ns = clientSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = Console.ReadLine();

            while (message != "stop")
            {
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();

                Console.WriteLine("Server: " + serverAnswer);

                message = Console.ReadLine();
            }

            ns.Close();

            clientSocket.Close();

        }

    }

}
