using System.ComponentModel.DataAnnotations;

namespace FirstTaskFromDean.Models;

public class Rubber
{
    public Guid id { get; set; }
    public string brand { get; set; }
    [Required]
    public string name { get; set; }
    public int speed { get; set; }
    public int spin { get; set; }
    public int touch { get; set; }
    public int power { get; set; }
    
    
}