using LocationService.Business_Entities;

namespace LocationService.Interfaces
{
    public interface IAddressInfoProvider
    {
        Address AddressLookup(string strPostcode);
        IAddressParser AddressParser { get; set; }
    }
}
