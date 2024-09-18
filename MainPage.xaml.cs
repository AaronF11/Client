using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class MainPage : ContentPage
    {
        TcpClient client;
        NetworkStream stream;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ConnectButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 12345);
                stream = client.GetStream();

                string authData = AuthEntry.Text;
                byte[] data = Encoding.ASCII.GetBytes(authData);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                ResponseLabel.Text = response;

                if (response == "Autenticacion exitosa")
                {
                    EchoEntry.IsEnabled = true;
                    SendButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                ResponseLabel.Text = $"Error: {ex.Message}";
            }
        }

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    ResponseLabel.Text = "Cliente no conectado.";
                    return;
                }

                string message = EchoEntry.Text;
                byte[] data = Encoding.ASCII.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                ResponseLabel.Text = response;
            }
            catch (Exception ex)
            {
                ResponseLabel.Text = $"Error: {ex.Message}";
            }
        }

        private void DisconnectButton_Clicked(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                byte[] data = Encoding.ASCII.GetBytes("exit");
                stream.Write(data, 0, data.Length);
                client.Close();
                ResponseLabel.Text = "Conexion cerrada.";
                EchoEntry.IsEnabled = false;
                SendButton.IsEnabled = false;
            }
        }
    }
}
