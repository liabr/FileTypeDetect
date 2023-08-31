using FileSignatures;

namespace FileTypeDetect.models
{
    public class FileWithExtensionCalculated : IFileNameCreator
    {        
        public Dictionary<string, ExcelDataModel> InitializeConfigurationExcel(string fileName)
        {
            return new Dictionary<string, ExcelDataModel>();
        }

        public void CreateNewDirectoryWithExtension(string filePath, string extensionForFileType, string newDirectoryPath)
        {
            if(!Directory.Exists(newDirectoryPath)){
                Directory.CreateDirectory(newDirectoryPath);
            }
            try{
                var destinationFileName = newDirectoryPath + 
                                                Path.GetFileNameWithoutExtension(filePath) + 
                                                  "." + extensionForFileType;
                File.Copy(filePath, destinationFileName, true);
            }
            catch (Exception m) { Console.WriteLine(m.Message); }        
        }

        public void GetFileType(string filePath, string newDirectoryPath, string configFileLocation)
        {
            var inspector = new FileFormatInspector();
            FileFormat? format;
            using(var stream = File.Open(filePath, FileMode.Open, FileAccess.Read)){
                 format = inspector.DetermineFileFormat(stream); 
            }
            if(format?.Extension is not null){
                CreateNewDirectoryWithExtension(filePath, format.Extension,
                                            newDirectoryPath);
            } 
        }
    }
}