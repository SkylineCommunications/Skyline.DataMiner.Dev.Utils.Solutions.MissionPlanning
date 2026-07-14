namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Repositories.Mission
{
	using Skyline.DataMiner.SDM.Middleware;
	using Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models;
	using Skyline.DataMiner.SDM;

	public static class MissionDomRepository_Extensions
	{

		public static Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models.Mission> WithMiddleware(
			this Skyline.DataMiner.SDM.IBulkRepository<Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models.Mission> repository,
			IMiddlewareMarker<Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models.Mission> middleware)
		{
			return new MissionDomRepository_Middleware(repository, middleware);
		}
	}
}
