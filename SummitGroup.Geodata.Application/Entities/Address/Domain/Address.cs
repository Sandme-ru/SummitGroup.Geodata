namespace SummitGroup.Geodata.Application.Entities.Address.Domain;

/// <summary>
/// Class Address.
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets the place identifier.
    /// </summary>
    /// <value>The place identifier.</value>
    public long place_id { get; set; }

    /// <summary>
    /// Gets or sets the licence.
    /// </summary>
    /// <value>The licence.</value>
    public string licence { get; set; }

    /// <summary>
    /// Gets or sets the type of the osm.
    /// </summary>
    /// <value>The type of the osm.</value>
    public string osm_type { get; set; }

    /// <summary>
    /// Gets or sets the osm identifier.
    /// </summary>
    /// <value>The osm identifier.</value>
    public long osm_id { get; set; }

    /// <summary>
    /// Gets or sets the lat.
    /// </summary>
    /// <value>The lat.</value>
    public string lat { get; set; }

    /// <summary>
    /// Gets or sets the lon.
    /// </summary>
    /// <value>The lon.</value>
    public string lon { get; set; }

    /// <summary>
    /// Gets or sets the class.
    /// </summary>
    /// <value>The class.</value>
    public string @class { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>The type.</value>
    public string type { get; set; }

    /// <summary>
    /// Gets or sets the place rank.
    /// </summary>
    /// <value>The place rank.</value>
    public int place_rank { get; set; }

    /// <summary>
    /// Gets or sets the importance.
    /// </summary>
    /// <value>The importance.</value>
    public double importance { get; set; }

    /// <summary>
    /// Gets or sets the addresstype.
    /// </summary>
    /// <value>The addresstype.</value>
    public string addresstype { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string name { get; set; }

    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    /// <value>The display name.</value>
    public string display_name { get; set; }

    /// <summary>
    /// Gets or sets the boundingbox.
    /// </summary>
    /// <value>The boundingbox.</value>
    public List<string> boundingbox { get; set; }
}