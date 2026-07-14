using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
    [SdmDomMapper]
    public static class PriorityAndImportanceDomMapper
    {
        internal const string ModuleId = "(slc)mission_management";
        private static readonly DomDefinitionId PriorityAndImportanceDomDefinitionId = new DomDefinitionId(new Guid("a7d6573a-3957-4dd1-bba3-0364f52aae0b"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => PriorityAndImportanceDomDefinitionId;

        public static class PriorityAndImportanceProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("fb271bb0-f7bd-4e48-8877-b89a04cb8150"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID Priority = new FieldDescriptorID(new Guid("35db713a-3d5d-43d4-87e6-52dfbaa2df7f"));
            public static readonly FieldDescriptorID Criticality = new FieldDescriptorID(new Guid("5242588a-4c53-48c8-b6ef-a9782df016d8"));
        }
    }
}