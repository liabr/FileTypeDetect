using FileSignatures;
using FileSignatures.Formats;

namespace FileTypeDetect.models
{
    public class FileWithExtensionCalculated : IFileNameCreator
    {        
        public Dictionary<string, ExcelDataModel> InitializeConfigurationExcel(string fileName)
        {
            return new Dictionary<string, ExcelDataModel>();
        }

        public void CreateNewDirectoryWithExtension(ExcelDataModel excelDataModel, string fileName,  string newDirectoryPath)
        {
            if(!Directory.Exists(newDirectoryPath)){
                Directory.CreateDirectory(newDirectoryPath);
            }
            try{
                var destinationFileName = newDirectoryPath + 
                                                Path.DirectorySeparatorChar +
                                                fileName + 
                                                Path.PathSeparator +
                                                excelDataModel.FileExtension;
                File.Copy(excelDataModel.FolderName, destinationFileName, true);
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
                ExcelDataModel excelDataModel = new()
                {
                    FileExtension = format.Extension,
                    Title = filePath,
                    FolderName = filePath
                };
                CreateNewDirectoryWithExtension(excelDataModel, filePath, newDirectoryPath);
            } 
        }
    }
}