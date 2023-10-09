using BlogAnimalApi.Entity;
using BlogAnimalApi.Repository;

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
builder.Services.AddScoped<PostCommentRepository>();
builder.Services.AddScoped<PostLikeRepository>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<TagRepository>();
//Add auto mapper
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
