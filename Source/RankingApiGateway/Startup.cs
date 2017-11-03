using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RankingApiGateway.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using RankingApiGateway.Clients;

namespace RankingApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string playersApiUrl = "http://localhost";
            string matchesApiUrl = "http://localhost";
            string ratingApiUrl = "http://localhost";

            services.AddMvc();

            var builder = new ContainerBuilder(); 
            
            builder.RegisterType<PlayersService>().As<IPlayersService>();
            builder.RegisterType<MatchesService>().As<IMatchesService>();

            //IMatchApiClient matchApiClient = Refit.RestService.For<IMatchApiClient>(matchesApiUrl);
            //IPlayerApiClient playerApiClient = Refit.RestService.For<IPlayerApiClient>(playersApiUrl);
            //IRatingApiClient ratingApiClient = Refit.RestService.For<IRatingApiClient>(ratingApiUrl);

            //builder.RegisterInstance(matchApiClient).As<Clients.IMatchApiClient>();
            //builder.RegisterInstance(playerApiClient).As<Clients.IPlayerApiClient>();
            //builder.RegisterInstance(ratingApiClient).As<Clients.IRatingApiClient>();

            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
