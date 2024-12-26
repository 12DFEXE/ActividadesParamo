using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiTests
{
	class PostResponse
	{
		// Instancia estática de HttpClient, se recomienda reutilizar HttpClient.
		private static readonly HttpClient client = new HttpClient();

		static async Task Main(string[] args)
		{
			// URL del endpoint al que se enviará la solicitud POST
			string url = "https://restful-booker.herokuapp.com/auth";

			// Crear el objeto con las credenciales que se enviarán en el cuerpo de la solicitud
			var requestBody = new
			{
				username = "admin",
				password = "password123"
			};

			// Serializar el objeto requestBody a una cadena JSON usando Newtonsoft.Json
			string jsonRequestBody = JsonConvert.SerializeObject(requestBody);

			// Crear el contenido de la solicitud HTTP (usando UTF-8 y estableciendo el tipo de contenido a "application/json")
			var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

			try
			{
				// Realizar la solicitud POST de forma asíncrona
				HttpResponseMessage response = await client.PostAsync(url, content);

				// Verificar si la respuesta es exitosa (código 2xx)
				if (response.IsSuccessStatusCode)
				{
					// Leer y mostrar el contenido de la respuesta si fue exitosa
					string responseContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Request successful!");
					Console.WriteLine("Response: " + responseContent);
				}
				else
				{
					// Si la respuesta no es exitosa, mostrar el código de estado HTTP
					Console.WriteLine($"Request failed with status code: {response.StatusCode}");
					string errorContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Error details: " + errorContent);
				}
			}
			catch (HttpRequestException httpRequestException)
			{
				// Manejar excepciones relacionadas con HTTP
				Console.WriteLine($"An error occurred while sending the request: {httpRequestException.Message}");
			}
			catch (Exception ex)
			{
				// Manejar cualquier otra excepción
				Console.WriteLine($"An unexpected error occurred: {ex.Message}");
			}
		}
	}
}
