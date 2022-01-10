
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;

using System.IO;
using System.Threading.Tasks;

namespace AzureFunctions.OutputBindings
{
	public static class BandMessageHandler
	{
		[FunctionName("BandMessageHandler")]
		public static async Task Run(
			[QueueTrigger("%BandQueueName%")] byte[] message,
			[Blob("%BandsContainerName%/{rand-guid}.json", FileAccess.Write)] CloudBlockBlob outputBlob)
		{
			using var ms = new MemoryStream(message);
			await outputBlob.UploadFromStreamAsync(ms);
		}
	}
}
