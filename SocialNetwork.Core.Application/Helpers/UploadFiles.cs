using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Helpers
{
    public static class UploadFiles
    {
        public static string UploadImage(IFormFile file, int id, string path, bool isEditMode = false, string imagePath = "")
        {
            if(isEditMode)
                if(file == null)
                    return imagePath;

            string basePath = $"/Images/{path}/{id}";
            string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            if(!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);

            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = $"{guid}{fileInfo.Extension}";
            string fullPath = Path.Combine(pathToSave, fileName);
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            if (isEditMode)
            {
                string[] oldImage = imagePath.Split("/");
                string oldImagePath = oldImage[^1];
                string completeImagePath = Path.Combine(pathToSave, oldImagePath);
                if (File.Exists(completeImagePath))
                    File.Delete(completeImagePath);
            }
            return $"{basePath}/{fileName}";
        }
    }
}
