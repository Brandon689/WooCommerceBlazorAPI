namespace FacadeAPI
{

    class xo
    {
        HttpClient client;
        public xo()
        {
            client = new HttpClient();
        }
        public async Task co(string url, string filePath)
        {
            using (var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
