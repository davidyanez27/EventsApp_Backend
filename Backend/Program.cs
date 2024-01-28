using Backend.Models;
using Microsoft.EntityFrameworkCore;

using Backend.Services.Contracts;
using Backend.Services.Implementation;

using AutoMapper;
using Backend.DTO;
using Backend.Utilities;


#region build
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BdeventsContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("SQLdata"),
        new MySqlServerVersion(new Version(7, 0, 0))); // Update the version number as needed
});

builder.Services.AddScoped<IEventService, EventsServices>();
//builder.Services.AddScoped<IUserService, UserServices>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

var app = builder.Build();

#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Peticiones
app.MapGet("/event", async(IEventService _eventService,IMapper
     _mapper) =>
{
    var eventsList = await _eventService.GetAllEvents();
    var eventDTO = _mapper.Map<List<EventDTO>>(eventsList);
    if(eventDTO.Count >0)
        return Results.Ok(eventsList);
    else
        return Results.NotFound();

}
);


app.MapGet("/event/{id}", async (IEventService _eventService, IMapper
     _mapper, int id) =>
{
    var eventfind = await _eventService.GetEventById(id);
    return Results.Ok(eventfind);

}
);


//not working properly, only make the post if you create a new user with unique email, you can test in the swagger page
app.MapPost("/event", async (IEventService _eventService, IMapper _mapper, Event eventDTO) =>
{
    var result = await _eventService.CreateEvent(eventDTO);

});

//not working properly, only make the put if you create a new user with unique email
app.MapPut("/event", async (IEventService _eventService, IMapper _mapper, Event eventDTO) =>
{
    var result = await _eventService.UpdateEvent(eventDTO);

});



#endregion

app.UseCors("NewPolicy");
app.Run();

