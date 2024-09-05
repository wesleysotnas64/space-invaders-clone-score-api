namespace space_invaders_clone_score_api.TRA
{
    public class PlayerTRA
    {
        private readonly List<string> keys = new List<string>()
        {
            "aB1!cD2@eF3#gH4&",
            "xY5@zW6#vU7!tS8*",
            "M9*N0#kL1@jI2!oH_",
            "P3*Q4!rS5#T6@uV7-",
            "W8#X9!yZ0@aB1&cD2"
        };
        public bool VerifyKey(string key)
        {
            return keys.Contains(key);

        }

        public bool VerifyScore(int score)
        {
            return true;
        }
    }
}
