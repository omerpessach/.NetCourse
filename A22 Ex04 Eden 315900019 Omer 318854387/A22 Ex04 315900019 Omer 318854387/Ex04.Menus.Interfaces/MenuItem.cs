namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string r_Title;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public string Title
        {
            get
            {
                return r_Title;
            }
        }
    }
}
