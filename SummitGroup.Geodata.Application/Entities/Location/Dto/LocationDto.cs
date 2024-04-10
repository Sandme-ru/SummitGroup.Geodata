using Newtonsoft.Json;

namespace SummitGroup.Geodata.Application.Entities.Location.Dto;

/// <summary>
/// Class LocationDro.
/// </summary>
public class LocationDto
{
    /// <summary>
    /// Gets or sets the latitude.
    /// </summary>
    /// <value>The latitude.</value>
    public double lat { get; set; }

    /// <summary>
    /// Gets or sets the longitude.
    /// </summary>
    /// <value>The longitude.</value>
    public double lon { get; set; }

    public int count { get; set; }

    public int radius { get; set; }
}