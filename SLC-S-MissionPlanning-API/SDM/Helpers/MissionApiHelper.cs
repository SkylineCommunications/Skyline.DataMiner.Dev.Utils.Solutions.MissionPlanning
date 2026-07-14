using Skyline.DataMiner.Net;
using Skyline.DataMiner.SDM;
using Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models;
using Skyline.DataMiner.Solutions.MissionPlanning.SDM.Repositories.Mission;

using MissionDomRepository = Skyline.DataMiner.Solutions.MissionPlanning.SDM.Repositories.Mission.MissionDomRepository;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Helpers
{
	public class MissionApiHelper : IMissionApiHelper
	{
		private readonly IBulkRepository<Mission> _missions;

		public MissionApiHelper(IConnection connection)
		{
			Connection = connection;

			_missions = new MissionDomRepository(connection);
		}

		public IConnection Connection { get; }

		public IBulkRepository<Mission> Missions { get { return _missions; } }

		//public void Test()
		//{
		//	var m = new Mission
		//	{
		//		Administrative = new Administrative(),
		//		CoalitionAndMultinationalContext = new CoalitionAndMultinationalContext(),
		//		PriorityAndImportance = new PriorityAndImportance(),
		//		GeographicalArea = new GeographicalArea(),
		//		Services = new List<Service>() { new Service() },
		//	};

		//	Missions.Create(m);
		//}
	}
}
