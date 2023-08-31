using Ganss.Excel;

namespace FileTypeDetect.models
{
    public class FileWithExtensionFromExcel : IFileNameCreator
    {
        public Dictionary<string, ExcelDataModel> InitializeConfigurationExcel(string fileName){
            var excelData = new ExcelMapper(fileName).Fetch<ExcelDataModel>(0); 
            return excelData.ToDictionary(x => x.ContentDocumentId);
        }
        public void CreateNewDirectoryWithExtension(ExcelDataModel excelDataModel, string fileName, string newDirectoryPath)
        {
            var entireDirectoryPath = newDirectoryPath + Path.DirectorySeparatorChar + excelDataModel.FolderName;
            if(!Directory.Exists(entireDirectoryPath)){
                Directory.CreateDirectory(entireDirectoryPath);
            }
            try{
                File.Copy(fileName, entireDirectoryPath
                                                                    + Path.DirectorySeparatorChar
                                                                    + excelDataModel.Title
                                                                    + "."
                                                                    + excelDataModel.FileExtension, true);
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
                        CreateNewDirectoryWithExtension(excelDataFileName, a,  newDirectoryPath);
                    }
                }
            }
        }
    }
}