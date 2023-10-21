namespace ÄPI.Helpers
{
    public class IdentityAccountGenerator_Helper //In charge of creating both the CBU and UUID as appropiate.
    {
        private string EstablishRandomNumbers(int length = 1) //For every single character, establish a random number. Used for CBU generation.
        {
            Random random = new Random();
            const string characters = "0123456789";

            string result = new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }


        public string GenerateCBU() //CBU structure => WWWW-X-YYYY-ZZZZZZZZZZZZZ
        {
            string firstPart = EstablishRandomNumbers(4); //First part => WWWW
            string secondPart = EstablishRandomNumbers(); //Second part => X
            string thirdPart = EstablishRandomNumbers(4); //Third part => YYYY
            string fourthPart = EstablishRandomNumbers(13); //Fourth part => ZZZZZZZZZZZZZ

            string cbu = $"{firstPart}-{secondPart}-{thirdPart}-{fourthPart}";

            return cbu;
        }

        //---------------------------------------------------------------------------------------------

        private string EstablishRandomValues(int length) //For every single character, establish a random number/letter. Used for UUID generation.
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string result = new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }


        public string GenerateUUID() //UUID structure => VVVVVVVV-WWWW-XXXX-YYYY-ZZZZZZZZZZZZ
        {
            string firstPart = EstablishRandomValues(8); //First part => VVVVVVVV
            string secondPart = EstablishRandomValues(4); //Second part => WWWW
            string thirdPart = EstablishRandomValues(4); //Third part => XXXX
            string fourthPart = EstablishRandomValues(4); //Fourth part => YYYY
            string fifthPart = EstablishRandomValues(12); //Fourth part => ZZZZZZZZZZZZ

            string uuid = $"{firstPart}-{secondPart}-{thirdPart}-{fourthPart}-{fifthPart}";

            return uuid;
        }
    }
}
