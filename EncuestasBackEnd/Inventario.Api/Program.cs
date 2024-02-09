using Inventario.DataAccess;
using Inventario.Entities.Users;
using Inventario.Services.Contrats;
using Inventario.Services.Mappers;
using Inventario.Services.Surveys;
using Inventario.Services.Surveys.Questions;
using Inventario.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<EncuestasDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<EncuestasDbContext>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ISurveyService, SurveyService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IOptionService, OptionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EncuestasDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");
}
else 
{
    app.UseExceptionHandler("/error");
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var adminRoleExists = await roleManager.RoleExistsAsync("admin");
    if (!adminRoleExists)
    {
        await roleManager.CreateAsync(new IdentityRole("admin"));
    }

    var adminUser = new User
    {
        UserName = "yoda123",
        NormalizedUserName = "yoda123",
        EmailConfirmed = true
    };

    string adminPassword = "Password123#@!";
    var user = await userManager.FindByNameAsync("yoda123");

    if (user == null)
    {
        var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
        if (createAdminUser.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "admin");
        }
    }
}


app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStatusCodePages(context => {
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.NotFound)
    {
        response.Redirect("/PageNotFound");
    }

    return Task.CompletedTask;
});

app.Run();
