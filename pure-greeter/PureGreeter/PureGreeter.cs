namespace PureGreeter
{
    public class PureGreeter
    {
        public string Greet(int currentHour, string name)
        {
            if (currentHour < 0 || currentHour > 23)
            {
                throw new HourOutOfRangeException();
            }

            if (currentHour < 6 || currentHour >= 20)
            {
                return $"¡Buenas noches {name}!";
            }

            if (currentHour < 12)
            {
                return $"¡Buenos días {name}!";
            }
            
            return $"¡Buenas tardes {name}!";
        }
    }

}