using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
    [SdmDomMapper]
    public static class CoalitionAndMultinationalContextDomMapper
    {
        internal const string ModuleId = "(slc)mission_management";
        private static readonly DomDefinitionId CoalitionAndMultinationalContextDomDefinitionId = new DomDefinitionId(new Guid("84c933b1-a072-4bbb-80b9-24e0c9b8fe8f"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => CoalitionAndMultinationalContextDomDefinitionId;

        public static class CoalitionAndMultinationalContextProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("c2fa69b3-484f-44be-9d97-3fbf8bbcefa1"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID CoalitionFlag = new FieldDescriptorID(new Guid("4a0284ad-0011-4377-ab2b-86b285024d96"));
            public static readonly FieldDescriptorID CoalitionName = new FieldDescriptorID(new Guid("f1b200c4-0cef-4d78-b2e4-5adc4a3d80a4"));
            public static readonly FieldDescriptorID ParticipatingNations = new FieldDescriptorID(new Guid("bf05bdb6-abea-4400-a31a-f1389196fd6e"));
            public static readonly FieldDescriptorID LeadNation = new FieldDescriptorID(new Guid("63e6c0d8-3c7d-4809-bb50-818fc9e4d24b"));
        }
    }
}