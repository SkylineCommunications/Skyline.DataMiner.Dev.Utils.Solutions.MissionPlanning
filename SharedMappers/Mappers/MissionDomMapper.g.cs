using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
    [SdmDomMapper]
    public static class MissionDomMapper
    {
        internal const string ModuleId = "(slc)mission_management";
        private static readonly DomDefinitionId MissionDomDefinitionId = new DomDefinitionId(new Guid("70a126c2-4b52-4fe0-ba90-19b6bb727c61"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => MissionDomDefinitionId;

		public static class Administrative
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("d0916055-8a2f-459c-b701-c1c3076cc797"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID MissionID = new FieldDescriptorID(new Guid("320a5138-e00f-4e84-9aa2-7905dfaaf06a"));
            public static readonly FieldDescriptorID MissionCode = new FieldDescriptorID(new Guid("e2c51eb1-11cb-4b3c-ba38-b8e55f09c643"));
            public static readonly FieldDescriptorID MissionName = new FieldDescriptorID(new Guid("ad18c763-f377-442b-bd7a-7c706989948c"));
            public static readonly FieldDescriptorID MissionDescription = new FieldDescriptorID(new Guid("02d36304-8475-4d34-8388-86e04750e520"));
            public static readonly FieldDescriptorID MissionCategory = new FieldDescriptorID(new Guid("62364e2f-f0e5-4a67-9253-6d60b3783362"));
            public static readonly FieldDescriptorID MissionStart = new FieldDescriptorID(new Guid("f3839223-e9c4-4f4e-b546-9c08a82669c0"));
            public static readonly FieldDescriptorID MissionEnd = new FieldDescriptorID(new Guid("d447f25d-9b37-41cb-902e-1409c394e52e"));
        }

        public static class CoalitionAndMultinationalContext
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("917aa5f9-fd86-4a38-a9cc-3b728fbff83a"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID CoalitionFlag = new FieldDescriptorID(new Guid("3db0589a-d630-47da-9cea-a601433a90e7"));
            public static readonly FieldDescriptorID CoalitionName = new FieldDescriptorID(new Guid("59eaae0a-7a8c-46e9-84d2-f40837f609f4"));
            public static readonly FieldDescriptorID ParticipatingNations = new FieldDescriptorID(new Guid("8e999809-0679-43a7-ae0d-064aef884d2a"));
            public static readonly FieldDescriptorID LeadNation = new FieldDescriptorID(new Guid("5467c766-9313-4898-b7f5-a29b13530d09"));
        }

        public static class PriorityAndImportance
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("6824a303-dbc2-4e49-9d85-930b0e7ee734"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID Priority = new FieldDescriptorID(new Guid("c1778481-5413-49d2-bd09-6fc22722f549"));
            public static readonly FieldDescriptorID Criticality = new FieldDescriptorID(new Guid("fcfd5aba-f2d1-4b03-9522-dad8fabb75bf"));
        }

        public static class GeographicalArea
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("ecff4ae5-8b94-46cc-b1dc-73190d312937"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID AreaOfOperations = new FieldDescriptorID(new Guid("c006bb53-4608-4083-8f47-69c3a3713ed2"));
            public static readonly FieldDescriptorID MobilityProfiles = new FieldDescriptorID(new Guid("33a98a28-8ba7-4258-a99f-fe8f22f99e3b"));
        }

        public static class Services
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("2ac99ff5-20cb-4733-9303-366f325294dd"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID ServiceID = new FieldDescriptorID(new Guid("3468d1d0-4c08-42a7-80bf-b5ab5a2d1f86"));
            public static readonly FieldDescriptorID Name = new FieldDescriptorID(new Guid("075e14f5-69fa-474b-9433-a1b9f67807fb"));
            public static readonly FieldDescriptorID Profile = new FieldDescriptorID(new Guid("36a50d04-c782-4639-b1ee-a7d5494d8b67"));
        }
    }
}