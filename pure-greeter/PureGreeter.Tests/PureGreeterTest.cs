using System;
using NUnit.Framework;

namespace PureGreeter.Tests
{
    [TestFixture]
    public class PureGreeterTest
    {
        private PureGreeter _pureGreeter;

        [SetUp]
        public void Init()
        {
            _pureGreeter = new PureGreeter();
        }
        
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(11)]
        public void Greet_during_the_morning(int currentHour)
        {
            var greeting = _pureGreeter.Greet(currentHour, "Pepe");

            Assert.That(greeting, Is.EqualTo("¡Buenos días Pepe!"));
        }

        [TestCase(15)]
        [TestCase(19)]
        [TestCase(12)]
        public void Greet_during_the_afternoon(int currentHour)
        {
            var greeting = _pureGreeter.Greet(currentHour, "Pepe");

            Assert.That(greeting, Is.EqualTo("¡Buenas tardes Pepe!"));
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(23)]
        public void Greet_during_the_night(int currentHour)
        {
            var greeting = _pureGreeter.Greet(currentHour, "Pepe");

            Assert.That(greeting, Is.EqualTo("¡Buenas noches Pepe!"));
        }

        [TestCase(24)]
        [TestCase(-1)]
        public void Greeting_hours_should_be_between_0_and_23(int currentHour)
        {
            Assert.Throws<HourOutOfRangeException>(() => _pureGreeter.Greet(currentHour, "Pepe"));
        }
    }
}