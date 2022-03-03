using Core.Utilities.Helpers.GuidHelperer;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Helpers.FileHelper
{
	public class FileHelperManager : IFileHelper
	{	
		public void Delete(string filePath) //"CarImageManager'dan gelen dosyanın kaydedildiği adres ve adı
		{
			if (File.Exists(filePath)) //parametre ile gelen adreste öyle bir dosya var mı
			{
				File.Delete(filePath); //dosya varsa bulunduğu yerden sil.
			}
			
		}
		//file=>yeni resim,video veya başka bir dosya
		//filepath=>Eski dosyanın yolu
		//root=>yeni dosyanın kaydedileceği ana dizin
		public string Update(IFormFile file, string filePath, string root)//güncellenecek yeni dosya,eski dosyanın kayıt dizini ve yeni bir kayıt dizini
		{
			
			if (File.Exists(filePath)) //parametre ile gelen adreste öyle bir dosya var mı
			{
				File.Delete(filePath); //dosya varsa bulunduğu yerden sil.
			}
			return Upload(file,root); //eski dosya silindikten sonra yerine geçecek yeni dosya için Upload methoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülür.
		}

		public string Upload(IFormFile file, string root)
		{
			if (file.Length>0)//Dosya uzunluğunu bayt olarak alır.Dosya gönderilip gönderilmediğini test işlemi yapıyor.
			{
				if (!Directory.Exists(root))//system.ıo class'ı.Methodun Parametresi olan root CarManager'dan gelmekte
				{							//CarImageManager içerisine girildiğinde parametre olarak *PathConstants.ImagesPath*gönderildiği görülür.
											//PathConstants class'ı içerisinde string ifadeyle bir dizin adresi bulunur. O adres yükleyeceğimiz dosyaların
											//kayıt edileceği adres burada"CheckIfaDirectoryExists" =>dosyanın kaydedileceği adres dizini var mı?
											//varsa blokdan çıkar yoksa kodda dosyaların kayıt edilecek dizini oluşturur.
					Directory.CreateDirectory(root);
				}
				string extension = Path.GetExtension(file.FileName);//seçilen dosyanın uzantısı elde edilir.
				string guid = GuidHelper.CreateGuid();//eşsiz adını koyar.GuidHelper içinde
				string filePath = guid + extension;//Dosyanın oluşturmuş olduğumuz adını ve uzantısı yan yana gelir.Örn/metin dosyası ise (.txt)
												   //resim yüklenecekse .jpg olur uzantılar
				using (FileStream fileStream = File.Create(root + filePath))//filestream class'ının bir örneği oluşturuldu.Belirtilen yolda bir
				{															//dosya oluşturur veya üzerine yazar.			
					file.CopyTo(fileStream);//Yukardan gelen IFormFile türüdendeki file dosyasının nereye kopyalanacağını belirttik
					fileStream.Flush();//arabellekten siler. //stream ana soyut sınıfı kullanılarak genişletilmiş,belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan sınıfdır.
					return filePath;//dosyanın adını geri gönderilir sebebi SQL servere(database) dosya eklenirken adı ile eklenmesi için
				}
			}
			return null;
		}
	}
}

