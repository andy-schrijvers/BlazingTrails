using Ardalis.ApiEndpoints;
using BlazingTrails.Api.Persistence;
using BlazingTrails.Shared.Features.Home.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingTrails.Api.Features.Home.Shared;

public class GetTrailsEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetTrailsRequest.Response>
{
    private readonly BlazingTrailContext _database;

    public GetTrailsEndpoint(BlazingTrailContext database)
    {
        _database = database;
    }

    [HttpGet(GetTrailsRequest.RouteTemplate)]
    public override async Task<ActionResult<GetTrailsRequest.Response>> HandleAsync(int trailId, CancellationToken cancellationToken = default)
    {
        var trails = await _database.Trails.Include(x => x.Waypoints).ToListAsync(cancellationToken);

        var response = new GetTrailsRequest.Response(trails.Select(trail => new GetTrailsRequest.Trail(
            trail.Id,
            trail.Name,
            trail.Image,
            trail.Location,
            trail.TimeInMinutes,
            trail.Length,
            trail.Description,
            trail.Owner,
            trail.Waypoints.Select(wp => new GetTrailsRequest.Waypoint(wp.Latitude, wp.Longitude)).ToList()
        )));

        return Ok(response);
    }
}