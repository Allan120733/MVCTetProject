using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Test.Web.Models
{   
	public  class RecordRepository : EFRepository<Record>, IRecordRepository
	{

	}

	public  interface IRecordRepository : IRepository<Record>
	{

	}
}