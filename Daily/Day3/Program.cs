/*
 * DAY 3  •  Series Of Tubes
 * 
 * Use sockets to connect to a webserver and display some page's contents
 * This can be any website, but a static one will provide a nicer output (try http://scanme.nmap.org/)
 * 
 * To accomplish this you will need to:
 * - Create a socket
 * - Connect the socket
 * - Write  GET request
 * - Receive the result and display it
 * 
 * This output of your program should look similar to what you get from  curl
 */

using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

// Setup variables
Uri website = new("http://example.com/");
CancellationToken token = new();
byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {website.AbsoluteUri} HTTP/1.1
Host: {website.Host}
Connection: close

" // Having two newlines at the end seems to make it more reliable... okay
);

// Configuring all these awaits isn't necessary in this project, but whatever

// Establish socket connection
using Socket socket = new(SocketType.Stream, ProtocolType.Tcp);
await socket.ConnectAsync(website.Host, website.Port, token).ConfigureAwait(false);

// Send request
int bytesSent = 0;
while (bytesSent < requestBytes.Length) {
	bytesSent += await socket.SendAsync(requestBytes, SocketFlags.None, token).ConfigureAwait(false);
}

// Retreive response
while (true) {
	byte[] buffer = new byte[256]; // Allocating a new array every loop? Gross.
	int bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None, token).ConfigureAwait(false);

	await Console.Out.WriteAsync(Encoding.ASCII.GetString(buffer)).ConfigureAwait(false);

	if (bytesReceived < buffer.Length - 1) { // Assume end of response
		break;
	}
}

// Disconnect, maybe unnecessary
await socket.DisconnectAsync(false, token).ConfigureAwait(false);