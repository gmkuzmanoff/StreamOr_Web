using System.Net;

namespace StreamOr.Infrastructure.Constants
{
    public static class RadioMetadata
	{
		public static async Task<string> GetTitle(string uri)
		{
			string result = "";
			HttpClient m_httpClient = new HttpClient();
			HttpResponseMessage? response = null;
			m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
			try
			{
				response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
				m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");
				if (response.IsSuccessStatusCode)
				{
					IEnumerable<string> headerValues;
					if (response.Headers.TryGetValues("icy-name", out headerValues))
					{
						string metaIntString = headerValues.First();
						if (!string.IsNullOrEmpty(metaIntString))
						{
							result = metaIntString;
						}

					}
				}
			}
			catch (Exception)
			{
				
			}
			m_httpClient.Dispose();
			return result;
		}
		public static async Task<string> GetGenre(string uri)
		{
			string result = "";
			HttpClient m_httpClient = new HttpClient();
			HttpResponseMessage? response = null;
			m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
			try
			{
				response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
				m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");

				if (response.IsSuccessStatusCode)
				{
					IEnumerable<string> headerValues;
					if (response.Headers.TryGetValues("icy-genre", out headerValues))
					{
						string metaIntString = headerValues.First();
						if (!string.IsNullOrEmpty(metaIntString))
						{
							result = metaIntString;
						}
					}
				}
			}
			catch (Exception)
			{
			
			}
			m_httpClient.Dispose();
			return result;
		}
		public static async Task<string> GetBitrate(string uri)
		{
			string result = "";
			HttpClient m_httpClient = new HttpClient();
			HttpResponseMessage? response = null;
			m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
			try
			{
				response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
				m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");

				if (response.IsSuccessStatusCode)
				{
					IEnumerable<string> headerValues;
					if (response.Headers.TryGetValues("icy-br", out headerValues))
					{
						string metaIntString = headerValues.First();
						if (!string.IsNullOrEmpty(metaIntString))
						{
							result = metaIntString;
						}
					}
				}
			}
			catch (Exception)
			{
				
			}
			m_httpClient.Dispose();
			return result;
		}
		public static async Task<string> GetDescription(string uri)
		{
			string result = "";
			HttpClient m_httpClient = new HttpClient();
			HttpResponseMessage? response = null;
			m_httpClient.DefaultRequestHeaders.Add("icy-metadata", "1");
			try
			{
				response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
				m_httpClient.DefaultRequestHeaders.Remove("icy-metadata");

				if (response.IsSuccessStatusCode)
				{
					IEnumerable<string> headerValues;
					if (response.Headers.TryGetValues("icy-description", out headerValues))
					{
						string metaIntString = headerValues.First();
						if (!string.IsNullOrEmpty(metaIntString))
						{
							result = metaIntString;
						}
                    }
				}
			}
			catch (Exception)
			{
			
			}
			m_httpClient.Dispose();
			return result;
		}
		public static async Task<string> GetMetaDataFromIceCastStream(string uri)
        {
            string result = "";
            HttpClient m_httpClient = new HttpClient();
            HttpResponseMessage response = null;
            m_httpClient.DefaultRequestHeaders.Add("Icy-MetaData", "1");
			try
			{
				response = await m_httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
			}
			catch
			{
				return result;
			}
			if (response != null)
			{
                m_httpClient.DefaultRequestHeaders.Remove("Icy-MetaData");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<string> headerValues;
                    if (response.Headers.TryGetValues("icy-metaint", out headerValues))
                    {
                        string metaIntString = headerValues.First();
                        if (!string.IsNullOrEmpty(metaIntString))
                        {
                            int metadataInterval = int.Parse(metaIntString);
                            byte[] buffer = new byte[metadataInterval];
							Stream stream = await response.Content.ReadAsStreamAsync();
							int numBytesToRead = metadataInterval;
							int n = 0;
							while (n < numBytesToRead)
							{
								n++;
								stream.ReadByte();
							}

							int lengthOfMetaData = stream.ReadByte();
							int metaBytesToRead = lengthOfMetaData * 16;
							byte[] metadataBytes = new byte[metaBytesToRead];
							var bytesRead = await stream.ReadAsync(metadataBytes, 0, metaBytesToRead);
							result = System.Text.Encoding.UTF8.GetString(metadataBytes);
							stream.Dispose();
						}
                    }
                }
            }
                
            m_httpClient.Dispose();
            return result;
        }
        public static async Task<string> GetNowPlayingTitleFromShoutcastServer(string uri)
        {
            WebResponse response = null;
            string result = "";
            Uri URL = new Uri(uri);
            string finalURL = $"{URL.Scheme}://{URL.Host}/currentsong?sid=#"; 
            WebRequest request = WebRequest.Create(finalURL);

            try
            {
                response = await request.GetResponseAsync();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadLine();
                reader.Close();
            }
            catch
            {

            }
            return result;
        }
    }
}
