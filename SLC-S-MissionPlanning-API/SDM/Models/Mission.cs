using System.Collections.Generic;

using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	[GenerateExposers]
	[SdmDomStorage("(slc)mission_management")]
	public class Mission : SdmObject<Mission>
	{
		public Administrative Administrative { get; set; }

		public CoalitionAndMultinationalContext CoalitionAndMultinationalContext { get; set; }

		public PriorityAndImportance PriorityAndImportance { get; set; }

		public GeographicalArea GeographicalArea { get; set; }

		public List<Service> Services { get; set; } = new List<Service>();
	}
}
