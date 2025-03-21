namespace StudentRegistry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? menuSelection = "-1";

            StudentHandler studentHandler = new();

            while (menuSelection != "0")
            {
                MenuMate.ShowMenu();

                menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        studentHandler.AddStudent();
                        break;

                    case "2":
                        studentHandler.UpdateStudent();
                        break;

                    case "3":
                        studentHandler.ShowStudents();
                        break;

                    case "0":
                        menuSelection = "0";
                        break;

                    default:
                        InputValidator.PrintErrorInvalidInput();
                        break;
                }
            }
        }
    }
}
