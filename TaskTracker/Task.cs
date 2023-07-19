using System;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
