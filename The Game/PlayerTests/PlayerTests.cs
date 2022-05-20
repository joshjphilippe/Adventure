using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using The_Game.models.player;

namespace PlayerTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Gold_IncreaseValidAmount_UpdatesAmount()
        {
            // Arrange
            int currentGold = 10;
            int addAmount = 12;
            int expectedAmt = 22;
            Player player = new Player("Name", 10, 10, 10, currentGold);

            // Act
            player.IncreaseGold(addAmount);

            // Assert
            int actual = player.Gold;
            Assert.AreEqual(expectedAmt, actual, 0.001, "Added Gold does not equal expected");
        }

        [TestMethod]
        public void Gold_DecreaseValidAmount_UpdatesAmount()
        {
            // Arrange
            int currentGold = 20;
            int removeAmount = 12;
            int expectedAmount = 8;
            Player player = new Player("Name", 10, 10, 10, currentGold);

            // Act
            player.RemoveGold(removeAmount);

            // Assert
            int actual = player.Gold;
            Assert.AreEqual(expectedAmount, actual, 0.001, "Removed Gold does not equal expected");
        }

        [TestMethod]
        public void Gold_DecreaseToNegativeAmount_UpdatesAmount()
        {
            // Arrange
            int currentGold = 0;
            int removeAmount = 12;
            int expectedAmount = 0;
            Player player = new Player("Name", 10, 10, 10, currentGold);

            // Act
            player.RemoveGold(removeAmount);

            // Assert
            int actual = player.Gold;
            Assert.AreEqual(expectedAmount, actual, 0.001, "I'm crying and idk why debug me");
        }

        [TestMethod]
        public void Atk_LevelUp_UpdatesAmount()
        {
            // Arrange
            int currentAtk = 10;
            int expectedAmount = 11;
            Player player = new Player("Name", 10, 10, currentAtk, 10);

            // Act
            player.LevelAtk(1);

            // Assert
            int actual = player.Atk;
            Assert.AreEqual(expectedAmount, actual, 0.001, "Attack has failed to level up");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Atk_LevelUpNegative_ThrowsException()
        {
            // Arrange
            int currentAtk = 10;
            Player player = new Player("Name", 10, 10, currentAtk, 10);

            // Act
            player.LevelAtk(-1);

            // Nothing to assert sicne we're checking for the expectedexception up above
        }

        [TestMethod]
        public void HP_RestoringHp_UpdatesAmount()
        {
            // Arrange
            int hp = 2;
            int vitality = 10;
            int expectedAmount = vitality;
            Player player = new Player("Name", vitality, hp, 10, 10);

            // Act
            player.RestoreHp(8);

            // Assert
            int actual = player.Hp;
            Assert.AreEqual(expectedAmount, actual, 0.001, "HP Failed to restore");
        }

        [TestMethod]
        public void HP_OverhealHp_EqualizesToVitality()
        {
            // Arrange
            int hp = 2;
            int vitality = 10;
            int expectedAmount = vitality;
            Player player = new Player("Name", vitality, hp, 10, 10);

            // Act
            player.RestoreHp(9);

            // Assert
            int actual = player.Hp;
            Assert.AreEqual(expectedAmount, actual, 0.001, "HP Failed to restore");
        }

        [TestMethod]
        public void HP_DiminshHp_UpdatesAmount()
        {
            // Arrange
            int hp = 2;
            int expectedAmount = 0;
            Player player = new Player("Name", 10, hp, 10, 10);

            // Act
            player.DiminishHp(2);

            // Assert
            int actual = player.Hp;
            Assert.AreEqual(expectedAmount, actual, 0.001, "HP Failed to Dimish");
        }

        [TestMethod]
        public void HP_DiminshHpToNegative_UpdatesAmount()
        {
            // Arrange
            int hp = 2;
            int expectedAmount = 0;
            Player player = new Player("Name", 10, hp, 10, 10);

            // Act
            player.DiminishHp(5);

            // Assert
            int actual = player.Hp;
            Assert.AreEqual(expectedAmount, actual, 0.001, "HP Failed to equalize to 0 from negative");
        }

        [TestMethod]
        public void Vitality_IncreaseVitality_UpdatesAmount()
        {
            // Arrange
            int vitality = 10;
            int expectedAmount = 16;
            Player player = new Player("Name", vitality, 10, 10, 10);

            // Act
            player.IncreaseVitality(6);

            // Assert
            int actual = player.Vitality;
            Assert.AreEqual(expectedAmount, actual, 0.001, "Vitality Failed to increase properly");
        }


    }
}
