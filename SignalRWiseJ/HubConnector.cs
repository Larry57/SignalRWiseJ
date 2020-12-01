using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRLib {
    public class HubConnector {
        HubConnection hub;
        
        public event Action<string> MessageReceived;

        public HubConnector(string address) {
            this.hub = new HubConnectionBuilder().WithUrl(address).Build();
            this.hub.On<string>("Message", s=> MessageReceived?.Invoke(s));
        }

        public Task Connect() {
            return this.hub.StartAsync();
        }
    }
}
