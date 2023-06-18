public abstract class A_Person
{
    public int Doc { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string User { get; set; }
    public DateTime DateBirth { get; set; }
    public DateTime EntryDate { get; set; }
    public bool Active { get; set; }

    public string GetFullName()
    {
        return $"{Name} {LastName}";
    }
}