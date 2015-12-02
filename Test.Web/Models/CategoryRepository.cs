using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Test.Web.Models
{   
	public  class CategoryRepository : EFRepository<Category>, ICategoryRepository
	{

	}

	public  interface ICategoryRepository : IRepository<Category>
	{

	}
}