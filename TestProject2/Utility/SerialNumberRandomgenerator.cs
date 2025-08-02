namespace AssignementPlaywright.Utility
{
    internal class SerialNumberRandomgenerator
    {
        public static string GeneratSerialNumber()
        {
            Random rnd = new Random();
           return rnd.Next(1, 10000000).ToString();
        }
    }
}
