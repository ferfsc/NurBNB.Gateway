using Newtonsoft.Json;
using NurBNB.Gateway.Dto;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;

namespace NurBNB.Gateway.Aggregator
{
    public class HuespedReservaDetailAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {

            if(responses.Count == 0)
            {
                return new DownstreamResponse(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            var response = responses[0];
            if (response.Items.Errors().Count > 0)
            {
                return new DownstreamResponse(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            var propiedadesDisponiblesResponse = await
               responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var objPropiedad = JsonConvert.DeserializeObject<List<PropiedadDto>>(propiedadesDisponiblesResponse);

            var BuscarHuesped_Response = await
               responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var objHuesped = JsonConvert.DeserializeObject<List<HuespedDto>>(BuscarHuesped_Response);

            return new DownstreamResponse(new StringContent(JsonConvert.SerializeObject(objHuesped)),
                HttpStatusCode.OK, new List<Header>(), "OK");

        }
    }
}
