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

            System.Console.WriteLine("Developer Directory Options on {DateTime:YearMoDay}:\n" +
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
                    AddNewDeveloper();
                    break;
                case "2": //View all Developers
                    SeeAllDevelopers();
                    break;
                case "3": //View Developer by ID
                    SeeDeveloperbyID();
                    break;
                case "4": //View Developer by Has Pluralsight
                    // DeveloperByPluralsightExpiry();
                    break;
                case "5": //Update existing Developer
                    UpdateDeveloperAttributes();
                    break;
                case "6": //Delete existing Developer
                    RemoveDeveloper();
                    break;
                case "7":
                    SeeAllTeams();
                    break;
                case "8":
                    AddNewTeam();
                    break;
                case "9":
                    UpdateTeamAttributes();
                    break;
                case "10":
                    RemoveTeam();
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

        private void AddNewDeveloper()
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
            System.Console.WriteLine("This will be their unique ID at Komono Insurance: ");
            Random r = new Random(); //sets up random #
            int rInt = r.next(32333,99999);
            newDeveloper.DeveloperUniqueIDNumber = rInt; //assigns rnd to Developer
            //[LATER] checks uniqueness of ID number? 
            //Do they have Pluralsight (part 1)?
            System.Console.WriteLine("Do they have a Pluralsight License? (yes or no)");
            newDeveloper.HasPluralsightID = Console.ReadLine().ToLower;
            if (newDeveloper.HasPluralsightID = "y" || newDeveloper.HasPluralsightID = "yes")
            {//if they have Pluralsight, ask for expiry
                System.Console.WriteLine("When does their Plurlasight membership expire? (YEAR/MO/DAY");
                pluralsightExpiryDate = Console.ReadLine();
            }
            else
            {
                pluralsightExpiryDate = DateTime.Today.ToShortDateString;
            }

            newDeveloper.DateDeveloperAdded = DateTime.Today.ToShortDateString;
            _developerRepo.AddDeveloper(newDeveloper);
        }

        private void AddNewTeam()
        {
            Console.Clear();
            DeveloperTeam newTeam = new DeveloperTeam();
            System.Console.WriteLine("What are we going to call the new team?");
            newDeveloperTeam.TeamName = Console.ReadLine();
            string newName = newDeveloperTeam.TeamName;
            Random r = new Random(); //sets up random #
            int rInt = r.next(100,999); //random # range
            newDeveloper.DeveloperUniqueIDNumber = rInt;
            System.Console.WriteLine("{newName}'s unique ID Number is: {rInt}.");
            System.Console.WriteLine("\nThis describes's the team:");
            char teamBlurb = Console.ReadLine();
            System.Console.WriteLine("Do you want to add Developers to this Team now? (yes or no)");
            addMembersNow = Console.ReadLine();
            if (addMembersNow = "yes")
            {
                System.Console.WriteLine("\nChoose from the list of Developers who gets to be on Team {newName}:\n");
                SeeAllDevelopers();
                developerAssignment = Console.ReadLine();
                System.Console.WriteLine("developer");
            }
            else
            {
                System.Console.WriteLine("Team {newName} has now been added.");
            }
        }   


        private void SeeAllDevelopers()
        {
            Console.Clear();
            List<Developer> _listOfDevelopers = new List<Developers>();
            foreach (Developer developer in _listOfDevelopers)
            {
                System.Console.WriteLine($"Developer name:{developer.DeveloperLastName} {developer.DeveloperLastName}\nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber}\nThey have Pluralsight? {developer.HasPluralsightID}");
                }
        }

        private void SeeAllTeams()
        {
            Console.Clear();
            List<DeveloperTeam> _listofTeams = new List<DeveloperTeam>();
            foreach (DeveloperTeam team in _listofTeams)
            {
                System.Console.WriteLine($"Team name: {DeveloperTeam.TeamName} /nTeam ID Number: {DeveloperTeam.TeamUniqueIDNumber} /nDevelopers on Team: {List<DeveloperTeam>.Count}");
            }
        }

        private void SeeDeveloperbyID()
        {
            Console.Clear();
            SeeAllDevelopers();
            System.Console.WriteLine("To learn more about a Developer, enter their ID number:");
            int searchByUniqueDeveloperIDNumber = int.Parse(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloperByID(uniqueDeveloperIDNumber);
            if (developer != null)
            {
                System.Console.WriteLine($"First Name: {developer.DeveloperFirstName} {developer.DeveloperLastName} /nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber} /nDo they have a Pluralsight license? {developer.HasPluralsightID}/nAnd if so, when does it expire? {developer.PluralsightExpiryDate}");
            }
        }

        private void SeeTeambyID()
        {
            Console.Clear();
            SeeAllTeams();
            System.Console.WriteLine("To see more about a Team, enter its ID number:");
            int searchByUniqueTeamIDNumber = int.Parse(Console.ReadLine());
            DeveloperTeam team = _developerTeamRepos.GetTeamByID(searchByUniqueTeamIDNumber);
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

        public bool RemoveDeveloper(int developerUniqueIDNumber)
        {
            SeeAllDevelopers();
            SeeDeveloperByID();
            System.Console.WriteLine("\nEnter the ID of the Developer you would like to remove: ");
            int findUniqueDeveloperID = Console.ReadLine();
            bool wasDeleted = _developerRepos.RemoveDeveloper(developerUniqueIDNumber);
            if (wasDeleted)
            {
                System.Console.WriteLine("That Developer has been deleted.");
            }
            else
            {
                System.Console.WriteLine("That Developer could not be deleted. Please contact your administrator.");
            }
        }

        public bool RemoveTeam(int teamUniqueIDNumber)
        {
        SeeAllTeams();
        SeeTeamsByID();
        System.Console.WriteLine("\nEnter the ID of the Team you would like to remove: ");
        int findUniqueTeamID = Console.ReadLine();
        bool wasDeleted = _developerTeanRepos.RemoveDeveloperTeam(teamUniqueIDNumber);
        if (wasDeleted)
            {
            System.Console.WriteLine("That Team has been deleted.");
            }
        else
            {
            System.Console.WriteLine("That Team could not be deleted.");
            }
        }
    
        public void UpdateDeveloperAttributes()
        {
        SeeAllDevelopers();
        SeeDevelopersByID();
        System.Console.WriteLine("\nEnter the ID of the Developer whose information you want to change:");
        int findUniqueDeveloperID = Console.ReadLine();
        Developer developer = _developerRepos.GetDeveloperByID(uniqueDeveloperIDNumber);
            if (developer != null)
            {
            System.Console.WriteLine($"First Name: {developer.DeveloperFirstName} {developer.DeveloperLastName} /nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber} /nDo they have a Pluralsight license? {developer.HasPluralsightID}/nAnd if so, when does it expire? {developer.PluralsightExpiryDate}");
            }
        }

        public void UpdateTeamAttributes()
        {
        SeeAllTeams();
        SeeTeamsByID();
        System.Console.WriteLine("\nEnter the ID of the Team which has information you'd like to change:");
        int findUniqueTeamID = _developerTeamRepos.GetTeamByID(teamUniqueIDNumber);
        if (findUniqueTeamID !=- null)
        {
            System.Console.WriteLine($"Team Name: {developerTeam.TeamName} /nTeam Description: {developerTeam.TeamDescription}");
            //[LATER]Check to see if Team name in use?
        }
        }

        public void AddDeveloperToTeam (int developerUniqueIDNumber)
        {   
        SeeAllTeams();
        System.Console.WriteLine("Choose the Team's ID to which you'd like to add Developers:");
        int chosenTeamUniqueID = int.Parse(Console.ReadLine());
        if (chosenTeamUniqueID >100 || chosenTeamUniqueID>1000) 
            {
            DeveloperTeam thisTeamNow = _developerTeamRepos.GetTeamByID(chosenTeamUniqueID);
            System.Console.WriteLine($"Are you ready to add Developers to {thisTeamNow.TeamName}?");
            }
        else 
            {
            System.Console.WriteLine("That Team isn't in this Directory.");
            }
         SeeAllDevelopers();
         System.Console.WriteLine($"Now choose the Developer you want to add to {thisTeamNow.TeamName}:");
         int developerToAdd = int.Parse(ReadLine());
         while (stillChoosing)
         int developerChosenForTeam = Console.ReadLine();
         System.Console.WriteLine($"You'd like to add {developerToAdd} (yes or no)?");
         string confirmAdd = Console.ReadLine().ToLower;
         if (confirmAdd = "yes")
         {
            List<Developer> _developersList = new List<Developer.Add>();
         }
         else
         {
            System.Console.WriteLine($"Again, choose the Developer you\'d like to add to {thisTeamNow.TeamName}:");
         }
        }   
        System.Console.WriteLine($"{developerToAdd} is now a member of {thisTeamnow.TeamName}");
        System.Cponsole.WriteLine($"Would you like to add another Developer to {thisTeamNow.TeamName}?");
        string anotherDeveloperForTeam = Console.ReadLine().ToLower;
            if (anotherDeveloperForTeam = "yes")
            {
            SeeAllDevelopers();
            System.Console.WriteLine($"Now choose the Developer you want to add to {thisTeamNow.TeamName}:");
            int anotherDeveloperToAdd = int.Parse(ReadLine());
            while (stillChoosingAdditionalDeveloper)
            int developerChosenForTeam = Console.ReadLine();
            System.Console.WriteLine($"You'd like to add {developerToAdd} (yes or no)?");
            string confirmAdd = Console.ReadLine().ToLower;
                if (confirmAdd = "yes")
                {
                List<Developer> _developersList = new List<Developer.Add>();
                }
            else
                {
                System.Console.WriteLine($"Again, choose the Developer you\'d like to add to {thisTeamNow.TeamName}:");
                }
         
        stillChosingAdditionalDeveloper=false;
        }
    }
}
    // keepRunning = false


