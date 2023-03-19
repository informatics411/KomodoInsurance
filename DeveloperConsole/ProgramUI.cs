using System.Collections.Generic;

// using DeveloperRepository;
// using DeveloperTeamRepository;
public class ProgramUI
{
    private DeveloperRepository _developerRepos = new DeveloperRepository();
    private DeveloperTeamRepository _developerTeamRepos = new DeveloperTeamRepository();

    public void Run()
    {
        //SeedTeamList();
        Menu();
    }

    private void Menu()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.Clear();

            System.Console.WriteLine($"Developer Directory Options on {DateTime.Today.Date}:\n" +
                    " 1. Add New Developer\n" +
                    " 2. View Developers\n" +
                    " 3. View Developer By ID\n" +
                    " 4. View Developers Who Have Pluralsight Licenses\n" +
                    " 5. Update Existing Developer\n" +
                    " 6. Delete Existing Developer\n" +
                    " 7. View all Teams\n" +
                    " 8. Add New Team\n" +
                    " 9. Update Existing Team\n" +
                    "10. Delete Existing Team\n" +
                    "11. Exit\n");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ChoosingToAddNewDeveloper();
                    break;
                case "2": //View all Developers
                    ChoosingToSeeAllDevelopers();
                    break;
                case "3": //View Developer by ID
                    ChoosingToSeeADeveloperByID();
                    break;
                case "4": //View Developer by Has Pluralsight
                    // DeveloperByPluralsightExpiry();
                    break;
                case "5": //Update existing Developer
                    ChoosingToChangeDeveloperInfo();
                    break;
                case "6": //Delete existing Developer
                    ChoosingToRemoveADeveloper();
                    break;
                case "7":
                    ChoosingToSeeAllTheTeams();
                    break;
                case "8":
                    ChoosingToAddNewTeam();
                    break;
                case "9":
                    ChoosingToAssignDeveloperToTeam();
                    break;
                case "10":
                    ChoosingToRemoveATeam();
                    break;
                // Exit
                case "11":
                    System.Console.WriteLine("Goodbye");
                    keepRunning = false;
                    break;

