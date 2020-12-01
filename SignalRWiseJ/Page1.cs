using SignalRLib;
using System;
using Wisej.Web;

namespace SignalRWiseJ {

    public partial class Page1 : Page {

        HubConnector connector;

        public Page1() {
            InitializeComponent();

            connector = new HubConnector("http://localhost:5000/notifications");
            connector.Connect();

            connector.MessageReceived += Connector_MessageReceived;
        }

        private void Connector_MessageReceived(string obj) {
            textBox1.Text = obj;
            Application.Update(textBox1);
        }
    }
}
