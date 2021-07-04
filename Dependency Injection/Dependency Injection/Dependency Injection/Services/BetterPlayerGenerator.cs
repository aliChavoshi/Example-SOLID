using System;
using Dependency_Injection.Models;

namespace Dependency_Injection.Services
{
    public class BetterPlayerGenerator : IPlayerGenerator
    {
        public Player CreateNewPlayer()
        {
            throw new NotImplementedException();
        }
    }
}