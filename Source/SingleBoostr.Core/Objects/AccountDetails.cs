using SingleBoostr.Core.Misc;

namespace SingleBoostr.Core.Objects
{
    public class AccountDetails
    {
        /// <summary>
        /// Username of steam account
        /// </summary>
        public string Username { get; set; } = "";
         
        /// <summary>
        /// Password of the steam account
        /// This will be set manually by user from console
        /// This will not be printed or read from json file
        /// </summary>
        public string Password { get; set; } = "";
        private bool PasswordSet = false;//=> !string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password);
        private string PasswordSalt = "";//= StringCipher.EncryptSHA1(Utils.GetMachineGuid());
        public void Encrypt() { }//=> Password = PasswordSet ? StringCipher.Encrypt(Password, PasswordSalt) : Password;
        public void Decrypt() { }//=> Password = PasswordSet ? StringCipher.Decrypt(Password, PasswordSalt) : Password;

        /// <summary>
        /// Login key for steam account
        /// Saving this means we don't have to enter code twice
        /// </summary>
        public string LoginKey { get; set; } = "";
    }
}
