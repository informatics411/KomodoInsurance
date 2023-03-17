using System.Collections.Generic;

public class DeveloperRepository
{
    private List<Developer> _developerList = new List<Developer>();
//create
    public void AddDeveloper(Developer developer){
        _developerList.Add(developer);
    } 
//read
    public List<Developer> GetDeveloperList()
    {
        return _developerList;
    }
        
//update
    public bool UpdateDeveloperInfo (Developer newDeveloperInfo)
    {   //Find the Developer by ID
        Developer knownDeveloper = GetDeveloperByID(newDeveloperInfo.DeveloperUniqueIDNumber);
        if (knownDeveloper != null) //Do you want to add developer? (UI)
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
        int initialCount = _developerList.Count;
        _developerList.Remove(developer);
        if (initialCount > _developerList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

    }

    //Helper method: list developer by ID;
    public Developer GetDeveloperByID (int developerUniqueIDNumber)
    {
        foreach (Developer developer in _developerList)
        {
            if (developer.DeveloperUniqueIDNumber == developerUniqueIDNumber)
            {
                return developer;
            }
        }   
        return null;
    }
}