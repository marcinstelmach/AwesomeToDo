namespace AwesomeToDo.Infrastructure.Managers.Abstract
{
    public interface IEncryptionManager
    {
        string GetSalt(string password);
        string GetHash(string password, string salt);
    }
}
