using System;
using System.Collections.Generic;
using System.Linq;
using CactusPie.MapLocation.Common.Requests.Data;
using Comfort.Common;
using EFT;
using StayInTarkov;
using StayInTarkov.Coop;

namespace CactusPie.MapLocation.Services.Bots
{
    public sealed class BotDataService : IBotDataService
    {
        private readonly Dictionary<int, BotOwner> _spawnedBots = new Dictionary<int, BotOwner>(35);

        private BotSpawner _botSpawnerClass;

        private IEnumerable<Player> _playersList;
        private bool _isCoopGame;

        private bool _isInitialized = false;

        public IReadOnlyDictionary<int, BotOwner> SpawnedBots => _spawnedBots;
        public IEnumerable<Player> PlayersList => _playersList;
        public bool IsCoopGame => _isCoopGame;

        public BotType GetBotType(BotOwner bot)
        {
            ProfileInfo info = bot.Profile.Info;

            if (info.Side == EPlayerSide.Usec)
            {
                return BotType.Usec;
            }

            if (info.Side == EPlayerSide.Bear)
            {
                return BotType.Bear;
            }

            if (info.Settings.IsBossOrFollower())
            {
                return BotType.Boss;
            }

            if (info.Side == EPlayerSide.Savage)
            {
                return BotType.Scav;
            }

            return BotType.Other;
        }
        
        public BotType GetBotType(Player bot)
        {
            ProfileInfo info = bot.Profile.Info;

            if (info.Side == EPlayerSide.Usec)
            {
                return BotType.Usec;
            }

            if (info.Side == EPlayerSide.Bear)
            {
                return BotType.Bear;
            }

            if (info.Settings.IsBossOrFollower())
            {
                return BotType.Boss;
            }

            if (info.Side == EPlayerSide.Savage)
            {
                return BotType.Scav;
            }

            return BotType.Other;
        }

        public void InitializeBotDataForCurrentGame()
        {
            if (_isInitialized)
            {
                throw new InvalidOperationException(
                    $"The service cannot be initialized twice. Run {nameof(UnloadBotDataForCurrentGame)} first.");
            }
            
            if (CoopGameComponent.GetCoopGameComponent() != null)
            {
                _spawnedBots.Clear();
                _isCoopGame = true;
            }
            else
            {
                if (Singleton<IBotGame>.Instantiated)
                {
                    _botSpawnerClass = Singleton<IBotGame>.Instance.BotsController.BotSpawner;

                    _botSpawnerClass.OnBotCreated += OnBotCreated;
                    _botSpawnerClass.OnBotRemoved += OnBotRemoved;
                    _isInitialized = true;
                }
                _isCoopGame = false;
            }
        }

        public void UnloadBotDataForCurrentGame()
        {
            if (_botSpawnerClass != null)
            {
                _botSpawnerClass.OnBotCreated -= OnBotCreated;
                _botSpawnerClass.OnBotRemoved -= OnBotRemoved;
                _botSpawnerClass = null;
                _spawnedBots.Clear();
            }
            _isInitialized = false;
        }

        public void Dispose()
        {
            if (_botSpawnerClass != null)
            {
                _botSpawnerClass.OnBotCreated -= OnBotCreated;
                _botSpawnerClass.OnBotRemoved -= OnBotRemoved;
                _botSpawnerClass = null;
            }
        }

        private void OnBotRemoved(BotOwner botOwner)
        {
            _spawnedBots.Remove(botOwner.Id);
        }

        private void OnBotCreated(BotOwner botOwner)
        {
            _spawnedBots.Add(botOwner.Id, botOwner);
        }

        ~BotDataService()
        {
            Dispose();
        }
    }
}