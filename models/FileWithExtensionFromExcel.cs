using Ganss.Excel;

namespace FileTypeDetect.models
{
    public class FileWithExtensionFromExcel : IFileNameCreator
    {
        public Dictionary<string, ExcelDataModel> InitializeConfigurationExcel(string fileName){
            var excelData = new ExcelMapper(fileName).Fetch<ExcelDataModel>(0); 
            return excelData.ToDictionary(x => x.ContentDocumentId);
        }
        public void CreateNewDirectoryWithExtension(string filePath, string newFileNameWithExtension, string newDirectoryPath)
        {
             if(!Directory.Exists(newDirectoryPath)){
                Directory.CreateDirectory(newDirectoryPath);
            }
            try{
                File.Copy(filePath, newDirectoryPath + Path.DirectorySeparatorChar + newFileNameWithExtension, true);
            }
            catch (Exception m) { Console.WriteLine(m.Message); } 
        }

        public void GetFileType(string filePath, string newDirectoryPath, string configFileLocation)
        {
            var config = InitializeConfigurationExcel(configFileLocation);
            if(Directory.Exists(filePath)){
                var f = Directory.GetFiles(filePath, "");

                foreach( var a in f){
                    config.TryGetValue(Path.GetFileNameWithoutExtension(a), out var excelDataFileName);
                    if(excelDataFileName is not null){
                        CreateNewDirectoryWithExtension(a, excelDataFileName.Title + "." + excelDataFileName.FileExtension,  newDirectoryPath);
                    }
                }
            }
        }
    }
}