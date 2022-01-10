using Microsoft.Azure.Cosmos.Table;

namespace AzureFunctions.OutputBindings
{
	public class BandEntity : TableEntity
	{
		public string Name { get; set; }
		public int FoundationYear { get; set; }
		public int Albums { get; set; }
	}
}
