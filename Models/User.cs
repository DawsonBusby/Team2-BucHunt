namespace ETSUBucHunt.WebApp.Models
{
    public class User
    {
        //The User's email and phone numbers will be stored in these strings.
        public String UserEmailAddress { get; set; }
        public String UserPhoneNumber { get; set; }

        //default constructor with default values
        public User()
        {
            UserEmailAddress = "default ";
            UserPhoneNumber = "default";
        }


        //Normal constructor that the web page can call to pass through data that will be stored as new user.
        public User(String inputEmailAddress, String inputPhoneNumber)
        {
            UserEmailAddress = inputEmailAddress;
            UserPhoneNumber = inputPhoneNumber;
        }

        //Testing the new class object.
        /*
             static void Main(string[] args)
            {
                User A = new User("test@test.edu", "123-456-7890");
                Console.WriteLine(A.UserEmailAddress + " " + A.UserPhoneNumber);

            }
        */
    }
}
