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
    /// 获取车辆检测位置信息
    /// </summary>
    /// <param name="vin"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    Task<List<VehicleInspectionLocationDto>> GetVehicleInspectionLocationInfosAsync(string vin,
        string item);

    /// <summary>
    /// 获取全部车辆检查信息
    /// </summary>
    /// <returns></returns>
    Task<List<VehicleInspection>> GetVehicleInspectionInfosAllAsync();

    /// <summary>
    /// 通过日期获取车辆检查信息
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<List<VehicleInspection>> GetVehicleInspectionInfosByDateAsync(DateTime date);

    /// <summary>
    /// 通过检测项目获取最新检测内容
    /// </summary>
    /// <param name="InspectionItem"></param>
    /// <returns></returns>
    Task<List<VehicleInspection>> GetNewVehicleInspectionInfosByItemAsync(string InspectionItem);
}
