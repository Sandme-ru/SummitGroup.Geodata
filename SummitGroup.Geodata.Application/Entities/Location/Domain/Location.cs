namespace SummitGroup.Geodata.Application.Entities.Location.Domain;

/// <summary>
/// Class Location.
/// </summary>
public class Location
{
    /// <summary>
    /// Gets or sets the source.
    /// </summary>
    /// <value>The source.</value>
    public string Source { get; set; }

    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    /// <value>The result.</value>
    public string Result { get; set; }

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>The postal code.</value>
    public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    /// <value>The country.</value>
    public string Country { get; set; }

    /// <summary>
    /// Gets or sets the region.
    /// </summary>
    /// <value>The region.</value>
    public string Region { get; set; }

    /// <summary>
    /// Gets or sets the city area.
    /// </summary>
    /// <value>The city area.</value>
    public string CityArea { get; set; }

    /// <summary>
    /// Gets or sets the city district.
    /// </summary>
    /// <value>The city district.</value>
    public string CityDistrict { get; set; }

    /// <summary>
    /// Gets or sets the street.
    /// </summary>
    /// <value>The street.</value>
    public string Street { get; set; }

    /// <summary>
    /// Gets or sets the house.
    /// </summary>
    /// <value>The house.</value>
    public string House { get; set; }

    /// <summary>
    /// Gets or sets the geo lat.
    /// </summary>
    /// <value>The geo lat.</value>
    public string GeoLat { get; set; }

    /// <summary>
    /// Gets or sets the geo lon.
    /// </summary>
    /// <value>The geo lon.</value>
    public string GeoLon { get; set; }

    /// <summary>
    /// Gets or sets the qc geo.
    /// </summary>
    /// <value>The qc geo.</value>
    public int QcGeo { get; set; }
}