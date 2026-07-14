using Skyline.DataMiner.Net;
using Skyline.DataMiner.SDM;
using Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Helpers
{
	public interface IMissionApiHelper
	{
		/// <summary>
		/// Gets the underlying connection used for communication with the repositories.
		/// </summary>
		IConnection Connection { get; }

		/// <summary>
		/// Gets the repository for <see cref="Mission"/> objects.
		/// </summary>
		IBulkRepository<Mission> Missions { get; }

		///// <summary>
		///// Gets the repository for <see cref="Administrative"/> objects.
		///// </summary>
		//IBulkRepository<Administrative> Administratives { get; }

		///// <summary>
		///// Gets the repository for <see cref="PriorityAndImportance"/> objects.
		///// </summary>
		//IBulkRepository<PriorityAndImportance> PriorityAndImportances { get; }

		///// <summary>
		///// Gets the repository for <see cref="CoalitionAndMultinationalContext"/> objects.
		///// </summary>
		//IBulkRepository<CoalitionAndMultinationalContext> CoalitionAndMultinationalContexts { get; }

		///// <summary>
		///// Gets the repository for <see cref="GeographicalArea"/> objects.
		///// </summary>
		//IBulkRepository<GeographicalArea> GeographicalAreas { get; }

		///// <summary>
		///// Gets the repository for <see cref="Service"/> objects.
		///// </summary>
		//IBulkRepository<Service> Services { get; }
	}
}
