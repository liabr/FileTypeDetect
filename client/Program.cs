using FileTypeDetect.models;

namespace FileTypeDetect.client
{
    class Program
    {
        static void Main(string[] args)
        {
            string? directoryName, newDirectoryPath, configFileLocation;

            Console.WriteLine("Enter directory path");
            directoryName = Console.ReadLine();

            Console.WriteLine("New  directory path should be terminated by \\");
            newDirectoryPath = Console.ReadLine();

            Console.WriteLine("Provide the full name of the configuration file with directory");
            configFileLocation = Console.ReadLine();

            var fileNameCreator = new FileWithExtensionFromExcel();
            if(directoryName is not null && newDirectoryPath is not null){
                fileNameCreator.GetFileType(directoryName, newDirectoryPath: newDirectoryPath, configFileLocation);
            }     

            Console.WriteLine("File Detect Operation successsfully completed. Press any key to exit");
            Console.ReadKey();      
        }
    }
}