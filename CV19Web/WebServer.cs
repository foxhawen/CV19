﻿using System.Net;

namespace CV19Web
{
    public class WebServer
    {
        //private TcpListener _Listener = new TcpListener(new IPEndPoint(IPAddress.Any, 8080));
        private HttpListener _Listene;
        private readonly int _Port;
        private bool _Enabled;
        private readonly object _SyncRoot = new object();

        public int Port => _Port;

        public bool Enabled { get => _Enabled; set { if (value) Start(); else Stop(); } }

        public WebServer(int Port) => _Port = Port;

        public void Start()
        {
            if (_Enabled) return;
            lock (_SyncRoot)
            {
                if (_Enabled) return;

                _Listene = new HttpListener();
                _Listene.Prefixes.Add($"http://*:{_Port}");
                _Listene.Prefixes.Add($"http://+:{_Port}");
                _Enabled = true;
            }
            Listen();
        }

        public void Stop()
        {
            if (!_Enabled) return;
            lock (_SyncRoot)
            {
                if (!_Enabled) return;

                _Listene = null;
                _Enabled = false;
            }
        }

        private void Listen()
        {

        }

    }
}
