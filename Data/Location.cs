using System.ComponentModel.DataAnnotations;

namespace HotChocolateIssueReproduction.Data;

public sealed class Location
{
    public int Id { get; init; }

    [StringLength(200)] public required string Name2 { get; init; }
}