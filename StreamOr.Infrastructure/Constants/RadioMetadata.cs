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
	}
}
