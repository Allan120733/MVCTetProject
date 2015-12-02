using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Test.Web.Models
{   
	public  class ProjectRepository : EFRepository<Project>, IProjectRepository
	{

	}

	public  interface IProjectRepository : IRepository<Project>
	{

	}
}