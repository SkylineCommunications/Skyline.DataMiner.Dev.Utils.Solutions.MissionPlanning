using System;
using System.Collections.Generic;
using System.Linq;

using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.Concatenation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.Status;
using Skyline.DataMiner.Net.Apps.Modules;
using Skyline.DataMiner.Net.Apps.Sections.SectionDefinitions;
using Skyline.DataMiner.Net.GenericEnums;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models;
using Skyline.DataMiner.Utils.DOM.Builders;

namespace DevPack.Installer.DOM
{
	public partial class DomInstaller
	{
		private const string ModuleId = "(slc)mission_management";
		private const string ServiceManagementModuleId = "(slc)servicemanagement";
		private const string ServiceProfileDefinitionId = "b3c7ef51-4f9a-44c1-9572-b8641c47f2b3";
		private const string ServicesDefinitionId = "d50bac89-6629-4f3b-aff0-05a57cb7e70d";
		private readonly Guid missionBehaviorDefinitionId = new Guid("8f2d6c41-9b7e-4a53-b8d2-1f6e9c4a73ab");

		private readonly IConnection _connection;
		private readonly Action<string> _logMethod;

		public DomInstaller(IConnection connection, Action<string> logMethod = null)
		{
			_connection = connection;
			_logMethod = logMethod;
		}

		public void InstallDefaultContent()
		{
			Log("Installation for MissionPlanning DOM module started...");

			var moduleHelper = new ModuleSettingsHelper(_connection.HandleMessages);
			var moduleExist = moduleHelper.ModuleSettings.Count(ModuleSettingsExposers.ModuleId.Equal(ModuleId)) == 0;
			if (!moduleExist)
			{
				Log("Installing Module Settings...");
			}
			else
			{
				Log("Updating Module Settings...");
			}

			var module = new DomModuleBuilder()
				.WithModuleId(ModuleId)
				.WithInformationEvents(false)
				.WithHistory(true)
				.Build();
			Import(moduleHelper.ModuleSettings, ModuleSettingsExposers.ModuleId.Equal(ModuleId), module);

			if (!moduleExist)
			{
				Log("Installed MissionPlanning Module Settings");
			}
			else
			{
				Log("Updated MissionPlanning Module Settings");
			}

			var domHelper = new DomHelper(_connection.HandleMessages, ModuleId);
			InstallAllSections(domHelper);
			InstallAllDefinitions(domHelper);
			InstallBehaviorDefinition(domHelper);
		}

		private void Log(string message)
		{
			_logMethod?.Invoke($"[MissionPlanning.Installer.DOM]: {message}");
		}

		private void Import<T>(ICrudHelperComponent<T> crudHelperComponent, FilterElement<T> equalityFilter, T dataType)
			where T : DataType
		{
			bool exists = crudHelperComponent.Read(equalityFilter).Any();

			if (exists)
			{
				crudHelperComponent.Update(dataType);
			}
			else
			{
				crudHelperComponent.Create(dataType);
			}
		}

		#region Sections

