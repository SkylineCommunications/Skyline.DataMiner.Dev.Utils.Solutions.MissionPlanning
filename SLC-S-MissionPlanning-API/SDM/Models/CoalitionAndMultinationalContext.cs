using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	/// <summary>
	/// Represents the coalition and multinational context for a mission, including coalition details and participating nations.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)mission_management")]
	public class CoalitionAndMultinationalContext : SdmObject<CoalitionAndMultinationalContext>
	{
		/// <summary>
		/// Gets or sets a value indicating whether the mission is part of a coalition.
		/// </summary>
		public bool CoalitionFlag { get; set; }

		/// <summary>
		/// Gets or sets the name of the coalition.
		/// </summary>
		public string CoalitionName { get; set; }

		/// <summary>
		/// Gets or sets the nations participating in the coalition.
		/// </summary>
		public string ParticipatingNations { get; set; }

		/// <summary>
		/// Gets or sets the lead nation of the coalition.
		/// </summary>
		public LeadNation LeadNation { get; set; }
	}
}
