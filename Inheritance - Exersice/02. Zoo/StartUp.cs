namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Gorilla gorilla = new Gorilla("Marto");
            System.Console.WriteLine(gorilla.Name);
        }
    }
}