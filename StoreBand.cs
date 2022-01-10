using Microsoft.Azure.WebJobs;

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureFunctions.OutputBindings
{
	public static class StoreBand
	{
		[FunctionName("StoreBand")]
		[return: Table("%BandTable%")]
		public static async Task<BandEntity> Run(
			[BlobTrigger("%BandsContainerName%/{name}")] Stream myBlob,
			string name)
		{
			var band = await JsonSerializer.DeserializeAsync<Band>(myBlob, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});

			return new BandEntity
			{
				PartitionKey = band.Genre,
				RowKey = Guid.NewGuid().ToString(),
				Name = band.Name,
				FoundationYear = band.FoundationYear,
				Albums = band.Albums
			};
		}
	}
}
