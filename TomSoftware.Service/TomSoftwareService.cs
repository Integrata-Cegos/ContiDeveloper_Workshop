using Microsoft.EntityFrameworkCore;
using WorkShopContext;
using WorkShopContext.Models;

namespace TomSoftware.Service;

public interface ITomSoftwareService
{
	public void DoIt();
}
public class TomSoftwareService : ITomSoftwareService
{
	private readonly IEntityBaseRepository<WorkShopItem> _tomSoftwareRepository;
    public TomSoftwareService(
        IEntityBaseRepository<WorkShopItem> tomSoftwareRepository)
	{
		_tomSoftwareRepository = tomSoftwareRepository;
	}

	public void DoIt()
	{
		_tomSoftwareRepository.Add(new() { Name = "TOM", Price = new Random().Next(1000) });
		_tomSoftwareRepository.Commit();
        //this.DbContext.Database.EnsureCreated();
	}
}
