using System.Collections.Generic;


public class DeveloperTeam //Plain Old C# Object
{
    public string TeamName { get; set; }
    public int DateTeamAdded {get; set;}
    public int TeamUniqueIDNumber {get; set;}
    public string Project1
    public List<Developer> DevList = new List<Developer>();

    public DeveloperTeam(){} //Default Constrcutor

    public DeveloperTeam(string teamName, int teamUniqueIDNumber, string teamDescription)
    {
        TeamName = teamName;
        TeamUniqueIDNumber = teamUniqueIDNumber;
        TeamDescription = teamDescription; 
        DateTeamAdded = DateTeamAdded;
    }

    public DeveloperTeam (string teamName, int teamUniqueIDNumber, List<Developer> devList)
    {
        TeamName = teamName;
        TeamUniqueIDNumber = teamUniqueIDNumber;
        DevList = devList;
    }

}