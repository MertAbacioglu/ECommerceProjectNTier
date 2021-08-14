using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUploader
    {
        
        public static string UploadImage(string serverPath,HttpPostedFileBase file)
        {      
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                

                serverPath = serverPath.Replace("~",string.Empty);
                string[] fileArray = file.FileName.Split('.'); //
                string extension = fileArray[fileArray.Length - 1].ToLower();

                string fileName = $"{uniqueName}.{extension}";

                if (extension=="jpg"||extension=="gif"||extension=="png"||extension=="jpeg")
                {
                   
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1"; //Ancak Guid kullandıgımız icin aslında aynı ismin tekrarlanmaması konusunda bayagı güvendeyiz...Yine de 1'i yani dosya zaten var kodunu burada Algoritmik olarak cagırmak durumundayız...

                    }

                    string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                    file.SaveAs(filePath);
                    return serverPath + fileName;

                }
                
                return "2"; //secilen dosyanın uzantısı bizim istedigimiz gibi degil...





            }

            return "3"; //dosya null...
        }
    }
}
