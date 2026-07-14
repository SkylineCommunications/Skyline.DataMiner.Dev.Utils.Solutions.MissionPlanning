namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Repositories.Administrative
{
	using Skyline.DataMiner.SDM.Middleware;
	using Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models;
	using Skyline.DataMiner.SDM;

	public static class AdministrativeDomRepository_Extensions
	{

		public static Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models.Administrative> WithMiddleware(
			this Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models.Administrative> repository,
			IMiddlewareMarker<Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models.Administrative> middleware)
		{
			return new AdministrativeDomRepository_Middleware(repository, middleware);
		}
	}
}
