namespace MangaLibrary.UI.ApiModels
{
    public class Error
    {
        public string Property { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
