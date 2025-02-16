using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Category
{
   // [JsonPropertyName("id")]
    public int Id {get;set;}

    [Required(ErrorMessage = "name is required")]
    [MinLength(2, ErrorMessage = "minimum 2 characters should be there in name")]
    [MaxLength(10, ErrorMessage = "maximum 10 characters should be there in name")]

   // [JsonPropertyName("name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "order is required")]
    [Range(1, 10, ErrorMessage = "order should be between 1 and 10")]
   //[JsonPropertyName("order")]
    public int Order { get; set; }
}
