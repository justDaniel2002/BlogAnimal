using BlogAnimalApi;
using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using BlogAnimalApi.Repository;
using BlogAnimalApi.Services;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add dbcontext
builder.Services.AddDbContext<BlogAnimalContext>();
//add repo
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<BlogRepository>();
builder.Services.AddScoped<BlogComment>();
builder.Services.AddScoped<BlogRepository>();
builder.Services.AddScoped<BlogTagRepository>();
builder.Services.AddScoped<PetTypeRepository>();
builder.Services.AddScoped<BlogTypeRepository>();
builder.Services.AddScoped<PostCommentRepository>();
builder.Services.AddScoped<PostLikeRepository>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<BlogCommentRepository>();
builder.Services.AddScoped<TradeRepository>();
builder.Services.AddScoped<TradeCommentRepository>();

//add services
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<TradeService>();

//Add auto mapper
builder.Services.AddAutoMapper(typeof(Program));
//Add util
builder.Services.AddScoped<Util>();

// Configure the maximum request size for file uploads (if needed)
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueCountLimit = int.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = long.MaxValue;
});
//cloudonary config
builder.Services.AddScoped<CloudinaryConfig>();

//Add Cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173/");
                      });
});
builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
