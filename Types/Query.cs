namespace HotChocolateIssueReproduction.Types;

[QueryType]
public static class Query
{
    public static Book GetBook()
        => new()
        {
            Id = 1,
            Title = "C# in depth.",
            Author = new Author
            {
                Id = 1,
                Name = "Jon Skeet"
            }
        };
}
