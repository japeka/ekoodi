using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Repositories;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApi
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

            // ADD service interface + service //
            /* kutsun aikana: samaa instanssia käytetään */
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository,ContactRepository>();
            //services.AddSingleton<IContactRepository, ContactRepository>();

            //cors ongelman ohittamiseksi sallitaan yhteydet kaikkialta
            services.AddCors(o => o.AddPolicy("ContactsAppPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            //register in memory database called ContactList
            services.AddDbContext<ContactContext>(opt => opt.UseInMemoryDatabase("ContactList"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("ContactsAppPolicy");
            app.UseMvc();
        }
    }
}
