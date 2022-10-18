using Microsoft.EntityFrameworkCore;
using WorkShopContext;
using WorkShopContext.Models;

namespace TomSoftware.Service;

public interface ITomSoftwareService
{
	public void DoIt();
}
public class TomSoftwareService
{
	public TomSoftwareService()
	{

	}

	private readonly IEntityBaseRepository<WorkShopItem> _tomSoftwareRepository;
    public TomSoftwareService(
        IEntityBaseRepository<WorkShopItem> tomSoftwareRepository)
	{
		_tomSoftwareRepository = tomSoftwareRepository;
	}

	public void DoIt()
	{
		_tomSoftwareRepository.Add(new() { Name = "TOM", Price = 1.22 });
		_tomSoftwareRepository.Commit();
        //this.DbContext.Database.EnsureCreated();
	}
}
