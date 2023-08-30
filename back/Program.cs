using System;
using System.Linq;
using System.Threading.Tasks;

using back.Model;
using Security.Jwt;

BlablaContext context = new BlablaContext();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
    policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<BlablaContext>();


builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICargoRepository, CargoRepository>();
builder.Services.AddTransient<ICommunityRepository, CommunityRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<ISearchRepository, SearchRepository>();
builder.Services.AddTransient<ILikeRepository, LikeRepository>();

builder.Services.AddScoped<JwtService>();
builder.Services.AddSingleton<IPasswordProvider, FilePasswordProvider>(p => new FilePasswordProvider(".env"));

var app = builder.Build();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();