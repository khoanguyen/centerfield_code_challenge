using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Model;

public class CoffeeShop
{    
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    
    public byte[] Timestamp { get; set; }

    public bool IsOpen => 
        TimeOnly.FromDateTime(DateTime.Now) >= OpeningTime && 
        TimeOnly.FromDateTime(DateTime.Now) <= ClosingTime;
}