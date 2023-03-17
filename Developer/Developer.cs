public class Developer  //Plain Old C# Object
{
    public string DeveloperLastName { get; set; }
    public string DeveloperFirstName { get; set; }
    public int DeveloperUniqueIDNumber { get; set; }
    public bool HasPluralsightID { get; set; }
    public int PluralsightExpiryDate {get; set;}
    public int DateDeveloperAdded {get; set;}
    

    public Developer(){}

   public Developer(string developerLastName, string developerFirstName,int developerUniqueIDNumber, bool hasPluralsightID, int pluralsightExpiryDate, int dateDeveloperAdded)
    {
        DeveloperLastName = developerLastName;
        DeveloperFirstName = developerFirstName;
        DeveloperUniqueIDNumber = developerUniqueIDNumber;
        HasPluralsightID = hasPluralsightID;
        PluralsightExpiryDate = pluralsightExpiryDate; 
        DateDeveloperAdded = dateDeveloperAdded;
    }

}