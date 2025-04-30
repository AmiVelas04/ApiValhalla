using Microsoft.AspNetCore.SignalR;
namespace ApiValhalla.Hubs
{
    public class Notifications:Hub
    {
        public async Task NewPreparacion(string Mesa,string prepa)
        {
            await Clients.Others.SendAsync("Notificacion",Mesa,prepa);
            Console.WriteLine("Datos enviados desde el servidor: {0} y {1}",Mesa,prepa);
        }
    }
}
