using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	/// <summary>
	/// Represents the priority and importance attributes associated with a mission.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)mission_management")]
	public class PriorityAndImportance : SdmObject<PriorityAndImportance>
	{
		/// <summary>
		/// Gets or sets the priority level of the mission.
		/// </summary>
		public MissionPriority Priority { get; set; }

		/// <summary>
		/// Gets or sets the criticality level of the mission.
		/// </summary>
		public MissionCriticality Criticality { get; set; }
	}
}
