using GameModels.PlayerEssence;
using NUnit.Framework;

namespace Tests.Edit.PlayerTests
{
    public class Tests
    {
        [Test]
        public void Health_GetDamage100_Equals0()
        {
            var player = new Player();
            
            Assert.AreEqual(player.Health, 100);
            
            player.GetDamage(100);
            
            
            Assert.AreEqual(player.Health, 0);
        }
    }
}