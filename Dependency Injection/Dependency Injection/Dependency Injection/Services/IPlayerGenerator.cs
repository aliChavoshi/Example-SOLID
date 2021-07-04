using Dependency_Injection.Models;

namespace Dependency_Injection.Services
{
    public interface IPlayerGenerator
    {
        Player CreateNewPlayer();
    }
}