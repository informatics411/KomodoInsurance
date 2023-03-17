using DeveloperRepository;
using DeveloperTeamRepository;
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

            System.Console.WriteLine("Developer Directory Options:\n" +
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
                    AddDeveloperInfo();
                    break;
                case "2": //View all Developers
                    SeeAllDevelopers();
                    break;
                case "3": //View Developer by ID
                    // FindDeveloperByID();
                    break;
                case "4": //View Developer by Has Pluralsight
                    // DeveloperByPluralsightExpiry();
                    break;
                case "5": //Update existing Developer
                    // UpdateExistingDeveloper();
                    break;
                case "6": //Delete existing Developer
                    // RemoveExistingDevloper();
                    break;
                case "7":
                    // LookAtTeamsList();
                    break;
                case "8":
                    // AddNewTeam();
                    break;
                case "9":
                    // ChangeTeamAttributes();
                    break;
                case "10":
                    // DeleteTeam();
                    break;
                // Exit
                case "11":
                    System.Console.WriteLine("Goodbye");
                    keepRunning = false;
                    break;

                default:
                    System.Console.WriteLine("Please enter a valid number");
                    break;
            }
        }

        private void AddDeveloperInfo()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();
            //Last name
            System.Console.WriteLine("What's the new Developer's last name:");
            newDeveloper.DeveloperLastName = Console.ReadLine();
            //First name
            System.Console.WriteLine("What's the new Developer's last name:");
            newDeveloper.DeveloperFirstName = Console.ReadLine();
            //UniqueID
            System.Console.WriteLine("This will be their unique ID at Komono Insurance: ");
            Random r = new Random(); //sets up random #
            int rInt = r.next(32333,99999);
            newDeveloper.DeveloperUniqueIDNumber = rInt; //assigns rnd to Developer
            //[LATER] checks uniqueness of ID number? 
            //Do they have Pluralsight (part 1)?
            System.Console.WriteLine("Do they have a Pluralsight License? (y/n)");
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

        private void SeeAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetContentList();
            foreach (Developer developer in listOfDevelopers)
            {
                System.Console.WriteLine($"Developer name:{developer.DeveloperLastName} {developer.DeveloperLastName}\nDeveloperUniqueID:{developer.DeveloperUniqueIDNumber}\nThey have Pluralsight? {developer.HasPluralsightID}");
                }
        }

        private void SeeDeveloperbyID()
        {
            Console.Clear();
            SeeDeveloperList();
            System.Console.WriteLine("To learn more about a Developer, enter their ID number:");
            input uniqueDeveloperID = Console.ReadLine();
            Developer developer = _developerRepo.GetDeveloperByID(uniqueDeveloperIDNumber);
            if (developer != null)
            {
            System.Console.WriteLine($"First Name: {developer.DeveloperFirstName}");
            }
        }
    }

    // private void DeveloperByPluralsightExpiry()
    // {
    // }

    public bool RemoveDeveloper(int developerUniqueIDNumber)
    {
        SeeAllDevelopers();
        SeeDeveloperByID();
        _developerRepos.RemoveDeveloper();
    }

    // public bool RemoveTeam(int teamUniqueIDNumber)
    // {
    // }
    

    // _developerTeamRepos.RemoveTeam()
    // {
    // }
    
}

// Helper methods
private DeveloperRepository SeeDeveloperByID(int developerUniqueIDNumber)
{
    foreach(DeveloperRepository developer in _developerRepos)
    {
        if (developer.DevoloperUniqueIDNumber == developerUniqueIDNumber)
        {
        return developer;
        }
    }   return null;
}