namespace VariaveisDeAmbiente
{
    public class Env
    {
        public string Key { get; }
        public string Issuer { get; }
        public string Audience { get; }
        public string ExpirationInMinutes { get; }

        public Env()
        {
            this.Key = "ChaveSuperSecreta123";
            this.Issuer = "FERNANDO";
            this.Audience = "AplicacaoWebAPI";
            this.ExpirationInMinutes = "30";
        }
    }
}
