namespace Infrastructure.Helpers
{
    public static class FileHelper
    {
        public static async Task<List<AbstractFile>> WriteBulkFiles<TExtensionEnum>(List<IFormFile> files, string folder) where TExtensionEnum : Enum
        {
            List<AbstractFile> fileRes = new List<AbstractFile>();
            foreach (var file in files)
            {
                //Denine if file greater than 8MB
                if (file.Length > Math.Pow(2, 20) * 8)
                {
                    continue;
                }

                var oldName = file.FileName;
                var extension = GetExtension(oldName);

                //Denine if file do not match extensions
                if (IsExtensionDefined<TExtensionEnum>(extension))
                {
                    string newName = DateTime.UtcNow.Ticks.ToString() + "." + extension;
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{folder}");

                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    var exactpath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{folder}", newName);
                    using (var stream = new FileStream(exactpath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        fileRes.Add(new AbstractFile
                        {
                            Title = oldName,
                            Extension = "." + extension,
                            Id = Guid.NewGuid(),
                            Path = newName,
                            Size = file.Length,
                            Status = StatusEnum.Active,
                            Alt = newName,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                        }); ;
                    }
                }
            }
            return fileRes;
        }

        public static async Task<AbstractFile> WriteFile<TExtensionEnum>(IFormFile file, string folder) where TExtensionEnum : Enum
        {

            if (file.Length > Math.Pow(2, 20) * 8)
            {
                return null;
            }

            var oldName = file.FileName;
            var extension = GetExtension(oldName);

            //Denine if file do not match extensions
            if (IsExtensionDefined<TExtensionEnum>(extension))
            {
                string newName = DateTime.UtcNow.Ticks.ToString() + "." + extension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{folder}");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload/{folder}", newName);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    return new AbstractFile
                    {
                        Title = oldName,
                        Extension = "." + extension,
                        Id = Guid.NewGuid(),
                        Path = newName,
                        Size = file.Length,
                        Status = StatusEnum.Active,
                        Alt = newName,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };
                }
            }
            return null;

        }

        public static string GetExtension(string name)
        {
            return Path.GetExtension(name).TrimStart('.').ToLowerInvariant();
        }

        private static bool IsExtensionDefined<TExtensionEnum>(string extension) where TExtensionEnum : Enum
        {
            extension = extension.ToLowerInvariant(); 

            return Enum.GetNames(typeof(TExtensionEnum))
                       .Any(name => name.ToLowerInvariant() == extension);
        }
    }
}
