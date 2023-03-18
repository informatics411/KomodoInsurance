using System.Collections.Generic;


public class DeveloperTeam //Plain Old C# Object
{
    public string TeamName { get; set; }
    public DateTime DateTeamAdded {get; set;}
    public int TeamUniqueIDNumber {get; set;}
    public string TeamDescription {get; set;}
    public List<Developer> DevTeamList = new List<Developer>();

    public DeveloperTeam(){} //Default Constrcutor

    public DeveloperTeam(string teamName, int teamUniqueIDNumber, string teamDescription)
    {
        TeamName = teamName;
        TeamUniqueIDNumber = teamUniqueIDNumber;
        TeamDescription = teamDescription; 
        DateTeamAdded = DateTime.Today;
    }

    public DeveloperTeam (string teamName, int teamUniqueIDNumber, List<Developer> devTeamList, string teamDescription)
    {
        TeamName = teamName;
        TeamUniqueIDNumber = teamUniqueIDNumber;
        DevTeamList = devTeamList;
        TeamDescription = teamDescription;
        DateTeamAdded = DateTime.Today;
    }

}