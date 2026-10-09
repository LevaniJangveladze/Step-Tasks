namespace EF_Hotel.Model;

public class Passport
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string IdentityNumber { get; set; }
    
    public int GuestId { get; set; }
    public Guest? Guest { get; set; }
}