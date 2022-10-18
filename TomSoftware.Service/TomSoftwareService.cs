using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WorkShopContext;
using WorkShopContext.Models;

namespace TomSoftware.Service;

public interface ITomSoftwareService
{
    public void Create(WorkShopItem item);
	public List<WorkShopItem> ListAll();
	public WorkShopItem GetByID(int id);
	public void DeleteByID(int id);
	public void Edit(WorkShopItem item);
}
public class TomSoftwareService : ITomSoftwareService
{
	private readonly IEntityBaseRepository<WorkShopItem> _tomSoftwareRepository;
    public TomSoftwareService(
        IEntityBaseRepository<WorkShopItem> tomSoftwareRepository)
	{
		_tomSoftwareRepository = tomSoftwareRepository;
	}

	public WorkShopItem GetByID(int id)
	{
		return _tomSoftwareRepository.GetSingle(id);
	}

	public List<WorkShopItem> ListAll()
	{
		return _tomSoftwareRepository.GetAll().ToList();
	}

	public void DeleteByID(int id)
	{
		try
		{
			_tomSoftwareRepository.Delete(_tomSoftwareRepository.GetSingle(id));
			_tomSoftwareRepository.Commit();
		}
		catch (Exception)
		{
		}
	}

	public void Edit(WorkShopItem item)
	{
		try
		{
			_tomSoftwareRepository.Edit(item);
            _tomSoftwareRepository.Commit();
        }
		catch (Exception)
		{

		}
	}

	public void Create(WorkShopItem item)
	{
		_tomSoftwareRepository.Add(item);
		_tomSoftwareRepository.Commit();
        //this.DbContext.Database.EnsureCreated();
	}
}
