namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
	public enum MissionCategory
	{
		ISR ,
		TacticalOperation,
		StrategicOperation,
		Humanitarian,
		MaritimeSecurity,
		BorderControl,
		AirborneOperation,
		SpecialForces,
		Exercise,
		DisasterResponse,
		LogisticsSupport,
		CyberOperation,
		Support,
	}

	public enum MissionCriticality
	{
		NonEssential,
		Important,
		Essential,
		MissionCritical,
		NationalCritical,
	}

	public enum MissionPriority
	{
		Routine,
		Elevated,
		High,
		Strategic,
	}

	public enum LeadNation
	{
		Albania,
		Belgium,
		Bulgaria,
		Canada,
		Croatia,
		CzechRepublic,
		Denmark,
		Estonia,
		Finland,
		France,
		Germany,
		Greece,
		Hungary,
		Iceland,
		Italy,
		Latvia,
		Lithuania,
		Luxembourg,
		Montenegro,
		Netherlands,
		NorthMacedonia,
		Norway,
		Poland,
		Portugal,
		Romania,
		Slovakia,
		Slovenia,
		Spain,
		Sweden,
		Turkey,
		UnitedKingdom,
		UnitedStates,
	}

	public enum MobilityProfile
	{
		Static,
		Maritime,
		Airborne,
		LandMobile,
	}
}
