﻿using CV19.Services.Interfaces;

namespace CV19.Services
{
    internal class HttpListnerWebServerer : IWebServerService 
    {
        public bool Enabled { get; set; }
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }
    }
}
