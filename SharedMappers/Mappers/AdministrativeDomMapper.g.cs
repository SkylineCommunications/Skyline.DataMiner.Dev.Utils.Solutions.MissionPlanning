using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
    [SdmDomMapper]
    public static class AdministrativeDomMapper
    {
        internal const string ModuleId = "(slc)mission_management";
        private static readonly DomDefinitionId AdministrativeDomDefinitionId = new DomDefinitionId(new Guid("2d39634b-1ef7-4b33-907f-a57aedeb9eaa"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => AdministrativeDomDefinitionId;

        public static class AdministrativeProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("6ca224ff-9882-48b9-9e5c-d8109c0ae012"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID MissionID = new FieldDescriptorID(new Guid("dad1dc9c-9611-45ce-b053-d944726eb24d"));
            public static readonly FieldDescriptorID MissionCode = new FieldDescriptorID(new Guid("4decfd24-2a47-4fe5-9c82-1a90f1c15e66"));
            public static readonly FieldDescriptorID MissionName = new FieldDescriptorID(new Guid("498ee835-7bb5-48b3-8569-44be0bf23b0b"));
            public static readonly FieldDescriptorID MissionDescription = new FieldDescriptorID(new Guid("c9bb84b2-aeed-4f8f-b96d-0e02f3fa8b18"));
            public static readonly FieldDescriptorID MissionCategory = new FieldDescriptorID(new Guid("a5222a10-9360-4515-9b0a-05c9647e00ae"));
            public static readonly FieldDescriptorID MissionStart = new FieldDescriptorID(new Guid("b907c23f-6a86-45d9-8dca-0ac86e4a7aea"));
            public static readonly FieldDescriptorID MissionEnd = new FieldDescriptorID(new Guid("56b189b9-6038-4454-9771-64d590484098"));
        }
    }
}