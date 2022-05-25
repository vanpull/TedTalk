namespace TedTalk.Domain
{
    public interface ICsvPathResolver
    {
        string GetCsvPath(string fileKey);
    }
}
