using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependency_Injection.Services;
using Microsoft.Extensions.Logging;

namespace Dependency_Injection.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IPlayerGenerator _playerGenerator;
        public GameController(ILogger<GameController> logger, IPlayerGenerator playerGenerator)
        {
            _logger = logger;
            _playerGenerator = playerGenerator;
        }

        public IActionResult Index()
        {
            var newPlayers = _playerGenerator.CreateNewPlayer();

            return View(newPlayers);
        }
    }
}
