using System.ComponentModel.DataAnnotations.Schema;
using HotChocolateIssueReproduction.Data;
using Location = HotChocolateIssueReproduction.Data.Location;

namespace HotChocolateIssueReproduction.Types;

public sealed class SpeakerDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Bio { get; init; }
    public string? Website { get; init; }
    public List<Location> Locations { get; init; } = [];
    public Location? LatestLocation { get; init; }
}

public static class TrackedEntityExtensions
{
    public static IQueryable<SpeakerDto> MapToDto(this IQueryable<Speaker> query) =>
        query.Select(e => new SpeakerDto
        {
            Id = e.Id,
            Name = e.Name,
            Bio = e.Bio,
            Website = e.Website,
            Locations = e.Locations,
            LatestLocation = e.Locations.OrderByDescending(l => l.Name2).FirstOrDefault()
        });
}

[ObjectType<SpeakerDto>]
public static partial class SpeakerDtoNode
{
    public static List<Location> Locations([Parent(requires: nameof(SpeakerDto.Locations))] SpeakerDto speaker) =>
        speaker.Locations;
}