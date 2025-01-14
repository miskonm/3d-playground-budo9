using System;
using Playground.Services.Save;

namespace Playground.Models
{
    [Serializable]
    public class GameData : SaveData
    {
        public int score;
    }
}