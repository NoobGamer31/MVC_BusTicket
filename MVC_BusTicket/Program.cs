namespace MVC_BusTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add distributed cache for Session State
            builder.Services.AddDistributedMemoryCache();

            // Configure session state
            builder.Services.AddSession(options =>
            {
                // Config to use __Host-
                options.Cookie.Name = "__Host-Session"; // Use a secure cookie name
                options.Cookie.Path = "/"; // Set the cookie path to root

                // Config timeout and essential cookie
                options.IdleTimeout = TimeSpan.FromMinutes(15); // Set session timeout
                options.Cookie.IsEssential = true; // Ensures the cookie is always sent even without user consent

                // Config security
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Only sends the cookie via HTTPS
                options.Cookie.SameSite = SameSiteMode.Strict; // Prevents CSRF attacks
                options.Cookie.HttpOnly = true; // Prevents XSS attacks
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Client/Error");
            }

            app.UseHttpsRedirection();

            // Use session middleware
            app.UseSession();

            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
