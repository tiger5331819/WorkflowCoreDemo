using WorkflowCore.Models;

namespace AlltoseaCore.WorkFlowCoreDefinition.Step
{
    public record BodyStep<TStep> : DefinitionStep where TStep : StepBody
    {
        public BodyStep(string ID, string nextStepId, ErrorBehaviorEnum errorBehavior = ErrorBehaviorEnum.Retry) : base(ID, nextStepId, errorBehavior)
        {
            StepType = typeof(TStep).FullName + "," + typeof(TStep).Assembly.GetName().Name;
        }

        /// <summary>
        /// 添加Input信息
        /// </summary>
        /// <param name="propertyName">数据属性名称</param>
        public void AddInput(string stepPropertyName, string propertyName) => Inputs.Add(stepPropertyName, propertyName);

        /// <summary>
        /// 添加Output信息
        /// </summary>
        /// <param name="propertyName">数据属性名称</param>
        /// <param name="stepPropertyName">Step属性名称</param>
        public void AddOutputs(string propertyName, string stepPropertyName) => Outputs.Add(propertyName, stepPropertyName);
    }
}
