namespace AlltoseaCore.WorkFlowCoreDefinition
{
    public enum ErrorBehaviorEnum
    {
        /// <summary>
        /// 重试
        /// </summary>
        Retry,

        /// <summary>
        /// 暂停
        /// </summary>
        Suspend,

        /// <summary>
        /// 终止
        /// </summary>
        Terminate,

        /// <summary>
        /// 补偿
        /// </summary>
        Compensate,
    }
}
