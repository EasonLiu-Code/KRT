using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;
using SimpleWebApi.Infrastructure.Entities.VehicleInspection;

namespace SimpleWebApi.Application.AppService;

/// <summary>
/// application
/// </summary>
public class VehicleInspectionService:IVehicleInspectionService
{
    private readonly IVehicleInspectionRepository _vehicleInspectionRepository;

    /// <summary>
    /// ctor构造函数
    /// </summary>
    /// <param name="vehicleInspectionRepository"></param>
    public VehicleInspectionService(IVehicleInspectionRepository vehicleInspectionRepository)
    {
        _vehicleInspectionRepository = vehicleInspectionRepository;
    }
    /// <summary>
    /// 录入车辆检查信息
    /// </summary>
    /// <param name="vehicleInfos"></param>
    /// <returns></returns>
    public async Task<bool> InsertVehicleInspectionInfosAsync(List<VehicleInspectionDto> vehicleInfos)
    {
        return await _vehicleInspectionRepository.InsertDataAsync(vehicleInfos);
    }

    /// <summary>
    /// 根据vin获取车辆检查信息
    /// </summary>
    /// <param name="vin"></param>
    /// <returns></returns>
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosByVinAsync(string vin)
    {
        return await _vehicleInspectionRepository.GetVehicleInspectionInfosByVinAsync(vin);
    }

    /// <summary>
    /// 获取全部车辆检查信息
    /// </summary>
    /// <returns></returns>
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosAllAsync()
    {
        return await _vehicleInspectionRepository.GetVehicleInspectionInfosAllAsync();
    }

}