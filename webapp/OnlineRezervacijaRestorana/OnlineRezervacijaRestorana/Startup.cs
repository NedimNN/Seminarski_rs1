using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Online_Rezervacija_Restorana.Repository;
using Online_Rezervacija_Restorana.Services;
using Online_Rezervacija_Restorana.Services.Worker;
using Online_Rezervacija_Restorana.Configuration;
using Online_Rezervacija_Restorana.Services.SMS;

namespace Online_Rezervacija_Restorana
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICouponRepository, CouponRepository>();
            services.AddTransient<IFollowRepository, FollowRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IMealRepository, MealRepository>();
            services.AddTransient<IMealTypeRepository, MealTypeRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentDetailRepository, PaymentDetailRepository>();
            services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IUserDataRepository, UserDataRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();

            services.AddTransient<ReservationService>();

            EmailConfig emailConfig = new EmailConfig();
            Configuration.GetSection("Email").Bind(emailConfig);
            services.AddSingleton<EmailConfig>(emailConfig);

            SMSConfig smsConfig = new SMSConfig();
            Configuration.GetSection("SMS").Bind(smsConfig);
            services.AddSingleton<SMSConfig>(smsConfig);

            services.AddSingleton<SMSService>();
            services.AddSingleton<EmailingService>();

            services.AddHostedService<ReservationReminderWorkerService>();
            services.AddSwaggerGen(c =>
            {
                var info = new Microsoft.OpenApi.Models.OpenApiInfo { Title = "myApi", Version = "v1" };
                c.SwaggerDoc("v1", info);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "reservation",
                   pattern: "restaurant/{id=1}/{controller=Reservation}/{action=Index}");

                endpoints.MapControllerRoute(
                   name: "rating",
                   pattern: "restaurant/{id=1}/{controller=Rating}/{action=Index}");

                endpoints.MapRazorPages();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi V1");
            });
        }
    }
}
