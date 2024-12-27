using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Get_request_to_Bookin
{
    internal class Assertions
    {




		// Validación de que la respuesta es exitosa (HTTP 200)
		public static void AssertSuccess(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)// lee el response de mas arriba
			{
				throw new Exception($"Request failed with status code: {response.StatusCode}");
			}
		}

		// Validación de que el body contiene un array de objetos con bookingid
		public static void AssertBookingIds(JArray bookingIds)
		{
			// Verifica que el body no esté vacío y contenga al menos un objeto
			if (bookingIds.Count == 0)
			{
				throw new Exception("The response does not contain any booking IDs.");
			}

			// Verifica que cada elemento en el array tenga un "bookingid" y que sea un número entero
			foreach (var booking in bookingIds)
			{
				// Verificar que el "bookingid" sea un número entero
				var bookingId = booking["bookingid"];
				if (bookingId == null || bookingId.Type != JTokenType.Integer)
				{
					throw new Exception($"Invalid ID type found: {bookingId?.Type}. All IDs should be integers.");
				}
			}
		}
	}
}
