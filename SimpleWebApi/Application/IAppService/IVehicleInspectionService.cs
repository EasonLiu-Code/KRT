using SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;
using SimpleWebApi.Infrastructure.Entities.VehicleInspection;

namespace SimpleWebApi.Application.IAppService;

/// <summary>
/// I
/// </summary>
public interface IVehicleInspectionService
{
    /// <summary>
    /// 录入车辆检查信息
    /// </summary>
    /// <param name="vehicleInfos"></param>
    /// <returns></returns>
    Task<bool> InsertVehicleInspectionInfosAsync(List<VehicleInspectionDto> vehicleInfos);

    /// <summary>
    /// 根据vin获取车辆检查信息
    /// </summary>
    /// <param name="vin"></param>
    /// <returns></returns>
    Task<List<VehicleInspection>> GetVehicleInspectionInfosByVinAsync(string vin);

    /// <summary>
    /// 获取全部车辆检查信息
    /// </summary>
    /// <returns></returns>
    Task<List<VehicleInspection>> GetVehicleInspectionInfosAllAsync();
}