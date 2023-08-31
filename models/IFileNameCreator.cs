namespace FileTypeDetect.models
{
    public interface IFileNameCreator
    {
        Dictionary<string, ExcelDataModel> InitializeConfigurationExcel(string fileName);
        void GetFileType(string filePath, string newDirectoryPath, string configFileLocation);
        void CreateNewDirectoryWithExtension(string filePath, string newFileNameWithExtension, string newDirectoryPath);
    }
}