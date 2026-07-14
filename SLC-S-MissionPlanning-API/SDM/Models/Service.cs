using System;

using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	/// <summary>
	/// Represents a service in the SDM model.
	/// </summary>
	[GenerateExposers]
	[SdmDomStorage("(slc)mission_management")]
	public class Service : SdmObject<Service>
	{
		/// <summary>
		/// Gets or sets the unique identifier of the service.
		/// </summary>
		public Guid ServiceID { get; set; }

		/// <summary>
		/// Gets or sets the name of the service.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the profile associated with the service.
		/// </summary>
		public Guid Profile { get; set; }
	}
}
