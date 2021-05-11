using Bowling;
using NUnit.Framework;

namespace BowlingTests
{
    public class Tests
    {
        private BowlingGame _game;

        [SetUp]
        public void Setup()
        {
            _game = new BowlingGame();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }

        }

        [Test]
        public void testGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.Score());
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void TestOneSpare()
        {           
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _game.Score());

        }
        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
        Assert.AreEqual(24, _game.Score());
        }

        public void TestPerfectGame()
        {
            RollMany(12,10);
            Assert.AreEqual(300, _game.Score());
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }


}
}