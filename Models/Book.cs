using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(100)]
    public string Author { get; set; }

    [Required]
    [StringLength(13)]
    [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", 
        ErrorMessage = "Invalid ISBN format")]
    public string ISBN { get; set; }

    [Range(0.01, 1000.00)]
    public decimal Price { get; set; }
} 