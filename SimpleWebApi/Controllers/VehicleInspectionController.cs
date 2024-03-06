using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Application.IAppService;
using SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;
using SimpleWebApi.Infrastructure.Entities.VehicleInspection;

namespace SimpleWebApi.Controllers;

/// <summary>
/// 车辆检查
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class VehicleInspectionController:ControllerBase
{
    private readonly IVehicleInspectionService _vehicleInspectionService;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="vehicleInspectionService"></param>
    public VehicleInspectionController(IVehicleInspectionService vehicleInspectionService)
    {
        _vehicleInspectionService = vehicleInspectionService;
    }

    /// <summary>
    /// 根据Vin获取车辆检查信息
    /// </summary>
    /// <param name="vin"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosByVinAsync(string vin)
    {
        return await _vehicleInspectionService.GetVehicleInspectionInfosByVinAsync(vin);
    }

    /// <summary>
    /// 获取指定检测项目的信息
    /// </summary>
    /// <param name="vin"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<VehicleInspectionLocationDto>> GetVehicleInspectionLocationInfosAsync(string vin,
        string item)
    {
        return await _vehicleInspectionService.GetVehicleInspectionLocationInfosAsync(vin, item);
    }

    /// <summary>
    /// 录入车辆检查信息
    /// </summary>
    /// <param name="vehicleInfos"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> InsertVehicleInspectionInfosAsync(List<VehicleInspectionDto> vehicleInfos)
    {
        return await _vehicleInspectionService.InsertVehicleInspectionInfosAsync(vehicleInfos);
    }

    /// <summary>
    /// 获取全部车辆检查信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosAllAsync()
    {
        return await _vehicleInspectionService.GetVehicleInspectionInfosAllAsync();
    }

    /// <summary>
    /// 通过日期获取车辆检查信息
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosByDateAsync(DateTime date)
    {
        return await _vehicleInspectionService.GetVehicleInspectionInfosByDateAsync(date);
    }

    /// <summary>
    /// 通过检测项目获取最新检测信息
    /// </summary>
    /// <param name="Inspectionitem"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<VehicleInspection>> GetNewVehicleInspectionInfosByItemAsync(string Inspectionitem)
    {
        return await _vehicleInspectionService.GetNewVehicleInspectionInfosByItemAsync(Inspectionitem);
    }
}