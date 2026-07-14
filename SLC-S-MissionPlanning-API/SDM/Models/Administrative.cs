using System;

using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	/// <summary>
	/// Represents the administrative information for a mission in the mission planning system.
	/// This class stores core mission metadata including identification, scheduling, and categorization details.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)mission_management")]
	public class Administrative : SdmObject<Administrative>
	{
		/// <summary>
		/// Gets or sets the unique identifier for the mission.
		/// </summary>
		public string MissionID { get; set; }

		/// <summary>
		/// Gets or sets the mission code used for reference and identification purposes.
		/// </summary>
		public string MissionCode { get; set; }

		/// <summary>
		/// Gets or sets the display name of the mission.
		/// </summary>
		public string MissionName { get; set; }

		/// <summary>
		/// Gets or sets the detailed description of the mission, including objectives and scope.
		/// </summary>
		public string MissionDescription { get; set; }

		/// <summary>
		/// Gets or sets the category classification of the mission.
		/// </summary>
		public MissionCategory MissionCategory { get; set; }

		/// <summary>
		/// Gets or sets the start date and time of the mission.
		/// </summary>
		public DateTime MissionStart { get; set; }

		/// <summary>
		/// Gets or sets the end date and time of the mission.
		/// </summary>
		public DateTime MissionEnd { get; set; }
	}
}
