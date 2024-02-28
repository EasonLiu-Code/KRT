using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.IRepository;
using SimpleWebApi.Infrastructure.CommonDto.VehicleInspection;
using SimpleWebApi.Infrastructure.Entities.VehicleInspection;

namespace SimpleWebApi.Infrastructure.Repositories;

/// <summary>
/// repo
/// </summary>
public class VehicleInspectionRepository:IVehicleInspectionRepository
{
    private readonly DataDbContext _dbContext;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dbContext"></param>
    public VehicleInspectionRepository(DataDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 录入车辆检查信息
    /// </summary>
    /// <param name="vehicleInfos"></param>
    /// <returns></returns>
    public async Task<bool> InsertDataAsync(List<VehicleInspectionDto> vehicleInfos)
    {
        var vehicleInspectionInfos = new List<VehicleInspection>();
        vehicleInfos.ForEach(a=>vehicleInspectionInfos.Add(new VehicleInspection
        {
            Vin = a.Vin,
            InspectionItem = a.InspectionItem,
            InspectionTime = DateTime.Now,
            InspectionStatus = a.InspectionStatus,
            ImageUrl = a.ImageUrl
        }));
        await _dbContext.VehicleInspection.AddRangeAsync(vehicleInspectionInfos);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// 根据Vin获取车辆检查信息
    /// </summary>
    /// <param name="vin"></param>
    /// <returns></returns>
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosByVinAsync(string vin)
    {
        var res = await _dbContext.VehicleInspection.
            Where(v => v.Vin != null && v.Vin.Equals(vin)).ToListAsync();
        return res is not {Count:>0} ? new List<VehicleInspection>() : res;
    }

    /// <summary>
    /// 获取全部车辆检查信息
    /// </summary>
    /// <returns></returns>
    public async Task<List<VehicleInspection>> GetVehicleInspectionInfosAllAsync()
    {
        var res = await _dbContext.VehicleInspection.ToListAsync();
        return res is not { Count: > 0 } ? new List<VehicleInspection>() : res;
    }


}