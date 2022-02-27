using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Helpers.FileHelper
{
	public interface IFileHelper
	{
		string Upload(IFormFile file, string root); //IFormFile==>HttpRequest ile gönderilen bir dosyayı temsil eder.Projeye dosa yüklemek kullanılan yöntem.

		void Delete(string filePath);

		string Update(IFormFile file, string filePath, string root);
	}
}
