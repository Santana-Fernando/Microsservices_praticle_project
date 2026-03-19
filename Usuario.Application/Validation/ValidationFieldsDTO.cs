using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Usuario.Application;

public class ValidationFieldsDTO
{
    public bool IsValid { get; set; }
    public List<ValidationResult> ErrorMessages { get; set; } = new List<ValidationResult>();
}
