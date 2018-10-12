using LocationService.Business_Entities;
using LocationService.Interfaces;

namespace LocationService.Services
{
    public class PostcodeServiceClient
    {
        private readonly IAddressInfoProvider _serviceClient = null;
        public bool Enabled { get; } = true;

        public PostcodeServiceClient(IAddressInfoProviderFactory addressInfoProviderFactory)
        {
            _serviceClient = addressInfoProviderFactory.CreateProvider();
            if (_serviceClient == null)
                Enabled = false;
        }

        public Address FindAddress(string postCode)
        {
            return _serviceClient.AddressLookup(postCode);
        }
    }
}