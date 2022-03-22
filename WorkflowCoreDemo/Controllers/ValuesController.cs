using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using WorkflowCore.Interface;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IWorkflowController WorkflowService;
        IWorkflowRegistry Registry;
        IWorkflowHost Host;


        public ValuesController(IWorkflowHost host, IWorkflowController workflowService, IWorkflowRegistry registry)
        {
            WorkflowService = workflowService;
            Host = host;
            Registry = registry;
            var tt = Registry.GetDefinition("WorkflowCoreTest");
        }

        [HttpGet]
        public void Test()
        {
            MyDataClass data = new() { Value1 = 1, Value2 = 2 };
            WorkflowService.StartWorkflow("WorkflowCoreTest", data);
        }

        [HttpGet("Event")]
        public void EventTest()
        {
            MyDataClass data = new() { Value1 = 1, Value2 = 2 };
            var t = WorkflowService.StartWorkflow("WorkflowCoreTest-Event", data).Result;
            Thread.Sleep(10000);
            WorkflowService.PublishEvent("EventWaitFor", "1", " yes!");
        }

        [HttpGet("Activities")]
        public void ActivitiesTest()
        {
            MyDataClass data = new() { Value1 = 1, Value2 = 2 };
            WorkflowService.StartWorkflow("WorkflowCoreTest-Activity", data);
            var approval = Host.GetPendingActivity("ActivityTest", "worker1", TimeSpan.FromDays(1)).Result;

            if (approval != null)
            {
                Console.WriteLine("Approval required for " + approval.Parameters);
                Host.SubmitActivitySuccess(approval.Token, " susususu");
            }
        }

        [HttpGet("Error")]
        public void ErrorTest()
        {
            MyDataClass data = new() { Value1 = 1, Value2 = 2 };
            WorkflowService.StartWorkflow("WorkflowCoreTest-Error", data);
        }

        [HttpGet("Branch")]
        public void BranchTest(string value)
        {
            MyDataClass2 data = new() { Value = value };
            WorkflowService.StartWorkflow("WorkflowCoreTest-Branch", data);
        }

        [HttpGet("IF")]
        public void IFTest(string value)
        {
            MyDataClass2 data = new() { Value = value };
            WorkflowService.StartWorkflow("WorkflowCoreTest-IF", data);
        }

        [HttpGet("Parallel")]
        public void ParallelTest()
        {
            MyDataClass3 data = new() { Value1 = 1, Value2 = 2, Value4 = 5 };
            WorkflowService.StartWorkflow("WorkflowCoreTest-Parallel", data);
            WorkflowService.PublishEvent("ParallelEventWaitFor", "1", " sususususu");
        }

        [HttpGet("WorkFlowDemo")]
        public void WorkFlowDemo()
        {
            MyDataClass2 data = new() { };
            WorkflowService.StartWorkflow("WorkflowCoreDemo", data);
        }

        [HttpGet("WorkFlowDemo/Event")]
        public void WorkFlowDemoEvent(string value)
        {
            var approval = Host.GetPendingActivity("ActivityTest", "worker1", TimeSpan.FromDays(1)).Result;

            if (approval != null)
            {
                Console.WriteLine("输入！");
                Host.SubmitActivitySuccess(approval.Token, value);
            }
        }
    }

    public class MyDataClass
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Value3 { get; set; }
    }

    public class MyDataClass2
    {
        public string Value { get; set; }
    }

    public class MyDataClass3
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public int Value4 { get; set; }
        public string Value3 { get; set; }

        public string Value5 { get; set; }
    }
}
