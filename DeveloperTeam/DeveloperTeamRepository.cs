using System.Collections.Generic;

public class DeveloperTeamRepository
{
    private List<DeveloperTeam> _teamList = new List<DeveloperTeam>();

   //create
    public void AddTeam(DeveloperTeam team){
        _teamList.Add(team);
    } 
//read -->can I call an object called DeveloperDirectory?
    public List<DeveloperTeam> GetTeamList()
    {
        return _teamList;
    }
        
//update
    public bool UpdateTeamsList (DeveloperTeam newTeam)
    {   //Find the Team by Team ID
        DeveloperTeam knownTeam = GetTeamByID(newTeam.TeamUniqueIDNumber);
        if (knownTeam != null) //Do you want to add developer? (UI)
        {
            knownTeam.TeamUniqueIDNumber = newTeam.TeamUniqueIDNumber;//QUESTION: is this redundant, e.g., the unchangeable property?
            knownTeam.TeamName = newTeam.TeamName;
            knownTeam.TeamDescription = newTeam.TeamDescription;
            knownTeam.DateTeamAdded = newTeam.DateTeamAdded;
            return true;
            
        }
        else
        {
            return false;
        }
    }
//delete
    public bool RemoveTeam(int teamUniqueIDNumber)
    {
        DeveloperTeam team = GetTeamByID(teamUniqueIDNumber);
        if (team == null)
        {
            return false;
        }
        int initialCount = _teamList.Count;
        _teamList.Remove(team);
        if (initialCount > _teamList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
    }


    public DeveloperTeam GetTeamByID (int teamUniqueIDNumber)
    {
        foreach (DeveloperTeam team in _teamList)
        {
            if (team.TeamUniqueIDNumber == teamUniqueIDNumber)
            {
                return team;
            }
        }   
        return null;
    } 

    

    
}