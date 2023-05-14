using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseHR.Tests
{
    [TestClass]
    public class EncryptStringTests
    {
        [TestMethod]
        public void encrypt_same_key_test()
        {
            //arrange
            string passwordTest = "qwerty1234";

            //act
            string encryptedPassword1 = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", passwordTest);
            string encryptedPassword2 = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", passwordTest);

            //assert
            Assert.AreEqual(encryptedPassword1, encryptedPassword2);
        }

        [TestMethod]
        public void encrypt_different_key_test()
        {
            //arrange
            string passwordTest = "qwerty1234";

            //act
            string encryptedPassword1 = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", passwordTest);
            string encryptedPassword2 = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("vbhf234jfbdn2343234jkfnjfkfm2787", passwordTest);

            //assert
            Assert.AreNotEqual(encryptedPassword1, encryptedPassword2);
        }

        [TestMethod]
        public void decrypt_same_key_test()
        {
            //arrange 
            string passwordTest = "qwerty1234";
            string encryptedPassword = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", passwordTest);

            //act
            string decryptedPassword = EncryptionDecryptionUsingSymmetricKey.AesOperation.DecryptString("b14ca5898a4e4133bbce2ea2315a1916", encryptedPassword);

            //assert
            Assert.AreEqual(passwordTest, decryptedPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Security.Cryptography.CryptographicException))]
        public void decrypt_different_key_test()
        {
            //arrange 
            string passwordTest = "qwerty1234";
            string encryptedPassword = EncryptionDecryptionUsingSymmetricKey.AesOperation.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", passwordTest);

            //act
            string decryptedPassword = EncryptionDecryptionUsingSymmetricKey.AesOperation.DecryptString("vbhf234jfbdn2343234jkfnjfkfm2787", encryptedPassword);

            //assert - Expects exception
        }
    }

}
