namespace SummitGroup.Geodata.Application.Entities.Address.Dto;

/// <summary>
/// Class AddressDto.
/// </summary>
public class AddressDto
{
    public string Country { get; set; }
    /// <summary>
    /// Gets or sets the region.
    /// </summary>
    /// <value>The region.</value>
    public string Region { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>The city.</value>
    public string City { get; set; }

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
    /// Gets or sets the apartment.
    /// </summary>
    /// <value>The apartment.</value>
    public string Apartment { get; set; }
}