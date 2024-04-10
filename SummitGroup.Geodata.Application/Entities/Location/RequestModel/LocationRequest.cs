namespace SummitGroup.Geodata.Application.Entities.Location.RequestModel;

/// <summary>
/// Class LocationRequest.
/// </summary>
public class LocationRequest
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

    /// <summary>
    /// Gets or sets the count.
    /// </summary>
    /// <value>The count.</value>
    public int count { get; set; }

    /// <summary>
    /// Gets or sets the radius.
    /// </summary>
    /// <value>The radius.</value>
    public int radius { get; set; }
}