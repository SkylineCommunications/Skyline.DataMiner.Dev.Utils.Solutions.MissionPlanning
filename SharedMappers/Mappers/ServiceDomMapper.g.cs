using System;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.Sections;
using Skyline.DataMiner.SDM;

namespace Skyline.DataMiner.Solutions.MissionPlanning.SDM.Models
{
    [SdmDomMapper]
    public static class ServiceDomMapper
    {
        internal const string ModuleId = "(slc)mission_management";
        private static readonly DomDefinitionId ServiceDomDefinitionId = new DomDefinitionId(new Guid("f4d09d3b-6458-4a09-86d2-3b61b721e243"))
        {
            ModuleId = ModuleId
        };
        internal static DomDefinitionId DomDefinitionId => ServiceDomDefinitionId;

        public static class ServiceProperties
        {
            private static readonly SectionDefinitionID sectionDefinitionId = new SectionDefinitionID(new Guid("74516f7e-8218-4dab-85e0-d5f1d4b869b0"))
            {
                ModuleId = ModuleId
            };
            internal static SectionDefinitionID SectionDefinitionId => sectionDefinitionId;

            public static readonly FieldDescriptorID ServiceID = new FieldDescriptorID(new Guid("91dd20bd-db43-4691-abce-f4d2d25680ec"));
            public static readonly FieldDescriptorID Name = new FieldDescriptorID(new Guid("35948228-ae6e-43ad-879e-f5c6aa81363a"));
            public static readonly FieldDescriptorID Profile = new FieldDescriptorID(new Guid("920d6d38-70a3-4052-8d53-94f9cda09012"));
        }
    }
}