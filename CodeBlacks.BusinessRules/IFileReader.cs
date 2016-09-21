namespace CodeBlacks.BusinessRules
{
    public interface IFileReader
    {
        string ReadAllText(string path);

        bool Exists(string path);
    }
}
