using System.IO.IsolatedStorage;
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
    /// 获取指定检测项目数据列表
    /// </summary>
    /// <param name="vin"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task<List<VehicleInspectionLocationDto>> GetVehicleInspectionLocationInfosAsync(string vin,
        string item)
    {
        var infos = await _vehicleInspectionRepository.GetVehicleInspectionInfosByVinAsync(vin);
        var result = infos
            .Where(a => a.InspectionItem != null && a.InspectionItem.Equals(item))
            .Select(a => new VehicleInspectionLocationDto
            {
                InspectionLocation = a.InspectionLocation,
                InspectionStatus = a.InspectionStatus,
                ImageUrl = a.ImageUrl
            })
            .ToList();
        return result;
    }

    /// <summary>
    /// 获取全部车辆检查信息
    /// </summary>
    /// <returns></returns>
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosAllAsync()
    {
        return await _vehicleInspectionRepository.GetVehicleInspectionInfosAllAsync();
    }

    /// <summary>
    /// 通过日期获取车辆检查信息
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosByDateAsync(DateTime date)
    {
        return await _vehicleInspectionRepository.GetVehicleInspectionInfosByDateAsync(date);
    }

}