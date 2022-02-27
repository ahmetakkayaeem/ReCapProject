using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelperer
{
	public class GuidHelper
	{
		public static string CreateGuid()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
//yüklenilecek olan dosya için eşsiz bir isim oluşturuyor.Yüklenen dosya kendi ismiyle olmasın diye.Çünkü ilerde başka bir dosyayla aynı
//isimden dolayı çakışma yaşanmasın.
//guid.NewGuid()==>bu method eşsiz bir değer oluşturur.
//toStrin()==> string hale gelir.
