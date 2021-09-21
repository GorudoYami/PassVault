using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassVault {
    public class Crypto {
        private Aes aes;
        public Crypto(string password) {
            aes = Aes.Create();
        }

        public string Encrypt(string data) {
            throw new NotImplementedException();
        }

        public string Decrypt(string data) {
            throw new NotImplementedException();
        }
    }
}
