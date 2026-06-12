using NUnit.Framework;

// [(s:10, q:10)] => [(s:9, q:8)]
// [(s:1, q:2)] => [(s:0, q:0)]
// [(s:0, q:10)] => [(s:-1, q:6)]
// [(s:0, q:4)] => [(s:-1, q:0)]
// [(s:3, q:0)] => [(s:2, q:0)]
// [(s:1, q:1)] => [(s:0, q:0)]
// [(s:0, q:3)] => [(s:-1, q:0)]
    
namespace ArgentRose.Tests
{
    public class ArgentRoseTest
    {
        [Test]
        public void Think_A_Good_Name_And_Change_It()
        {
            Assert.That(false, Is.True);
        }
    }
}
