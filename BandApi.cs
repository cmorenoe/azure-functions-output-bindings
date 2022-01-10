using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using System.IO;
using System.Threading.Tasks;

namespace AzureFunctions.OutputBindings
{
	public static class BandApi
	{
		[FunctionName("BandApi")]
		[return: Queue("%BandQueueName%")]
		public static async Task<byte[]> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "band")] HttpRequest req)
		{
			using MemoryStream ms = new();
			await req.Body.CopyToAsync(ms);
			return ms.ToArray();
		}
	}
}
