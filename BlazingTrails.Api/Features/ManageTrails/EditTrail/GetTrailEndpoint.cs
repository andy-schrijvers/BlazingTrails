using Ardalis.ApiEndpoints;
using BlazingTrails.Api.Persistence.Entities;
using BlazingTrails.Shared.Features.ManageTrails.EditTrail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazingTrails.Api.Features.ManageTrails.EditTrail
{
    [Authorize]
    public class GetTrailEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetTrailRequest.Response>
    {
        private readonly BlazingTrailContext _database;

        public GetTrailEndpoint(BlazingTrailContext database)
        {
            _database = database;
        }


        [HttpGet(GetTrailRequest.RouteTemplate)]
        public override async Task<ActionResult<GetTrailRequest.Response>> HandleAsync([FromRoute]int trailId, CancellationToken cancellationToken = default)
        {
            var trail = await _database.Trails.Include(x => x.Waypoints).SingleOrDefaultAsync(x => x.Id == trailId, cancellationToken: cancellationToken);

            if (trail is null)
            {
                return BadRequest("Trail could not be found.");
            }

            if (!trail.Owner.Equals(HttpContext.User.Identity!.Name, StringComparison.CurrentCultureIgnoreCase) && !HttpContext.User.IsInRole("Administrator"))
            {
                return Unauthorized();
            }

            var response = new GetTrailRequest.Response(new GetTrailRequest.Trail(trail.Id,
                trail.Name,
                trail.Location,
                trail.Image,
                trail.TimeInMinutes,
                trail.Length,
                trail.Description,
                trail.Waypoints.Select(wp => new GetTrailRequest.Waypoint(wp.Latitude, wp.Longitude))));

            return Ok(response);
        }
    }
}
