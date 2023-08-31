namespace FileTypeDetect.models
{
    public interface IFileNameCreator
    {
        Dictionary<string, ExcelDataModel> InitializeConfigurationExcel(string fileName);
        void GetFileType(string filePath, string newDirectoryPath, string configFileLocation);
        void CreateNewDirectoryWithExtension(ExcelDataModel excelDataModel, string fileName,  string newDirectoryPath);
    }
}