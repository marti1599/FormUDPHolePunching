using LumiSoft.Net.STUN.Client;
using NetFwTypeLib;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FormUDPHolePunching
{
    public partial class Form1 : Form
    {
        bool stopSender = false;
        bool stopListener = false;
        bool stopScan = false;

        (STUN_NetType netType, EndPoint localEndPoint, EndPoint remoteEndPoint) MachineInfo;

        /* Steps:
         * 1 - This machine send a request to a STUN server on local port xxxx (4321)
         * 2 - STUN receive the message and read the remote endpoint (IP, Port)
         * 3 - STUN send response to this machine with local and remote endpoint
         * 4 - Now i need the local and remote enpoint of the remote machine (now i simply copy them)
         * 5 - With the local and remote endpoint i start sending UDP Datagram with a specific value (for check that is my app and not another listener) to the 2 endpoints and start to listen on local port
         */

        /*
         * Go to checkip.dyndns.org You will get your public IP address.
         * Open CMD and type tracert {public IP}, for example: tracert 144.54.89.140
         * If there is more than 1 hop, you are behind a NAT.
         * */

        /*HOW IT WORK:
         * C1 = Client 1
         * C2 = Client 2
         * 
         * 1 - C1 and C2 gets infos from STUN
         * 2.1 - if port is the same as the sended message (in the test 12356) it's more easy, i only need the public IP of the other client
         * 2.2 - if port is different i need to check if connecting to another STUN return the same port or not
         * 2.2.1 - if the port is the same i need to send it to the other Client IP and Port
         * 2.2.2 - if the port is different i need a workaround because if the other Client is in the same situation (the port change) the connection will not work (i need at least 1 port known). The connection with the other Client will have a unknown port (i can use VPN)
         * 3 - when i have all the info i need to send them to the other Client (C1 will send to C2 the LocalEndPoint and RemoteEndpoint, C2 will send to C1 the LocalEndPoint and RemoteEndpoint) (I NEED A WAY TO DO THIS, IF I DIRECTLY SEND THE PACKETS THE RECEIVER CAN NOT RECEIVE THEM AND DON'T START TO TRY TO CONNECT, GOOD PRACTISE IS TO USE A THIRD USER THAT EXCHANGE THE INFOS)
         * 4 - After receiving the infos i start to send SYN packets to the received infos
         * 5 - if at least one of the Client receive the packet i can start the comunication (if i'm not sending packets to the received IP i didn't received the EndPoints so i start to send SYN to the received packet EndPoint, otherwise if i'm already sending packets to the received packet IP i can check if the port and IP of the packet received is the same i'm using, if yes i'm just late and don't need to change packets Port, if no i need to change the port with the port of the received packet)
         * 6 - After have both sending packets to the right IP and Port the connection is enstablished
         */

        /*TIPS:
         * - VPN can workaround if sending packets to STUNs servers return always a different port
         * 
         * 
         */
        public Form1()
        {
            InitializeComponent();

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            var currentProfiles = firewallPolicy.CurrentProfileTypes;

            bool firewallRuleAddedIn = false;
            try
            {
                firewallPolicy.Rules.Item("UDPHolePunchingIn");
                firewallRuleAddedIn = true;
            }
            catch(FileNotFoundException ex)
            {
                //Rule not find
                firewallRuleAddedIn = false;
            }

            if (!firewallRuleAddedIn)
            {
                try
                {
                    //Create Firewall Rule
                    /*INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    firewallRule.Description = "UDPHolePunching rule";
                    firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    firewallRule.Enabled = true;
                    firewallRule.InterfaceTypes = "All";
                    firewallRule.Name = "UDPHolePunching";*/

                    //Inbound Rule

                    // Let's create a new rule
                    INetFwRule2 firewallRuleIn = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRuleIn.Enabled = true;
                    firewallRuleIn.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    //Allow through firewall
                    firewallRuleIn.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    //Using protocol UDP
                    firewallRuleIn.Protocol = 17;
                    firewallRuleIn.LocalAddresses = "*";
                    firewallRuleIn.RemoteAddresses = "*";
                    firewallRuleIn.EdgeTraversal = true;
                    firewallRuleIn.EdgeTraversalOptions = 1;
                    //Name of rule
                    firewallRuleIn.Name = "UDPHolePunchingIn";

                    firewallPolicy.Rules.Add(firewallRuleIn);

                    firewallPolicy.Rules.Item("UDPHolePunchingIn").RemotePorts = "*";
                    firewallPolicy.Rules.Item("UDPHolePunchingIn").LocalPorts = "*";
                }
                catch (Exception e) { }
            }

            bool firewallRuleAddedOut = false;
            try
            {
                firewallPolicy.Rules.Item("UDPHolePunchingOut");
                firewallRuleAddedOut = true;
            }
            catch (FileNotFoundException ex)
            {
                //Rule not find
                firewallRuleAddedOut = false;
            }

            if (!firewallRuleAddedOut)
            {
                try
                {
                    //Outboudn Rule

                    // Let's create a new rule
                    INetFwRule2 firewallRuleOut = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                    firewallRuleOut.Enabled = true;
                    firewallRuleOut.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    //Allow through firewall
                    firewallRuleOut.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    //firewallRuleOut.EdgeTraversal = true;
                    //firewallRuleOut.EdgeTraversalOptions = 1;
                    //Using protocol UDP
                    firewallRuleOut.Protocol = 17;
                    firewallRuleOut.LocalAddresses = "*";
                    firewallRuleOut.RemoteAddresses = "*";
                    //Name of rule
                    firewallRuleOut.Name = "UDPHolePunchingOut";

                    firewallPolicy.Rules.Add(firewallRuleOut);

                    firewallPolicy.Rules.Item("UDPHolePunchingOut").RemotePorts = "*";
                    firewallPolicy.Rules.Item("UDPHolePunchingOut").LocalPorts = "*";
                }
                catch (Exception e) { }
            }

            int defaultPort = 12357;
            TxtbxListenerIP.Text = IPAddress.Any.ToString();
            NudListenerPort.Value = defaultPort;

            MachineInfo = ConnectToSTUN(GetLocalIPAddress(), defaultPort);

            TxtbxNetTypeValue.Text = MachineInfo.netType.ToString();
            TxtbxLocalEndPointValue.Text = MachineInfo.localEndPoint.ToString();
            TxtbxRemoteEndPointValue.Text = MachineInfo.remoteEndPoint.ToString();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("Local IP: " + ip.ToString());
                    AppendTextBox("Local IP: " + ip.ToString());
                }
            }
        }

        public IPAddress GetLocalIPAddress()
        {
            IPAddress localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address;
            }
            return localIP;
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            TxtbxLog.Text = value + Environment.NewLine + TxtbxLog.Text;
        }

        private (STUN_NetType netType, EndPoint localEndPoint, EndPoint remoteEndPoint) ConnectToSTUN(IPAddress IP, int port)
        {
            //List of STUN
            //https://gist.github.com/zziuni/3741933
            //https://gist.github.com/sagivo/3a4b2f2c7ac6e1b5267c2f1f59ac6c6b

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //socket.Bind(new IPEndPoint(IPAddress.Any, 0));
            //socket.Bind(new IPEndPoint(IPAddress.Any, localPort));
            //socket.Bind(new IPEndPoint(IP, 0));
            socket.Bind(new IPEndPoint(IP, port));

            STUN_Result result = STUN_Client.Query("stun.l.google.com", 19302, socket);
            STUN_NetType netType = result.NetType;
            EndPoint epLocal = socket.LocalEndPoint;
            EndPoint epPublic = null;
            if (result.NetType != STUN_NetType.UdpBlocked)
            {
                epPublic = result.PublicEndPoint;
            }

            Console.WriteLine("NetType = " + netType.ToString());
            AppendTextBox("NetType = " + netType.ToString());
            Console.WriteLine("Local EndPoint = " + epLocal.ToString());
            AppendTextBox("Local EndPoint = " + epLocal.ToString());
            if (epPublic != null)
            {
                Console.WriteLine("Public EndPoint = " + epPublic.ToString());
                AppendTextBox("Public EndPoint = " + epPublic.ToString());
            }
            else
            {
                Console.WriteLine("Public EndPoint = ");
                AppendTextBox("Public EndPoint = ");
            }

            //return (netType, epLocal, epPublic);

            //2 STUN, For TEST

            result = STUN_Client.Query("stun1.l.google.com", 19302, socket);
            netType = result.NetType;
            epLocal = socket.LocalEndPoint;
            epPublic = null;
            if (result.NetType != STUN_NetType.UdpBlocked)
            {
                epPublic = result.PublicEndPoint;
            }

            Console.WriteLine("NetType = " + netType.ToString());
            AppendTextBox("NetType = " + netType.ToString());
            Console.WriteLine("Local EndPoint = " + epLocal.ToString());
            AppendTextBox("Local EndPoint = " + epLocal.ToString());
            if (epPublic != null)
            {
                Console.WriteLine("Public EndPoint = " + epPublic.ToString());
                AppendTextBox("Public EndPoint = " + epPublic.ToString());
            }
            else
            {
                Console.WriteLine("Public EndPoint = ");
                AppendTextBox("Public EndPoint = ");
            }

            socket.Close();

            return (netType, epLocal, epPublic);
        }

        private void BtnStartConnection_Click(object sender, EventArgs e)
        {
            stopSender = false;

            Thread remoteSender = new Thread(() =>
            {
                /*IPEndPoint ep = new IPEndPoint(IPAddress.Parse(TxtbxConnectionRemoteIPValue.Text), Convert.ToInt32(NudConnectionRemotePortValue.Value));

                byte[] msg = Encoding.UTF8.GetBytes("SYN");
                Socket remoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                while (!stopSender)
                {
                    remoteSocket.SendTo(msg, ep);
                    Console.WriteLine("Sent SYN to " + ep.ToString());
                    AppendTextBox("Sent SYN to " + ep.ToString());

                    Thread.Sleep(500);
                }

                remoteSocket.Shutdown(SocketShutdown.Both);
                remoteSocket.Close();*/

                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(TxtbxConnectionRemoteIPValue.Text), Convert.ToInt32(NudConnectionRemotePortValue.Value));
                
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socket.Bind(new IPEndPoint(IPAddress.Any, Convert.ToInt32(NudConnectionRemotePortValue.Value)));

                byte[] msg = Encoding.UTF8.GetBytes("SYN");
                while (!stopSender)
                {
                    socket.SendTo(msg, ep);
                    Console.WriteLine("Sent SYN to " + ep.ToString() + " From " + socket.LocalEndPoint);
                    AppendTextBox("Sent SYN to " + ep.ToString() + " From " + socket.LocalEndPoint);

                    Thread.Sleep(500);
                }
            });

            Thread localSender = new Thread(() =>
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(TxtbxConnectionLocalIPValue.Text), Convert.ToInt32(NudConnectionLocalPortValue.Value));
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);
                socket.Bind(ep);

                byte[] msg = Encoding.UTF8.GetBytes("SYN");

                while (!stopSender)
                {
                    //localSocket.SendTo(msg, ep);
                    socket.SendTo(msg, ep);
                    Console.WriteLine("Sent SYN to " + ep.ToString() + " From " + socket.LocalEndPoint);
                    AppendTextBox("Sent SYN to " + ep.ToString() + " From " + socket.LocalEndPoint);

                    Thread.Sleep(500);
                }

                //localSocket.Shutdown(SocketShutdown.Both);
                //localSocket.Close();

                /*IPEndPoint ep = new IPEndPoint(IPAddress.Parse(TxtbxConnectionLocalIPValue.Text), Convert.ToInt32(NudConnectionLocalPortValue.Value));

                byte[] msg = Encoding.UTF8.GetBytes("SYN");

                while (!stopSender)
                {
                    socket.SendTo(msg, ep);
                    Console.WriteLine("Sent SYN to " + ep.ToString());
                    AppendTextBox("Sent SYN to " + ep.ToString());

                    Thread.Sleep(500);
                }*/
            });

            if (!TxtbxConnectionRemoteIPValue.Text.Equals("") && NudConnectionRemotePortValue.Value != 0)
            {
                remoteSender.Start();
            }
            if (!TxtbxConnectionLocalIPValue.Text.Equals("") && NudConnectionLocalPortValue.Value != 0)
            {
                localSender.Start();
            }
        }

        private void BtnStopConnection_Click(object sender, EventArgs e)
        {
            stopSender = true;
        }

        private void BtnStartListener_Click(object sender, EventArgs e)
        {
            Thread listener = new Thread(() =>
            {
                try
                {
                    stopListener = false;

                    /*EndPoint ep = new IPEndPoint(IPAddress.Parse(TxtbxListenerIP.Text), Convert.ToInt32(NudListenerPort.Value));
                    Socket localSocket = new Socket(SocketType.Dgram, ProtocolType.Udp);

                    localSocket.Bind(ep);

                    Console.WriteLine("Listening on " + ep.ToString());
                    AppendTextBox("Listening on " + ep.ToString());

                    localSocket.ReceiveTimeout = 1000;

                    while (!stopListener)
                    {
                        try
                        {
                            byte[] msg = new byte[localSocket.ReceiveBufferSize];
                            localSocket.Receive(msg);

                            int lastIndex = Array.FindLastIndex(msg, b => b != 0);
                            Array.Resize(ref msg, lastIndex + 1);

                            Console.WriteLine("Received " + Encoding.UTF8.GetString(msg) + " from " + localSocket.LocalEndPoint.ToString());
                            AppendTextBox("Received " + Encoding.UTF8.GetString(msg) + " from " + localSocket.LocalEndPoint.ToString());
                        }
                        catch (SocketException ex)
                        {
                            Console.WriteLine(ex.Message);
                            AppendTextBox(ex.Message);
                        }
                    }

                    localSocket.Shutdown(SocketShutdown.Both);
                    localSocket.Close();*/

                    EndPoint listeningEP = new IPEndPoint(IPAddress.Parse(TxtbxListenerIP.Text), Convert.ToInt32(NudListenerPort.Value));

                    //Console.WriteLine("Listening on " + ep.ToString());
                    //AppendTextBox("Listening on " + ep.ToString());

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    socket.Bind(listeningEP);

                    socket.ReceiveTimeout = 1000;

                    while (!stopListener)
                    {
                        try
                        {
                            Console.WriteLine("Listening on " + socket.LocalEndPoint);
                            AppendTextBox("Listening on " + socket.LocalEndPoint);

                            EndPoint ep = new IPEndPoint(IPAddress.Any, 0);

                            byte[] msg = new byte[socket.ReceiveBufferSize];
                            //socket.SendTo(Encoding.UTF8.GetBytes("test"), new IPEndPoint(IPAddress.Parse("167.86.122.45"), Convert.ToInt32(NudListenerPort.Value)));
                            socket.ReceiveFrom(msg, ref ep);

                            int lastIndex = Array.FindLastIndex(msg, b => b != 0);
                            Array.Resize(ref msg, lastIndex + 1);
                            try
                            {
                                Console.WriteLine("Received " + Encoding.UTF8.GetString(msg) + " from " + ep.ToString());
                                AppendTextBox("Received " + Encoding.UTF8.GetString(msg) + " from " + ep.ToString());
                            }
                            catch (Exception) { }
                        }
                        catch (SocketException ex)
                        {
                            Console.WriteLine(ex.Message);
                            AppendTextBox(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    AppendTextBox(ex.Message);
                }
            });

            listener.Start();
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            stopListener = true;
        }

        private void BtnStartScan_Click(object sender, EventArgs e)
        {
            /*stopScan = false;
            Thread remoteSender = new Thread(() =>
            {
                for (int i = 1; i < 65535; i++)
                {
                    try
                    {
                        if(stopScan)
                        {
                            break;
                        }

                        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(TxtbxScanRemoteIPValue.Text), i);

                        byte[] msg = Encoding.UTF8.GetBytes("SYN");
                        MachineInfo.socket.SendTo(msg, ep);

                        Console.WriteLine("Sent SYN to " + ep.ToString());
                        AppendTextBox("Sent SYN to " + ep.ToString());
                    }
                    catch (Exception ex) { }
                }

                Console.WriteLine("Done");
                AppendTextBox("Done");
            });

            remoteSender.Start();*/
        }

        private void BtnStopScan_Click(object sender, EventArgs e)
        {
            stopScan = true;
        }
    }
}
