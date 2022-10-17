using Microsoft.EntityFrameworkCore;

namespace TomSoftware.Service;
public class TomSoftwareService<TContext> : ITomSoftwareService where TContext : DbContext
{
	public TomSoftwareService(TContext context)
	{

	}

	public void DoIt()
	{

	}
}
