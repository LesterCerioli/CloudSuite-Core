using MediatR;

namespace CloudSuite.Modules.Application.Hadlers.City.Request
{
    public class CheckCityExistsByCityNameRequest : IRequest<CheckCitExistsyByCityNameResponse>
    {
        public Guid Id { get; private set; }

        public string? CityName { get; set; }

        public CheckCityExistsByCityNameRequest(string cityName)
        {
            Id = Guid.NewGuid();
            CityName = cityName;
        }

        public CheckCityExistsByCityNameRequest() { }

    }
}
