var builder = WebApplication.CreateBuilder(args);

builder
    .AddGraphQL()
    .AddTypes()
    .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);