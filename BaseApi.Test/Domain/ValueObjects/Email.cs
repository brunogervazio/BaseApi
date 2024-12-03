using BaseApi.Domain.Exceptions;
using BaseApi.Domain.ValueObjcts;

namespace BaseApi.Test.Domain.ValueObjects
{
    public class EmailTest
    {
        private const string invalidEmail = "teste.com.br";
        private const string validEmail = "teste@gmail.com";

        [Test]
        public void Email_Invalid() =>
            Assert.Throws<EmailValidateException>(() => new Email(invalidEmail));


        [Test]
        public void Email_Valid() => _ = new Email(validEmail);
    }
}
