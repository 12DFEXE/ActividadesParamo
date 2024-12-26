using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace ApiTests
{
     class PostResponse//La clase principal de la aplicación donde ejecutaremos la lógica de nuestra prueba



	{

		private static readonly HttpClient client = new HttpClient();//Creamos una instancia estática de HttpClient.
																	 //Esto es importante porque HttpClient debe ser reutilizado,




		static async Task Main(string[] args)//El método Main es el punto de entrada en las aplicaciones de consola en C#. Este es un método asíncrono (async), lo que permite realizar operaciones no bloqueantes, como hacer solicitudes HTTP. El tipo Task indica que el método es asíncrono.

		{

			// URL del endpoint
			string url = "https://restful-booker.herokuapp.com/auth";
			// Crear el objeto con las credenciales
			var requestBody = new
			{
				username = "admin",
				password = "password123"
			};

			// Serializar el objeto a JSON
			string jsonRequestBody = JsonConvert.SerializeObject(requestBody);

			// Crear el contenido de la solicitud HTTP
			var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

			// Hacer la solicitud POST de forma asíncrona
			try
			{
				HttpResponseMessage response = await client.PostAsync(url, content);

				// Verificar si la respuesta es exitosa (código 2xx)
				if (response.IsSuccessStatusCode)
				{
					string responseContent = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Request successful!");
					Console.WriteLine("Response: " + responseContent);
				}
				else
				{
					Console.WriteLine($"Request failed with status code: {response.StatusCode}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}
	}
}