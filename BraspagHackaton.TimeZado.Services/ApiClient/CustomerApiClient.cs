using System.Threading.Tasks;
using BraspagHackaton.TimeZado.Services.ApiClient.Requests;
using BraspagHackaton.TimeZado.Services.ApiClient.Response;

namespace BraspagHackaton.TimeZado.Services.ApiClient
{
    public class CustomerApiClient
    {
        public CustomerApiClient() : this(new BlackboxApiClient())
        { }

        public CustomerApiClient(BlackboxApiClient client)
        {
            _blackboxApiClient = client;
        }

        private readonly BlackboxApiClient _blackboxApiClient;

        public BlackboxApiClient BlackboxApiClient { get { return _blackboxApiClient; } }

        public async Task<CustomerCreateApiResponse> Create(CreateCustomerRequest customer)
        {
            return await BlackboxApiClient.Post<CustomerCreateApiResponse>("customer", customer);
        }

        public async Task<CustomerCreateApiResponse> Update(CustomerUpdateRequest updateCustomer)
        {
            return await BlackboxApiClient.Put<CustomerCreateApiResponse>("customer", updateCustomer);
        }

        public async Task<CustomerCreateApiResponse> Get(int id)
        {
            return await BlackboxApiClient.Get<CustomerCreateApiResponse>(string.Concat("customer/", id.ToString()));
        }
    }
}