                default:
                    System.Console.WriteLine("Please enter a number from the Menu.");
                    break;
            }
        }
    }

    private void ChoosingToAddNewDeveloper()
    {
        Console.Clear();
        Developer newDeveloper = new Developer();
        //Last name
        System.Console.WriteLine("What's the new Developer's _last_ name:");
        newDeveloper.DeveloperLastName = Console.ReadLine();
        //First name
        System.Console.WriteLine("What's the new Developer's _first_ name:");
        newDeveloper.DeveloperFirstName = Console.ReadLine();
        //UniqueID
       
        Random r = new Random(); //sets up random #
        int rInt = r.Next(32333, 99999);
        newDeveloper.DeveloperUniqueIDNumber = rInt; //assigns rnd to Developer
         System.Console.WriteLine("This will be their unique ID at Komono Insurance: {rInt}. ");
        //[LATER] checks uniqueness of ID number? 
        //Do they have Pluralsight (part 1)?
        System.Console.WriteLine("Do they have a Pluralsight License? (yes or no)");
        string hasPluralsightID = Console.ReadLine().ToLower();
        if (hasPluralsightID == "y" || hasPluralsightID == "yes")
        {//if they have Pluralsight, ask for expiry
            newDeveloper.HasPluralsightID = true;
            // System.Console.WriteLine("When does their Plurlasight membership expire? (YEAR/MO/DAY");
            // int pluralsightExpiryDate = int.Parse(Console.ReadLine());
        }
        else
        {
            newDeveloper.HasPluralsightID = false;
            // pluralsightExpiryDate = DateTime.Today.ToShortDateString;
        }

        // newDeveloper.DateDeveloperAdded = DateTime.Today.ToShortDateString;
        _developerRepos.AddDeveloper(newDeveloper);
    }

    private void ChoosingToAddNewTeam()
    {   
       bool nowAdding = true;
        while (nowAdding)
        {
        Console.Clear();
        System.Console.WriteLine("....working...creating space for...new....Team...");
        DeveloperTeam newTeam = new DeveloperTeam();
        System.Console.WriteLine("What are we going to call the new team?");
        newTeam.TeamName = Console.ReadLine();
        System.Console.WriteLine($"\nDescribe Team {newTeam.TeamName}:");
        newTeam.TeamDescription = Console.ReadLine();
        Random r = new Random(); //sets up random #
        int rInt = r.Next(100,999); //random # range
        newTeam.TeamUniqueIDNumber = rInt;
        System.Console.WriteLine($"{newTeam.TeamName}, described as '{newTeam.TeamDescription}' and has the Unique ID: {newTeam.TeamUniqueIDNumber}.");
        nowAdding = false;
        Menu();
    }


    private void ChoosingToSeeAllDevelopers()
    {
        Console.Clear();
        List<Developer> _listOfDevelopers = new List<Developer>();
        foreach (Developer developer in _listOfDevelopers)
        {
            System.Console.WriteLine($"Developer name:{developer.DeveloperLastName} {developer.DeveloperLastName}\nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber}\nThey have Pluralsight? {developer.HasPluralsightID}");
        }
    }

    private void ChoosingToSeeAllTheTeams()
    {
        Console.Clear();
        List<DeveloperTeam> _listofTeams = new List<DeveloperTeam>();
        foreach (DeveloperTeam team in _listofTeams)
        {
            System.Console.WriteLine($"Team name: {team.TeamName} \nTeam ID Number: {team.TeamUniqueIDNumber} \n");
        }
    }

    private void ChoosingToSeeADeveloperByID()
    {
        Console.Clear();
        ChoosingToSeeAllDevelopers();
        System.Console.WriteLine("To learn more about a Developer, enter their ID number:");
        int searchByUniqueDeveloperIDNumber = int.Parse(Console.ReadLine());
        Developer developer = _developerRepos.GetDeveloperByID(searchByUniqueDeveloperIDNumber);
        if (developer != null)
        {
            System.Console.WriteLine($"First Name: {developer.DeveloperFirstName} {developer.DeveloperLastName} /nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber} /nDo they have a Pluralsight license? {developer.HasPluralsightID}/nAnd if so, when does it expire? {developer.PluralsightExpiryDate}");
        }
    }

    private void ChoosingToSeeTeambyID()
    {
        Console.Clear();
        ChoosingToSeeAllTheTeams();
        System.Console.WriteLine("To see more about a Team, enter its ID number:");
        int searchByUniqueTeamIDNumber = int.Parse(Console.ReadLine());
        DeveloperTeam team = _developerTeamRepos.FindTeamByID(searchByUniqueTeamIDNumber);
        if (team != null)
        {
            System.Console.WriteLine($"Team Name:{team.TeamName}/nTeam ID:{team.TeamUniqueIDNumber}");
        }
        else
        {
            System.Console.WriteLine("Could not find a Team with that ID Number.");
        }
    }

    // private void DeveloperByPluralsightExpiry()
    // {
    // }

    public void ChoosingToRemoveADeveloper()
    {
        ChoosingToSeeAllDevelopers();
        System.Console.WriteLine("\nEnter the ID of the Developer you would like to remove: ");
        int findUniqueDeveloperID = int.Parse(Console.ReadLine());
        bool wasDeleted = _developerRepos.RemoveDeveloper(findUniqueDeveloperID);
        if (wasDeleted)
        {
            System.Console.WriteLine("That Developer has been deleted.");
        }
        else
        {
            System.Console.WriteLine("That Developer could not be deleted. Please contact your administrator.");
        }
    }


    public void ChoosingToRemoveATeam()
    {
        ChoosingToSeeAllTheTeams();
        System.Console.WriteLine("\nEnter the ID of the Team you would like to remove: ");
        int findUniqueTeamID = int.Parse(Console.ReadLine());
        bool wasDeleted = _developerTeamRepos.RemoveTeamAltogether(findUniqueTeamID);
        if (wasDeleted)
        {
            System.Console.WriteLine("That Team has been deleted.");
        }
        else
        {
            System.Console.WriteLine("That Team could not be deleted.");
        }
    }

    public void ChoosingToChangeDeveloperInfo()
    {
        ChoosingToSeeAllDevelopers();
        ChoosingToSeeADeveloperByID();
        System.Console.WriteLine("\nEnter the ID of the Developer whose information you want to change:");
        int findUniqueDeveloperID = int.Parse(Console.ReadLine());
        Developer developer = _developerRepos.GetDeveloperByID(findUniqueDeveloperID);
        if (developer != null)
        {
            System.Console.WriteLine($"First Name: {developer.DeveloperFirstName} {developer.DeveloperLastName} /nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber} /nDo they have a Pluralsight license? {developer.HasPluralsightID}/nAnd if so, when does it expire? {developer.PluralsightExpiryDate}");
        }
    }

    public void ChoosingToUpdateTeamAttributes()
    {
        ChoosingToSeeAllTheTeams();
        ChoosingToSeeTeambyID();
        System.Console.WriteLine("\nEnter the ID of the Team which has information you'd like to change:");
        int findUniqueTeamID = int.Parse(Console.ReadLine());
        DeveloperTeam team = _developerTeamRepos.FindTeamByID(findUniqueTeamID);
        if (findUniqueTeamID != null)
        {
            System.Console.WriteLine($"Team Name: {team.TeamName} /nTeam Description: {team.TeamDescription}");
            //[LATER]Check to see if Team name in use?
        }
    }

    public void ChoosingToAssignDeveloperToTeam()
    {
        ChoosingToSeeAllTheTeams();
        System.Console.WriteLine("Choose the Team's ID to which you'd like to add Developers:");
        int chosenTeamUniqueID = int.Parse(Console.ReadLine());
        if (chosenTeamUniqueID > 100 || chosenTeamUniqueID > 1000)
        {
            DeveloperTeam thisTeamNow = _developerTeamRepos.FindTeamByID(chosenTeamUniqueID);
            System.Console.WriteLine($"Are you ready to add Developers to {thisTeamNow.TeamName}?");
        }
        else
        {
            System.Console.WriteLine("That Team isn't in this Directory.");
        }
        ChoosingToSeeAllDevelopers();
        DeveloperTeam thisTeamAgain = _developerTeamRepos.FindTeamByID(chosenTeamUniqueID);
        System.Console.WriteLine($"Now choose the Developer you want to add to {thisTeamAgain.TeamName}:");
        int developerToAdd = int.Parse(Console.ReadLine());
        bool stillChoosing = true;
        while (stillChoosing)
        //int developerChosenForTeam = int.Parse(Console.ReadLine());
        System.Console.WriteLine($"You'd like to add {developerToAdd} (yes or no)?");
        Developer developer = _developerRepos.GetDeveloperByID(developerToAdd);
        string confirmAdd = Console.ReadLine().ToLower();
        if (confirmAdd == "yes")
        {
            thisTeamAgain.DevTeamList.Add(developer);
        }
        else
        {
            System.Console.WriteLine($"Again, choose the Developer you\'d like to add to {thisTeamAgain.TeamName}:");
        }

        System.Console.WriteLine($"{developerToAdd} is now a member of {thisTeamAgain.TeamName}");
        System.Console.WriteLine($"Would you like to add another Developer to {thisTeamAgain.TeamName}?");
        string anotherDeveloperForTeam = Console.ReadLine().ToLower();
        if (anotherDeveloperForTeam == "yes")
        {
            ChoosingToSeeAllDevelopers();
            System.Console.WriteLine($"Now choose the Developer you want to add to {thisTeamAgain.TeamName}:");
            int yetAdditionalDeveloper = int.Parse(Console.ReadLine());
            // bool choosingYetAdditionalDeveloper = true;
            // while (choosingYetAdditionalDeveloper)
            //     int developerChosenForTeam = int.Parse(Console.ReadLine());
            System.Console.WriteLine($"You'd like to add {yetAdditionalDeveloper} (yes or no)?");
            string confirmAdditionalAdd = Console.ReadLine().ToLower();
            if (confirmAdditionalAdd == "yes")
            {
                thisTeamAgain.DevTeamList.Add(developer);
            }
            else
            {
                System.Console.WriteLine($"Again, choose the Developer you\'d like to add to {thisTeamAgain.TeamName}:");
            }
        }
    }
//     public void ChoosingToAssignDeveloperToTeam ()
// {
//     GetTeamByID();
//     System.Console.Writeline("Using Team ID Number, choose a Team you want to add a Developer to.");
//     int teamGettingDeveloper = int.Parse(ReadLine());
//     List<DeveloperTeam> expandingTeam = new _developerTeamRepos.GetTeamByID();
//     System.Console.WriteLine($"\nChoose the ID Number of the person who you want on Team {expandingTeam}:\n");
//     SeeAllDevelopers();
//     developerToBeAdded = int.Parse(Console.ReadLine());
//     int teamSizeBeforeAddition = expandingTeam.Count;
//     teamAddingDeveloper.Add(developerToBeAdded);
//     int teamSizeAfterAddition = teamAddingDeveloper.Count;
//         if (teamSizeBeforeAddition == teamSizeAfterAddition)
//         {
//         System.Console.WriteLine("Try again! Nobody was added to the Team.");
//         }   
//         else
//         {
//         System.Console.WriteLine($"Success! You've added {developerToBeAdded} to {expandingTeam}.");
//         }
// }






}

// keepRunning = false


