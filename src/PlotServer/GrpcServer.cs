using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grpc.Core;
using GrpcPlotServer;

namespace PlotServer
{
    class PlotServer : GrpcPlotServer.PlotServer.PlotServerBase
    {

        private Grpc.Core.Server _server;
        private static PlotServer _instance;
        public static PlotServer Instance => _instance;
        public EventHandler<LoadFileEventArgs> LoadFile;

        public PlotServer(string host, int port = 48133)
        {
            _instance = this;
            if (host != "localhost")
            {
                string localIp;
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", port);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIp = endPoint.Address.ToString();
                }
                host = localIp;
            }

            _server = new Grpc.Core.Server
            {
                Services = {GrpcPlotServer.PlotServer.BindService(this)},
                Ports = {new ServerPort(host, port, ServerCredentials.Insecure)},
            };
            _server.Start();
//			LogLine($"Server started {host} {port}");
        }

        public override Task<EmptyMsg> Heartbeat(EmptyMsg request, ServerCallContext context)
        {
            return new Task<EmptyMsg>(() => new EmptyMsg());
        }

        public override Task<EmptyMsg> PlotFile(PlotMsg request, ServerCallContext context)
        {
            LoadFile?.Invoke(this, new LoadFileEventArgs(request.FileName));
            return new Task<EmptyMsg>(() => new EmptyMsg());
        }
    }

    public class LoadFileEventArgs : EventArgs
    {
        public string FileName { get; }

        public LoadFileEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }

}
