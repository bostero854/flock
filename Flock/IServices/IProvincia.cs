using System.Threading.Tasks;

namespace Flock.IServices
{
    public interface IProvincia
    {
        Models.Georreferenciacion LatLon(string nombreProvincia);
        Task<Models.Georreferenciacion> LatLonAsync(string nombreProvincia);
    }
}
