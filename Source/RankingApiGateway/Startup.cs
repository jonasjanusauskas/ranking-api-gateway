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
using RankingApiGateway.Clients.MatchesApiClient;
using RankingApiGateway.Clients.PlayersApiClient;
using RankingApiGateway.Clients.RatingApiClient;

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
            string playersApiUrl = $"http://{Environment.GetEnvironmentVariable("POOLRANKING_PLAYERS_SERVICE_HOST")}:{Environment.GetEnvironmentVariable("POOLRANKING_PLAYERS_SERVICE_PORT")}";
            string matchesApiUrl = $"http://{Environment.GetEnvironmentVariable("POOLRANKING_MATCHES_SERVICE_HOST")}:{Environment.GetEnvironmentVariable("POOLRANKING_MATCHES_SERVICE_PORT")}"; ;
            string ratingApiUrl = $"http://{Environment.GetEnvironmentVariable("POOLRANKING_RANKING_SERVICE_HOST")}:{Environment.GetEnvironmentVariable("POOLRANKING_RANKING_SERVICE_PORT")}"; ;

            services.AddMvc();

            services.AddCors(o => o.AddPolicy("AllowAll", corsBuilder =>
            {
                corsBuilder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            var builder = new ContainerBuilder(); 
            
            builder.RegisterType<PlayersService>().As<IPlayersService>();
            builder.RegisterType<MatchesService>().As<IMatchesService>();
            builder.RegisterType<ScoreboardService>().As<IScoreboardService>();

            IMatchesApiClient matchApiClient = Refit.RestService.For<IMatchesApiClient>(matchesApiUrl);
            IPlayersApiClient playerApiClient = Refit.RestService.For<IPlayersApiClient>(playersApiUrl);
            IRatingApiClient ratingApiClient = Refit.RestService.For<IRatingApiClient>(ratingApiUrl);

            builder.RegisterInstance(matchApiClient).As<IMatchesApiClient>();
            builder.RegisterInstance(playerApiClient).As<IPlayersApiClient>();
            builder.RegisterInstance(ratingApiClient).As<IRatingApiClient>();

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
