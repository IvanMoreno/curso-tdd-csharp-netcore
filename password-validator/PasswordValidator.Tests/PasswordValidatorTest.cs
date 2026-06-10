using System;
using NUnit.Framework;

// Observable behavior: Contraseña es validada
// Input: Contraseña
// Output: Valido o no (bool)

// Smaller behaviors:
// Obligatoriamente:
    // Have more than 8 characters (8, inf)
    // Una mayúscula como mínimo
    // Una minúscula como mínimo
    // Un número como mínimo
    // Una barra baja como mínimo

// Ejemplos
// [x] (1Aa_5678) = No válido
// [x] (1Aa_56789) = Válida
// [x] (1Aaa56789) = No válido
// [] (1A__56789) = No válido
// [] (1aa_56789) = No válido
// [x] (aAa_aaaaa) = No válido

namespace PasswordValidator.Tests
{
    public class PasswordValidatorTest
    {
        [Test]
        public void LessThan9Characters_IsNotValid()
        {
            Assert.That(new PasswordValidator().IsValid("1Aa_5678"), Is.False);
        }

        [TestCase("1Aa_56789")]
        [TestCase("1Aa_567890")]
        public void MoreThan8Characters_IsValid(string password)
        {
            Assert.That(new PasswordValidator().IsValid(password), Is.True);
        }

        [Test]
        public void WithoutUnderscore_IsNotValid()
        {
            Assert.That(new PasswordValidator().IsValid("1Aaa56789"), Is.False);
        }
        
        [Test]
        public void WithoutNumbers_IsNotValid()
        {
            Assert.That(new PasswordValidator().IsValid("aAa_aaaaa"), Is.False);
        }
    }
}