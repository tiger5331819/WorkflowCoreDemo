using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Primitives;

namespace ConsoleApp1
{
    public class HelloWorld : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Hello world");
            return ExecutionResult.Next();
        }
    }

    public class ErrorTest : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Random rd = new Random();
            var result = rd.Next(1, 100);
            if (result % 10 != 0)
            {
                Console.WriteLine("Error!");
                throw new Exception();

            }
            else return ExecutionResult.Next();
        }
    }

    public class ShowNumber : StepBody
    {
        public int Input1 { get; set; }
        public int Input2 { get; set; }

        public string Output { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Output = (Input1 + Input2).ToString();
            Console.WriteLine(Output);
            return ExecutionResult.Next();
        }
    }

    public class ActivityTest : Activity
    {

    }

    public class IFTest : If
    { }

    public class ParallelTest : Sequence
    {
    }

    public class Event : WaitFor
    {
    }

    public class ShowNumber2 : StepBody
    {
        public string Message { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine(Message);
            return ExecutionResult.Next();
        }
    }

    //public class WorkflowCoreTest : IWorkflow
    //{
    //    public string Id => "WorkflowCoreTest";

    //    public int Version => 1;

    //    public void Build(IWorkflowBuilder<object> builder)
    //    {
    //        builder
    //        .StartWith<HelloWorld>();
    //        //.Then<GoodbyeWorld>();
    //    }
    //}
}
