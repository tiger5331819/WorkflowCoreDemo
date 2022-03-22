using System.Collections.Generic;

namespace AlltoseaCore.WorkFlowCoreDefinition.Step
{
    public abstract record DefinitionStep
    {
        public string Id { get; init; }

        public string StepType { get; init; }

        public string ErrorBehavior { get; init; }

        public string NextStepId { get; init; }

        public Dictionary<string, string> Inputs { get; init; } = new Dictionary<string, string>();
        public Dictionary<string, string> Outputs { get; init; } = new Dictionary<string, string>();

        public DefinitionStep(string ID, string nextStepId, ErrorBehaviorEnum errorBehavior = ErrorBehaviorEnum.Retry)
        {
            this.Id = ID;
            NextStepId = nextStepId;
            ErrorBehavior = errorBehavior.ToString();

        }

    }

}
