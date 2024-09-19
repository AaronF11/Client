using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Cliente TCP para establecer la conexión con el servidor.
        /// </summary>
        TcpClient client;

        /// <summary>
        /// Flujo de red para enviar y recibir datos.
        /// </summary>
        NetworkStream stream;

        /// <summary>
        /// Inicializa una nueva instancia de la clase MainPage.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de clic del botón de conexión. 
        /// Establece una conexión TCP con el servidor y envía datos de autenticación.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
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

                await DisplayAlert("Respuesta", response, "OK");

                if (response == "Autenticacion exitosa")
                {
                    EchoEntry.IsEnabled = true;
                    SendButton.IsEnabled = true;
                    ConnectButton.IsEnabled = false;
                    AuthEntry.IsEnabled = false;
                    DisconnectButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón de envío. 
        /// Envía un mensaje al servidor y espera una respuesta.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    await DisplayAlert("Error", "Cliente no conectado.", "OK");
                    return;
                }

                string message = EchoEntry.Text;
                byte[] data = Encoding.ASCII.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                await DisplayAlert("Respuesta", response, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón de desconexión. 
        /// Envía un mensaje de cierre al servidor y cierra la conexión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private async void DisconnectButton_Clicked(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                byte[] data = Encoding.ASCII.GetBytes("exit");
                await stream.WriteAsync(data, 0, data.Length);
                client.Close();
                await DisplayAlert("Conexión cerrada", "La conexión ha sido cerrada.", "OK");
                EchoEntry.IsEnabled = false;
                SendButton.IsEnabled = false;
                ConnectButton.IsEnabled = true;
                AuthEntry.IsEnabled = true;
                DisconnectButton.IsEnabled = false;
            }
        }
    }
}