using BusinessObjects;
using DAO;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC vào pipeline
builder.Services.AddControllersWithViews();

// Đăng ký các lớp DAO vào DI container
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<ITeamDAO, TeamDAO>();
builder.Services.AddScoped<IProjectDAO, ProjectDAO>();
builder.Services.AddScoped<IScoreDAO, ScoreDAO>();

// Đăng ký các Repository vào DI container
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

// Đăng ký các Service vào DI container
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// Cấu hình các middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Cấu hình endpoint cho các controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();