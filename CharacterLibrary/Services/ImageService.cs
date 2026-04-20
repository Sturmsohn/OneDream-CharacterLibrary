namespace CharacterLibrary.Services
{
    /// <summary>
    /// Handles copying user-selected image files into the app's local Images folder
    /// and producing a relative path suitable for storing in Character.ImagePath.
    /// </summary>
    public static class ImageService
    {
        public static string ImagesFolder => Path.Combine(AppContext.BaseDirectory, "Images");

        /// <summary>
        /// Copies the source file into the Images folder with a unique name and
        /// returns a relative path like "Images/abc123.png" suitable for DB storage.
        /// </summary>
        public static string ImportImage(string sourcePath)
        {
            Directory.CreateDirectory(ImagesFolder);
            var ext = Path.GetExtension(sourcePath);
            var newName = $"{Guid.NewGuid():N}{ext}";
            var destPath = Path.Combine(ImagesFolder, newName);
            File.Copy(sourcePath, destPath, overwrite: false);
            return Path.Combine("Images", newName).Replace('\\', '/');
        }

        /// <summary>
        /// Resolves a stored relative path to an absolute file path on disk.
        /// Returns null if the stored path is empty or the file doesn't exist.
        /// </summary>
        public static string? ResolveAbsolute(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return null;
            var abs = Path.IsPathRooted(relativePath)
                ? relativePath
                : Path.Combine(AppContext.BaseDirectory, relativePath);
            return File.Exists(abs) ? abs : null;
        }
    }
}
