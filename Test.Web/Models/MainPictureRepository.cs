using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Test.Web.Models
{   
	public  class MainPictureRepository : EFRepository<MainPicture>, IMainPictureRepository
	{

	}

	public  interface IMainPictureRepository : IRepository<MainPicture>
	{

	}
}