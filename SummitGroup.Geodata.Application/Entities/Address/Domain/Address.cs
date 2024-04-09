namespace SummitGroup.Geodata.Application.Entities.Address.Domain;

public class Address
{
    public string Source { get; set; }

    public string Result { get; set; }

    public string PostalCode { get; set; }

    public string Country { get; set; }

    public string Region { get; set; }

    public string CityArea { get; set; }

    public string CityDistrict { get; set; }

    public string Street { get; set; }

    public string House { get; set; }

    public string GeoLat { get; set; }

    public string GeoLon { get; set; }

    public int QcGeo { get; set; }
}