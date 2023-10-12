using BlogAnimalApi.Entity;
using BlogAnimalApi.Helper;
using BlogAnimalApi.Repository;
using BlogAnimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
//add services
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BlogService>();
builder.Services.AddScoped<PostService>();
//Add auto mapper
builder.Services.AddAutoMapper(typeof(Program));
//Add util
builder.Services.AddScoped<Util>();

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
