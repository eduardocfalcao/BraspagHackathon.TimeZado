using BraspagHackathon.TimeZado.Model.Entities;
using System.Threading.Tasks;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;
using BraspagHackaton.TimeZado.Services.ApiClient;

namespace BraspagHackathon.TimeZado.Services.ApiClient
{
    public class DeviceApiClient
    {
        public DeviceApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<Device> Create(CreateDeviceRequest request)
        {
            return await BlackboxApiClient.Post<Device>("device", request);
        }

        public async Task<Device> Update(UpdateDeviceRequest request)
        {
            return await BlackboxApiClient.Put<Device>("device", request);
        }
    }
}