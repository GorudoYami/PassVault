using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassVault {
    public class Crypto {
        private const int saltSize = 64; // in bits
        private const int keySize = 256; // in bits
        public Crypto(string password) {

        }

        public string Encrypt(string data) {
            throw new NotImplementedException();
        }

        public string Decrypt(string data) {
            throw new NotImplementedException();
        }
    }
}
