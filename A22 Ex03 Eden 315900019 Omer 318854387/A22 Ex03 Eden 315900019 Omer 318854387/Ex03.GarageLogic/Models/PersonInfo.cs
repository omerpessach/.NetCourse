namespace Ex03.GarageLogic.Models
{
    public class PersonInfo
    {
        private readonly string r_Name;
        private readonly string r_PhoneNumber;

        public PersonInfo(string i_Name, string i_PhoneNumber)
        {
            r_Name = i_Name;
            r_PhoneNumber = i_PhoneNumber;
        }

        public override string ToString()
        {
            return string.Format(
@"Owner name: {0}
Phone number: {1}", r_Name, r_PhoneNumber);
        }
    }
}
