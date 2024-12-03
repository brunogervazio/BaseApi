using BaseApi.Domain.Exceptions;
using BaseApi.Domain.ValueObjcts;

namespace BaseApi.Test.Domain.ValueObjects
{
    [TestFixture]
    public class PasswordTest
    {
        private const string invalidEnoughCharacters = "123456";
        private const string invalidCaseCharacters = "123456789";
        private const string invalidEspecialCharacters = "BrunoTeste";
        private const string invalidNumber = "BrunoTeste@";
        private const string validPassword = "BrunoTeste@123";

        [Test]
        public void Password_not_contains_enough_characters()
        {
            var result = Assert.Throws<PasswordValidationException>(() =>
               new Password(invalidEnoughCharacters, string.Empty));

            Assert.That(result.Message, Is.EqualTo("Password must contain at least 9 characters."));
        }

        [Test]
        public void Password_not_contains_uppercase_lowercase()
        {
            var result = Assert.Throws<PasswordValidationException>(() =>
              new Password(invalidCaseCharacters, string.Empty));

            Assert.That(result.Message, Is.EqualTo("Password must contain uppercase and lowercase characters."));
        }

        [Test]
        public void Password_not_contains_special_characters()
        {
            var result = Assert.Throws<PasswordValidationException>(() =>
              new Password(invalidEspecialCharacters, string.Empty));

            Assert.That(result.Message, Is.EqualTo("Password must contain special character."));
        }

        [Test]
        public void Password_not_contains_number()
        {
            var result = Assert.Throws<PasswordValidationException>(() =>
                 new Password(invalidNumber, string.Empty));

            Assert.That(result.Message, Is.EqualTo("Password must contain number."));
        }

        [Test]
        public void Password_is_ok() => _ = new Password(validPassword, string.Empty);
    }
}
