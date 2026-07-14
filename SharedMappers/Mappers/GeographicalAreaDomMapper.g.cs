using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
    [SdmDomMapper]
    public static class GeographicalAreaDomMapper
    {
        internal const string ModuleId = "(slc)mission_management";
        private static readonly DomDefinitionId GeographicalAreaDomDefinitionId = new DomDefinitionId(new Guid("1cca789d-14ac-43c1-97ab-6278b15f838c"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => GeographicalAreaDomDefinitionId;

        public static class GeographicalAreaProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("edd9f511-4269-4da7-a877-e09741c76330"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID AreaOfOperations = new FieldDescriptorID(new Guid("d0778486-3443-42bc-a6c8-bf96438424f9"));
            public static readonly FieldDescriptorID MobilityProfiles = new FieldDescriptorID(new Guid("95c1520d-6966-4a1b-af92-2c89ffc0ef8e"));
        }
    }
}