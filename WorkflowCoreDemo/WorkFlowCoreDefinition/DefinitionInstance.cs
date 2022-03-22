using AlltoseaCore.WorkFlowCoreDefinition.Step;
using System.Collections.Generic;

namespace AlltoseaCore.WorkFlowCoreDefinition
{
    public class DefinitionInstance<T>
    {
        public string Id { get; set; }

        public int Version { get; set; }

        public string DataType { get; set; }

        public string Description { get; set; }

        public List<DefinitionStep> Steps { get; init; } = new List<DefinitionStep>();

        public DefinitionInstance(string id, int version, string description = null)
        {
            Id = id;
            Version = version;
            DataType = typeof(T).FullName + "," + typeof(T).Assembly.GetName().Name;
            Description = description;
        }
    }
}
