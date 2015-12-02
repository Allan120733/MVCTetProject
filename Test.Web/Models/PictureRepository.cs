using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Test.Web.Models
{   
	public  class PictureRepository : EFRepository<Picture>, IPictureRepository
	{

	}

	public  interface IPictureRepository : IRepository<Picture>
	{

	}
}