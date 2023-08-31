using Ganss.Excel;

namespace FileTypeDetect.models
{
    public class ExcelDataModel
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Latest Published Version ID")]
        public string ContentDocumentId { get; set; }

        [Column("Created By ID")]
        public string CreatedById { get; set; }

        [Column("File Extension")]       
        public string FileExtension{get; set; }

        [Column("Parent Record Name")]       
        public string FolderName{get; set; }
    }
}