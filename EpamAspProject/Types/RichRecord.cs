using System;

namespace EpamAspProject.Types
{
    public class RichRecord
    {
        public int IDRecord { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int UploadBy { get; set; }
        public DateTime UploadDate { get; set; }
        public string Type { get; set; }
        public string FileWay { get; set; }
        public string Format { get; set; }
    }
}