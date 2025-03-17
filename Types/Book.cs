using GreenDonut.Data;

namespace HotChocolateIssueReproduction.Types;

public class Book
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public required Author Author { get; init; }
}


[ObjectType<Book>]
public static partial class BookNode
{
    [NodeResolver]
    public static Book? GetBookById(int id, QueryContext<Book> queryContext)
    {
        return new Book
        {
            Id = id,
            Title = "Test Title",
            Author = new Author
            {
                Id = 1,
                Name = "Test Author"
            }
        };
    }
}