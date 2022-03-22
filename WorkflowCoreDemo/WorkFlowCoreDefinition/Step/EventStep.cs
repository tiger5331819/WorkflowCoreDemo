using AlltoseaCore.WorkFlowCoreDefinition;
using AlltoseaCore.WorkFlowCoreDefinition.Step;
using WorkflowCore.Primitives;

namespace WebApplication1.WorkFlowCoreDefinition.Step
{
    public record EventStep<TStep> : DefinitionStep where TStep : WaitFor
    {

        public EventStep(string ID, string nextStepId, ErrorBehaviorEnum errorBehavior = ErrorBehaviorEnum.Retry) : base(ID, nextStepId, errorBehavior)
        {
            StepType = typeof(TStep).FullName + "," + typeof(TStep).Assembly.GetName().Name;
        }


        public void AddInput(string eventName, string eventKey = "0", string effectiveDate = "DateTime.Now")
        {
            Inputs.Add("EventName", "\"" + eventName + "\"");
            Inputs.Add("EventKey", "\"" + eventKey + "\"");
            Inputs.Add("EffectiveDate", effectiveDate);
        }

        /// <summary>
        /// 添加Output信息
        /// </summary>
        /// <param name="propertyName">数据属性名称</param>
        /// <param name="stepPropertyName">Step属性名称</param>
        public void AddOutputs(string propertyName) => Outputs.Add(propertyName, "step.EventData");
    }
}
