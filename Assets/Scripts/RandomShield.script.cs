using TheAdventure.Scripting;
using System;
using TheAdventure;

namespace TheAdventure.Assets.Scripts;

public class RandomShield : IScript
{
    DateTimeOffset _nextShieldTimestamp;

    public void Initialize()
    {
        _nextShieldTimestamp = DateTimeOffset.UtcNow.AddSeconds(Random.Shared.Next(2, 5));
    }

    public void Execute(Engine engine)
    {
        if (_nextShieldTimestamp < DateTimeOffset.UtcNow)
        {
            _nextShieldTimestamp = DateTimeOffset.UtcNow.AddSeconds(Random.Shared.Next(2, 5));
            var playerPos = engine.GetPlayerPosition();
            var shieldPosX = playerPos.X + Random.Shared.Next(-100, 100);
            var shieldPosY = playerPos.Y + Random.Shared.Next(-100, 100);
            engine.AddShield(shieldPosX, shieldPosY);
        }
    }
}