// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace semestertest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileSystem myFileSystem = new FileSystem();

            Folder myFolder1 = new Folder("Save files");
            myFolder1.Add(new File("Save 1 - The Citadel", "data", 2348));
            myFolder1.Add(new File("Save 2 - Artemis Tau", "data", 6378));
            myFolder1.Add(new File("Save 3 - Serpent Nebula", "data", 973));
            myFileSystem.Add(myFolder1);

            Folder myFolder2 = new Folder("New folder");
            myFileSystem.Add(myFolder2);

            myFileSystem.Add(new File("AnImage", "jpg", 5342));
            myFileSystem.Add(new File("SomeFile", "txt", 832));

            myFileSystem.PrintContents();

            Console.ReadLine();
        }
    }
}