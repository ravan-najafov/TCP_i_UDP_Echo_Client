using System;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Diagnostics;


////TCP:

//Socket clientSocket = new Socket(
//    AddressFamily.InterNetwork,
//    SocketType.Stream,
//    ProtocolType.Tcp
//    );

//int port = 5000;
//string message;

//var endpoint = new IPEndPoint(IPAddress.Loopback, port);

//clientSocket.Connect(endpoint);

//Console.Write("Enter your message: ");

//message = Console.ReadLine();

//byte[] buffer = Encoding.UTF8.GetBytes(message);

//clientSocket.Send(buffer);

//Console.WriteLine("Message otpravleno serveru!");

//byte[] responseBuffer = new byte[1024];

//int received = clientSocket.Receive(responseBuffer);

//string messageS = Encoding.UTF8.GetString(responseBuffer, 0, received);

//Console.WriteLine(" ");
//Console.WriteLine($"Server otvetil: {messageS}");


////UDP client:

using Socket socketClient = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp
);

int port = 5001;
string message;

var serverEndpoint = new IPEndPoint(IPAddress.Loopback, port);

Console.Write("Enter your message: ");
message = Console.ReadLine();

byte[] data = Encoding.UTF8.GetBytes(message);

socketClient.SendTo(data, serverEndpoint);

Console.WriteLine("Message otpravleno serveru!");

byte[] buffer = new byte[1024];

EndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);

int received = socketClient.ReceiveFrom(buffer, ref remoteEndpoint);

string messageS = Encoding.UTF8.GetString(buffer, 0, received);

Console.WriteLine(" ");
Console.WriteLine($"Sever otvetil: {messageS}");

