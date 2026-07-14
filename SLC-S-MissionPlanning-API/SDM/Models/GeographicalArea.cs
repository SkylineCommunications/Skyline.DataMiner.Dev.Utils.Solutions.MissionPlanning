using System.Collections.Generic;

using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	/// <summary>
	/// Represents a geographical area within the mission planning domain.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)mission_management")]
	public class GeographicalArea : SdmObject<GeographicalArea>
	{
		/// <summary>
		/// Gets or sets the area of operations associated with this geographical area.
		/// </summary>
		public string AreaOfOperations { get; set; }

		/// <summary>
		/// Gets or sets the list of mobility profiles associated with this geographical area.
		/// </summary>
		public string MobilityProfiles { get; set; }
	}
}
