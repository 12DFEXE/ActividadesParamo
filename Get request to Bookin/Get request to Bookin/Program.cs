using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Get_request_to_Bookin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTests
{
	class GetAndBody
	{
		// Instancia estática de HttpClient, se recomienda reutilizar HttpClient.
		private static readonly HttpClient client = new HttpClient();

		static async Task Main(string[] args)
		{
			// URL del endpoint al que se enviará la solicitud POST
			string url = "https://restful-booker.herokuapp.com/booking";

			try
			{



				// Hacer la solicitud GET de manera asíncrona
				HttpResponseMessage response = await client.GetAsync(url);

				// Leer el contenido de la respuesta como string
				string responseContent = await response.Content.ReadAsStringAsync();

				// Parsear el contenido de la respuesta a JSON (un array de objetos)
				JArray bookingIds = JArray.Parse(responseContent);

				// Validar que la respuesta contiene un array de IDs usando el método AssertBookingIds desde Assertions.cs
				Assertions.AssertBookingIds(bookingIds);

				// Mostrar los resultados
				Console.WriteLine("Request successful!");
				Console.WriteLine($"Numero de bookings: {bookingIds.Count}");
				foreach (var booking in bookingIds)//foreach itera sobre cada objeto (llamado booking) dentro del array bookingIds. bookingIds es un objeto tipo JArray, que contiene varios objetos JSON (cada objeto representa una "reserva" o "booking").
				{
					// Mostrar el bookingid
					Console.WriteLine($"Booking ID: {booking["bookingid"]}");
				}
			}
			catch (Exception Variableex)
			{
				Console.WriteLine($"Ocurrio un Error: {Variableex.Message}");
			}
		}

		
	}
}
