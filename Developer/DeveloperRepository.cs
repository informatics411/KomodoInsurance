using System.Collections.Generic;

public class DeveloperRepository
{
    private List<Developer> _developer = new List<Developer>();
//create
    public void AddDeveloper(Developer developer){
        _developer.Add(developer);
    } 
//read
    public List<Developer> GetDeveloperList()
    {
        return _developer;
    }
        
//update
    public bool UpdateDeveloperInfo (Developer newDeveloperInfo)
    {   //Find the Developer by ID
        Developer knownDeveloper = GetDeveloperByID(newDeveloperInfo.DeveloperUniqueIDNumber);
        if (knownDeveloper != null) 
        {
            knownDeveloper.DeveloperFirstName = newDeveloperInfo.DeveloperFirstName;
            knownDeveloper.DeveloperLastName = newDeveloperInfo.DeveloperLastName;
            knownDeveloper.HasPluralsightID = newDeveloperInfo.HasPluralsightID;
            knownDeveloper.PluralsightExpiryDate = newDeveloperInfo.PluralsightExpiryDate;
            return true;
            
        }
        else
        {
            return false;
        }
    }
//delete
    public bool RemoveDeveloper(int developerUniqueIDNumber)
    {
        Developer developer = GetDeveloperByID(developerUniqueIDNumber);
        if (developer == null)
        {
            return false;
        }
        int initialCount = _developer.Count;
        _developer.Remove(developer);
        if (initialCount > _developer.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

    }
    public Developer GetDeveloperByID (int developerUniqueIDNumber)
    {
        foreach (Developer developer in _developer)
        {
            if (developer.DeveloperUniqueIDNumber == developerUniqueIDNumber)
            {
                return developer;
            }
        }   
        return null;
    }

    // public Developer PlaceDeveloperOnTeam (int developerUniqueIDNumber) 
    // {
    //     GetDeveloperByID();
    //     System.Console.WriteLine("What Team should this Developer be on? Choose from below:");
    //     SeeAllDeveloperTeams();
        
    // }

    // public Developer PluralsightExpiry (int pluaralsightExpiry)
    // {
    //     GetDeveloperByID();
    //     if (Developer hasPluralsightID == true)
    //     {

    //     }
    // }
}