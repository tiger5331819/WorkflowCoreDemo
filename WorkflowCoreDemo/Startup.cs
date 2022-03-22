using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WorkflowCore.Interface;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddWorkflow(x => x.UseSqlite(@"Data Source=Test.db;", true)).AddWorkflowDSL();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var host = app.ApplicationServices.GetService<IWorkflowHost>();
            host.Start();
            var loader = app.ApplicationServices.GetService<IDefinitionLoader>();
            try
            {
                //var json = System.IO.File.ReadAllText("json/Base.json");
                //loader.LoadDefinition(json, Deserializers.Json);

                //var json2 = System.IO.File.ReadAllText("json/Event.json");
                //loader.LoadDefinition(json2, Deserializers.Json);

                //var json3 = System.IO.File.ReadAllText("json/Activity.json");
                //loader.LoadDefinition(json3, Deserializers.Json);

                //var json4 = System.IO.File.ReadAllText("json/Error.json");
                //loader.LoadDefinition(json4, Deserializers.Json);

                //var json5 = System.IO.File.ReadAllText("json/Branch.json");
                //loader.LoadDefinition(json5, Deserializers.Json);

                //var json6 = System.IO.File.ReadAllText("json/IF.json");
                //loader.LoadDefinition(json6, Deserializers.Json);

                //var json7 = System.IO.File.ReadAllText("json/Parallel.json");
                //loader.LoadDefinition(json7, Deserializers.Json);

                //var demo = System.IO.File.ReadAllText("json/WorkFlowDemo.json");
                //loader.LoadDefinition(demo, Deserializers.Json);


                //DefinitionInstance<MyDataClass> definitionInstance = new DefinitionInstance<MyDataClass>("WorkflowCoreTest",1,"Test");
                //definitionInstance.Steps.Add(new BodyStep<HelloWorld>("Hello","Result"));
                //var Result = new BodyStep<ShowNumber>("Result","ShowResult");
                //Result.AddInput("Input1", "data.Value1");
                //Result.AddInput("Input2", "data.Value2");
                //Result.AddOutputs("Value3", "step.Output");
                //definitionInstance.Steps.Add(Result);

                //var ShowResult = new BodyStep<ShowNumber2>("ShowResult", null);
                //ShowResult.AddInput("Message", "\"End jungege\"+data.Value3");

                //definitionInstance.Steps.Add(ShowResult);

                //var jsonText=JsonSerializer.Serialize(definitionInstance);
                //loader.LoadDefinition(jsonText, Deserializers.Json);


                //DefinitionInstance<MyDataClass> EventdefinitionInstance = new DefinitionInstance<MyDataClass>("WorkflowCoreTest-Event", 1, "EventTest");
                //EventdefinitionInstance.Steps.Add(new BodyStep<HelloWorld>("Hello", "Event"));
                //var EventResult = new EventStep<Event>("Event", "ShowResult");
                //EventResult.AddInput("EventWaitFor", "1");
                //EventResult.AddOutputs("Value3");
                //EventdefinitionInstance.Steps.Add(EventResult);

                //EventdefinitionInstance.Steps.Add(ShowResult);

                //var jsonText2 = JsonSerializer.Serialize(EventdefinitionInstance);
                //loader.LoadDefinition(jsonText2, Deserializers.Json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
