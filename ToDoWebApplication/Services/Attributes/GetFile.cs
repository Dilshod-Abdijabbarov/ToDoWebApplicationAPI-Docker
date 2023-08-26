using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace ToDoWebApplication.Services.Attributes
{
    public class GetFile : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var path=(string)value;
            if (!File.Exists(path))
                return new ValidationResult("File not fount...");
            string[] extensions = new string[] { ".png", ".jpg", ".ico" };
            var extension = Path.GetExtension(path);

            if (!extensions.Contains(extension))
                return new ValidationResult("This photo extension is not allowed! Allowed extensions in png,jpg,ico");

            return ValidationResult.Success;
        }
    }
}
