using System;
using BraspagHackathon.TimeZado.Model.Entities;
using System.Threading.Tasks;
using BraspagHackathon.TimeZado.Services.ApiClient;
using BraspagHackaton.TimeZado.Services.ApiClient;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;

namespace BraspagHackathon.TimeZado.Services
{
    public class DeviceService
    {
        public async void CreateVirtualDevice(Action<Device> callback)
        {
            var createdDevice = await CreateVirtualDeviceOnApi();

            if (callback != null)
            {
                callback.Invoke(createdDevice);
            }
        }

        public async void UpdateVirutalDevice(Action<Device> callback, Device device)
        {
            var updatedDevice = await UpdateVirtualDeviceOnApi(device);

            if (callback != null)
            {
                callback.Invoke(updatedDevice);
            }
        }

        private async Task<Device> CreateVirtualDeviceOnApi()
        {
            var api = new DeviceApiClient(new BlackboxApiClient());

            return await api.Create(new CreateDeviceRequest { Type = "VIRTUAL" });
        }

        private async Task<Device> UpdateVirtualDeviceOnApi(Device device)
        {
            var request = new UpdateDeviceRequest
            {
                CustomerId = device.CustomerId.Value,
                Id = device.Id,
                OfferId = device.OfferId.Value,
                Type = device.Type
            };

            var api = new DeviceApiClient(new BlackboxApiClient());

            return await api.Update(request);
        }
    }
}