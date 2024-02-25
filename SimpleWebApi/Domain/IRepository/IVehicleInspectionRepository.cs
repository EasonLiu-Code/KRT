using SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;
using SimpleWebApi.Infrastructure.Entities.VehicleInspection;

namespace SimpleWebApi.Domain.IRepository;

/// <summary>
/// 
/// </summary>
public interface IVehicleInspectionRepository
{
   /// <summary>
   /// 录入车辆检查信息
   /// </summary>
   /// <param name="vehicleInfos"></param>
   /// <returns></returns>
   Task<bool> InsertDataAsync(List<VehicleInspectionDto> vehicleInfos);

   /// <summary>
   /// 通过Vin获取车辆检查信息
   /// </summary>
   /// <param name="vin"></param>
   /// <returns></returns>
   Task<List<VehicleInspection>> GetVehicleInspectionInfosByVinAsync(string vin);
}