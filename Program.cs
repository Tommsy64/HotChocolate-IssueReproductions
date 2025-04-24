using HotChocolate.Types.Pagination;
using HotChocolateIssueReproduction.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
        "Host=127.0.0.1;Port=5433;Username=hotchocolate;Password=hotchocolate_secret"))
    .AddGraphQLServer()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment())
    .AddSorting() // Error if this isn't added
    .AddPagingArguments()
    .AddTypes()
    .AddObjectType<PageInfo>(o => o.Name("RelativePageInfo"));

var app = builder.Build();

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);