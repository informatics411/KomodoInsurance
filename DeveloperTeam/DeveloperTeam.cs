public class DeveloperTeam //Plain Old C# Object
{
    public string TeamName { get; set; }
    public int TeamUniqueIDNumber {get; set;}
    public string TeamDescription {get; set;}
    public int DateTeamAdded {get; set;}
  

    public DeveloperTeam(){} //Default Constrcutor

    public DeveloperTeam(string teamName, int teamUniqueIDNumber, string teamDescription)
    {
        TeamName = teamName;
        TeamUniqueIDNumber = teamUniqueIDNumber;
        TeamDescription = teamDescription; 
        DateTeamAdded = DateTeamAdded;
    }

}