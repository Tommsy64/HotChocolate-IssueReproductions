namespace HotChocolateIssueReproduction.Types;

public class Author
{
    public int Id { get; init; }
    public required string Name { get; init; }
}

[ObjectType<Author>]
public static partial class AuthorNode
{
    [NodeResolver]
    public static Author? GetAuthorById(int id)
    {
        return new Author
        {
            Id = id,
            Name = "Test Name"
        };
    }
}