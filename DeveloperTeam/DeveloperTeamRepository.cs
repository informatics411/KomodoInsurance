using System.Collections.Generic;

public class DeveloperTeamRepository
{
    private List<DeveloperTeam> _team = new List<DeveloperTeam>();

   //create
    public void AddTeam(DeveloperTeam newTeam){
        _team.Add(newTeam);
    } 
//read 
    public List<DeveloperTeam> GetTeamList()
    {
        return _team;
    }
        
//update
    public bool UpdateTeamsAttributes (DeveloperTeam newTeam)
    {   //Find the Team by Team ID
        DeveloperTeam knownTeam = GetTeamByID(newTeam.TeamUniqueIDNumber);
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
    public bool RemoveTeam(int teamUniqueIDNumber)
    {
        DeveloperTeam team = GetTeamByID(teamUniqueIDNumber);
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
    public DeveloperTeam GetTeamByID (int teamUniqueIDNumber)
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

    public DeveloperTeam AddDeveloperToTeam();
    {
        SeeAllTeams();
        GetTeamByID();
        System.Console.WriteLine("Choose the Team you want Developers added:");
        expandingTeam = int.Parse(Console.ReadLine();
        List<DeveloperTeam> expandingTeam = new _developerTeamRepos.GetTeamByID();
        
        developerToBeAdded = int.Parse(Console.ReadLine());
    int teamSizeBeforeAddition = expandingTeam.Count;
    teamAddingDeveloper.Add(developerToBeAdded);
    int teamSizeAfterAddition = teamAddingDeveloper.Count;
        if (teamSizeBeforeAddition == teamSizeAfterAddition)
        {
    }


    
}