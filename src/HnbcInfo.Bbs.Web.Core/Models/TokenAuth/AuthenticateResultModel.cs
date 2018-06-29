namespace HnbcInfo.Bbs.Models.TokenAuth
{
    public class AuthenticateResultModel
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Renzheng { get; set; }

        public int Vip { get; set; }


    }
}
