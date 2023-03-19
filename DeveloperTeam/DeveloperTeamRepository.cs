using System.Collections.Generic;

public class DeveloperTeamRepository
{
    private List<DeveloperTeam> _team = new List<DeveloperTeam>();

//create
    public void AddTeamFromScratch(DeveloperTeam newTeam)
    {
        _team.Add(newTeam);
        Random r = new Random(); //sets up random #
        int rInt = r.Next(100, 999); //random # range
        newTeam.TeamUniqueIDNumber = rInt;
        int teamDevelopersAtStart = newTeam.DevTeamList.Count;
    } 
//read 
    public List<DeveloperTeam> GetTeamList()
    {
        return _team;
    }
        
//update
    public bool UpdateATeamAttribute (DeveloperTeam newTeam)
    {   //Find the Team by Team ID
        DeveloperTeam knownTeam = FindTeamByID(newTeam.TeamUniqueIDNumber);
        if (knownTeam != null) 
        {
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
    public bool RemoveTeamAltogether(int teamUniqueIDNumber)
    {
        DeveloperTeam team = FindTeamByID(teamUniqueIDNumber);
        if (team == null)
        {
            return false;
        }
        int initialCount = _team.Count;
        _team.Remove(team);
        if (initialCount > _team.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
    public DeveloperTeam FindTeamByID (int teamUniqueIDNumber)
    {
        foreach (DeveloperTeam team in _team)
        {
            if (team.TeamUniqueIDNumber == teamUniqueIDNumber)
            {
                return team;
            }
        }   
        return null;
    } 
}