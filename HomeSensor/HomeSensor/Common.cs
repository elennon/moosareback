using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace HomeSensor
{
	public static class Common
	{
		public static string JsonSerializer(object objectToSerialize)
		{
			if (objectToSerialize == null)
			{
				throw new ArgumentException("objectToSerialize must not be null");
			}
			MemoryStream ms = null;
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(objectToSerialize.GetType());
			ms = new MemoryStream();
			serializer.WriteObject(ms, objectToSerialize);
			ms.Seek(0, SeekOrigin.Begin);
			StreamReader sr = new StreamReader(ms);
			return sr.ReadToEnd();
		}

		public static T deserializeJSON<T>(string json)
		{
			var instance = typeof(T);

			using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				DataContractJsonSerializer deserializer = new DataContractJsonSerializer(instance.GetType());
				return (T)deserializer.ReadObject(ms);
			}
		}

	}
}

