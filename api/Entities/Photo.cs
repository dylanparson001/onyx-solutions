using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities;

[Table(("Photos"))]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string PublicId { get; set; }

    public int EmployeeUserId { get; set; }
    public Employee Employee { get; set; }
}