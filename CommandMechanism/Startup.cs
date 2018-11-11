using System;
using System.Linq;
using CommandMechanism.Base;
using CommandMechanism.Base.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CommandMechanism
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            RegisterCommands(services);

            services.AddSingleton<IComponentResolver, ComponentResolver>();

            services.AddTransient<ICommandProcessor, CommandProcessor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<ICommandProcessorFactory>(service => new CommandProcessorFactory(service.GetService<IComponentResolver>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// This methog register all commands which implement ICommandHandler interface.
        /// </summary>
        private void RegisterCommands(IServiceCollection services)
        {
            Type baseCommandHandlerType = typeof(ICommandHandler<>);

            var assembly = baseCommandHandlerType.Assembly;

            var types = assembly.GetTypes().Where(x => !x.IsAbstract && x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == baseCommandHandlerType)).ToList();

            foreach (var handlerType in types)
            {
                var interfaceType = handlerType.GetInterfaces()
                    .Single(y => y.IsGenericType && y.GetGenericTypeDefinition() == baseCommandHandlerType);

                services.AddTransient(interfaceType, handlerType);
            }
        }
    }
}