		private void InstallAdministrativeSection(DomHelper helper)
		{
			Log("Installing Administrative section...");
			var section = new SectionDefinitionBuilder()
				.WithID(AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId)
				.WithName("Administrative")
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionID)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionID))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The unique identifier for the mission."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionCode)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionCode))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The mission code used for reference and identification purposes."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionName)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionName))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The display name of the mission."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionDescription)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionDescription))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The detailed description of the mission."))
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionCategory)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionCategory))
					.WithIsOptional(false)
					.WithTooltip("The category classification of the mission.")
					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.ISR), (int)MissionCategory.ISR))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.TacticalOperation), (int)MissionCategory.TacticalOperation))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.StrategicOperation), (int)MissionCategory.StrategicOperation))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.Humanitarian), (int)MissionCategory.Humanitarian))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.MaritimeSecurity), (int)MissionCategory.MaritimeSecurity))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.BorderControl), (int)MissionCategory.BorderControl))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.AirborneOperation), (int)MissionCategory.AirborneOperation))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.SpecialForces), (int)MissionCategory.SpecialForces))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.Exercise), (int)MissionCategory.Exercise))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.DisasterResponse), (int)MissionCategory.DisasterResponse))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.LogisticsSupport), (int)MissionCategory.LogisticsSupport))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.CyberOperation), (int)MissionCategory.CyberOperation))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCategory.Support), (int)MissionCategory.Support)))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionStart)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionStart))
					.WithType(typeof(DateTime))
					.WithIsOptional(false)
					.WithTooltip("The start date and time of the mission."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(AdministrativeDomMapper.AdministrativeProperties.MissionEnd)
					.WithName(nameof(AdministrativeDomMapper.AdministrativeProperties.MissionEnd))
					.WithType(typeof(DateTime))
					.WithIsOptional(false)
					.WithTooltip("The end date and time of the mission."))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId.Id), section);
		}

		private void InstallCoalitionAndMultinationalContextSection(DomHelper helper)
		{
			Log("Installing CoalitionAndMultinationalContext section...");
			var section = new SectionDefinitionBuilder()
				.WithID(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.SectionDefinitionId)
				.WithName("Coalition And Multinational Context")
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.CoalitionFlag)
					.WithName(nameof(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.CoalitionFlag))
					.WithType(typeof(bool))
					.WithIsOptional(false)
					.WithTooltip("Indicates whether this context involves a coalition."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.CoalitionName)
					.WithName(nameof(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.CoalitionName))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The name of the coalition."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.ParticipatingNations)
					.WithName(nameof(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.ParticipatingNations))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The participating nations in the coalition."))
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
					.WithID(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.LeadNation)
					.WithName(nameof(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.LeadNation))
					.WithIsOptional(true)
					.WithTooltip("The lead nation of the coalition.")
					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Albania), (int)LeadNation.Albania))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Belgium), (int)LeadNation.Belgium))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Bulgaria), (int)LeadNation.Bulgaria))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Canada), (int)LeadNation.Canada))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Croatia), (int)LeadNation.Croatia))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.CzechRepublic), (int)LeadNation.CzechRepublic))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Denmark), (int)LeadNation.Denmark))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Estonia), (int)LeadNation.Estonia))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Finland), (int)LeadNation.Finland))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.France), (int)LeadNation.France))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Germany), (int)LeadNation.Germany))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Greece), (int)LeadNation.Greece))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Hungary), (int)LeadNation.Hungary))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Iceland), (int)LeadNation.Iceland))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Italy), (int)LeadNation.Italy))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Latvia), (int)LeadNation.Latvia))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Lithuania), (int)LeadNation.Lithuania))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Luxembourg), (int)LeadNation.Luxembourg))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Montenegro), (int)LeadNation.Montenegro))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Netherlands), (int)LeadNation.Netherlands))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.NorthMacedonia), (int)LeadNation.NorthMacedonia))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Norway), (int)LeadNation.Norway))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Poland), (int)LeadNation.Poland))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Portugal), (int)LeadNation.Portugal))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Romania), (int)LeadNation.Romania))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Slovakia), (int)LeadNation.Slovakia))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Slovenia), (int)LeadNation.Slovenia))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Spain), (int)LeadNation.Spain))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Sweden), (int)LeadNation.Sweden))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.Turkey), (int)LeadNation.Turkey))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.UnitedKingdom), (int)LeadNation.UnitedKingdom))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(LeadNation.UnitedStates), (int)LeadNation.UnitedStates)))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.SectionDefinitionId.Id), section);
		}

		private void InstallPriorityAndImportanceSection(DomHelper helper)
		{
			Log("Installing Priority And Importance section...");
			var section = new SectionDefinitionBuilder()
				.WithID(PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.SectionDefinitionId)
				.WithName("Priority And Importance")
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
					.WithID(PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.Priority)
					.WithName(nameof(PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.Priority))
					.WithIsOptional(false)
					.WithTooltip("The priority level of the mission.")
					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionPriority.Routine), (int)MissionPriority.Routine))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionPriority.Elevated), (int)MissionPriority.Elevated))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionPriority.High), (int)MissionPriority.High))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionPriority.Strategic), (int)MissionPriority.Strategic)))
				.AddFieldDescriptor(new GenericEnumFieldDescriptorBuilder()
					.WithID(PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.Criticality)
					.WithName(nameof(PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.Criticality))
					.WithIsOptional(false)
					.WithTooltip("The criticality level of the mission.")
					.WithEnumType(GenericEnumFieldDescriptorBuilder.EnumType.Int)
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCriticality.NonEssential), (int)MissionCriticality.NonEssential))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCriticality.Important), (int)MissionCriticality.Important))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCriticality.Essential), (int)MissionCriticality.Essential))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCriticality.MissionCritical), (int)MissionCriticality.MissionCritical))
					.AddEnumValue(new GenericEnumEntry<int>(nameof(MissionCriticality.NationalCritical), (int)MissionCriticality.NationalCritical)))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.SectionDefinitionId.Id), section);
		}

		private void InstallGeographicalAreaSection(DomHelper helper)
		{
			Log("Installing Geographical Area section...");
			var section = new SectionDefinitionBuilder()
				.WithID(GeographicalAreaDomMapper.GeographicalAreaProperties.SectionDefinitionId)
				.WithName("Geographical Area")
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(GeographicalAreaDomMapper.GeographicalAreaProperties.AreaOfOperations)
					.WithName(nameof(GeographicalAreaDomMapper.GeographicalAreaProperties.AreaOfOperations))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The area of operations associated with this geographical area."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(GeographicalAreaDomMapper.GeographicalAreaProperties.MobilityProfiles)
					.WithName(nameof(GeographicalAreaDomMapper.GeographicalAreaProperties.MobilityProfiles))
					.WithType(typeof(string))
					.WithIsOptional(true)
					.WithTooltip("The mobility profiles associated with this geographical area."))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(GeographicalAreaDomMapper.GeographicalAreaProperties.SectionDefinitionId.Id), section);
		}

		private void InstallServiceSection(DomHelper helper)
		{
			Log("Installing Service section...");
			var section = new SectionDefinitionBuilder()
				.WithID(ServiceDomMapper.ServiceProperties.SectionDefinitionId)
				.WithName("Service")
				.AddFieldDescriptor(new DomInstanceFieldDescriptorBuilder()
					.WithID(ServiceDomMapper.ServiceProperties.ServiceID)
					.WithName(nameof(ServiceDomMapper.ServiceProperties.ServiceID))
					.WithType(typeof(Guid))
					.WithIsOptional(false)
					.WithModule(ServiceManagementModuleId)
					.WithDefinitions(new[] { new DomDefinitionId(new Guid(ServicesDefinitionId)) })
					.WithTooltip("The unique identifier of the service."))
				.AddFieldDescriptor(new FieldDescriptorBuilder()
					.WithID(ServiceDomMapper.ServiceProperties.Name)
					.WithName(nameof(ServiceDomMapper.ServiceProperties.Name))
					.WithType(typeof(string))
					.WithIsOptional(false)
					.WithTooltip("The name of the service."))
				.AddFieldDescriptor(new DomInstanceFieldDescriptorBuilder()
					.WithID(ServiceDomMapper.ServiceProperties.Profile)
					.WithName(nameof(ServiceDomMapper.ServiceProperties.Profile))
					.WithType(typeof(Guid))
					.WithIsOptional(false)
					.WithModule(ServiceManagementModuleId)
					.WithDefinitions(new[] { new DomDefinitionId(new Guid(ServiceProfileDefinitionId)) })
					.WithTooltip("The unique identifier of the profile associated with the service."))
				.Build();

			Import(helper.SectionDefinitions, SectionDefinitionExposers.ID.Equal(ServiceDomMapper.ServiceProperties.SectionDefinitionId.Id), section);
		}

		#endregion

		#region Definitions
		private void InstallMissionDefinition(DomHelper helper)
		{
			Log("Installing Mission definition...");
			var missionDefinition = new DomDefinitionBuilder()
				.WithID(MissionDomMapper.DomDefinitionId)
				.WithName("Mission")
				.AddSectionDefinitionLink(new SectionDefinitionLink
				{
					SectionDefinitionID = AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.AddSectionDefinitionLink(new SectionDefinitionLink
				{
					SectionDefinitionID = PriorityAndImportanceDomMapper.PriorityAndImportanceProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.AddSectionDefinitionLink(new SectionDefinitionLink
				{
					SectionDefinitionID = CoalitionAndMultinationalContextDomMapper.CoalitionAndMultinationalContextProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.AddSectionDefinitionLink(new SectionDefinitionLink
				{
					SectionDefinitionID = GeographicalAreaDomMapper.GeographicalAreaProperties.SectionDefinitionId,
					AllowMultipleSections = false,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.AddSectionDefinitionLink(new SectionDefinitionLink
				{
					SectionDefinitionID = ServiceDomMapper.ServiceProperties.SectionDefinitionId,
					AllowMultipleSections = true,
					IsOptional = false,
					IsSoftDeleted = false,
				})
				.Build();

			// Ensure ModuleSettingsOverrides is not null before setting NameDefinition
			if (missionDefinition.ModuleSettingsOverrides == null)
			{
				missionDefinition.ModuleSettingsOverrides = new ModuleSettingsOverrides();
			}

			// Set instance naming definition on the DomDefinition level (takes priority over module level)
			missionDefinition.ModuleSettingsOverrides.NameDefinition = new DomInstanceNameDefinition
			{
				ConcatenationItems = new List<IDomInstanceConcatenationItem>
				{
					new FieldValueConcatenationItem { FieldDescriptorId = AdministrativeDomMapper.AdministrativeProperties.MissionName },
				},
			};

			Import(helper.DomDefinitions, DomDefinitionExposers.Id.Equal(MissionDomMapper.DomDefinitionId.Id), missionDefinition);
		}

		#endregion

		private void InstallBehaviorDefinition(DomHelper helper)
		{
			Log("Installing Mission behavior definition...");
			var behaviorDefinition = new DomBehaviorDefinition()
			{
				ID = new DomBehaviorDefinitionId(missionBehaviorDefinitionId),
				Name = "Mission",
				Statuses = new List<DomStatus>()
				{
					new DomStatus("draft", "Draft"),
					new DomStatus("confirmed", "Confirmed"),
					new DomStatus("active", "Active"),
					new DomStatus("completed", "Completed"),
					new DomStatus("deprecated", "Deprecated"),
				},
				InitialStatusId = "draft",
				StatusSectionDefinitionLinks = new List<DomStatusSectionDefinitionLink>()
				{
					new DomStatusSectionDefinitionLink(new DomStatusSectionDefinitionLinkId("draft", AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId))
					{
						FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>
						{
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionID),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCode),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionName),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionDescription),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCategory),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionStart),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionEnd),
						},
					},
					new DomStatusSectionDefinitionLink(new DomStatusSectionDefinitionLinkId("confirmed", AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId))
					{
						FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>
						{
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionID),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCode),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionName),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionDescription),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCategory),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionStart),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionEnd),
						},
					},
					new DomStatusSectionDefinitionLink(new DomStatusSectionDefinitionLinkId("active", AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId))
					{
						FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>
						{
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionID),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCode),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionName),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionDescription),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCategory),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionStart),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionEnd),
						},
					},
					new DomStatusSectionDefinitionLink(new DomStatusSectionDefinitionLinkId("completed", AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId))
					{
						FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>
						{
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionID),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCode),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionName),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionDescription),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCategory),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionStart),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionEnd),
						},
					},
					new DomStatusSectionDefinitionLink(new DomStatusSectionDefinitionLinkId("deprecated", AdministrativeDomMapper.AdministrativeProperties.SectionDefinitionId))
					{
						FieldDescriptorLinks = new List<DomStatusFieldDescriptorLink>
						{
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionID),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCode),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionName),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionDescription),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionCategory),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionStart),
							new DomStatusFieldDescriptorLink(AdministrativeDomMapper.AdministrativeProperties.MissionEnd),
						},
					},
				},
				StatusTransitions = new List<DomStatusTransition>()
				{
					new DomStatusTransition("draft_to_confirmed", "draft", "confirmed"),
					new DomStatusTransition("confirmed_to_active", "confirmed", "active"),
					new DomStatusTransition("active_to_completed", "active", "completed"),
					new DomStatusTransition("draft_to_deprecated", "draft", "deprecated")
					{
						FlowLevel = 1,
					},
					new DomStatusTransition("confirmed_to_deprecated", "confirmed", "deprecated")
					{
						FlowLevel = 1,
					},
				},
			};

			Import(helper.DomBehaviorDefinitions, DomBehaviorDefinitionExposers.Id.Equal(behaviorDefinition.ID), behaviorDefinition);
		}

		private void InstallAllSections(DomHelper helper)
		{
			InstallAdministrativeSection(helper);
			InstallCoalitionAndMultinationalContextSection(helper);
			InstallPriorityAndImportanceSection(helper);
			InstallGeographicalAreaSection(helper);
			InstallServiceSection(helper);
		}

		private void InstallAllDefinitions(DomHelper helper)
		{
			InstallMissionDefinition(helper);
		}
	}
}
