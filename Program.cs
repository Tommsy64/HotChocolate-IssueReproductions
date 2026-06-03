using HotChocolate.Types.Pagination;
using HotChocolateIssueReproduction.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("repro"))
    .AddGraphQLServer()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment())
    .AddSorting() // Error if this isn't added
    .AddPagingArguments()
    .AddTypes()
    .AddObjectType<PageInfo>(o => o.Name("RelativePageInfo"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);