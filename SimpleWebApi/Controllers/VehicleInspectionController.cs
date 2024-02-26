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
    /// 录入车辆检查信息
    /// </summary>
    /// <param name="vehicleInfos"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> InsertVehicleInspectionInfosAsync(List<VehicleInspectionDto> vehicleInfos)
    {
        return await _vehicleInspectionService.InsertVehicleInspectionInfosAsync(vehicleInfos);
    }

}