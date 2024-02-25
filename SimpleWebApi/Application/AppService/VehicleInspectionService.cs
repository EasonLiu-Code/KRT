using SimpleWebApi.Domain.IRepository;

namespace SimpleWebApi.Application.AppService;

/// <summary>
/// application
/// </summary>
public class VehicleInspectionService
{
    private readonly IVehicleInspectionRepository _vehicleInspectionRepository;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="vehicleInspectionRepository"></param>
    public VehicleInspectionService(IVehicleInspectionRepository vehicleInspectionRepository)
    {
        _vehicleInspectionRepository = vehicleInspectionRepository;
    }
}