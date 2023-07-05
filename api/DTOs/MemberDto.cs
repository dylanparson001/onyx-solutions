namespace api.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PhotoUrl { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public String KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    public string Title { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public List<PhotoDto> Photos { get; set; }
}