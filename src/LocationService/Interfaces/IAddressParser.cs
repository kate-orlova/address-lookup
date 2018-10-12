using LocationService.Business_Entities;

namespace LocationService.Interfaces
{
    public interface IAddressParser
    {
        Address Parse(string addressString, Address baseAddress);
    }
}
