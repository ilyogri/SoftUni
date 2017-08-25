namespace _04.Files
{
    public class File
    {
        public File(string root, string fileNameAndExt, long fileSize)
        {
            this.Root = root;
            this.FileNameAndExtension = fileNameAndExt;
            this.FileSize = fileSize;
        }

        public string Root { get; set; }
        public string FileNameAndExtension { get; set; }
        public long FileSize { get; set; }
    }
}