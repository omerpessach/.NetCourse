namespace Ex04.Menus.Delegates
{
    public delegate void SelectedEventHandler();
    public class MenuItem
    {
        public event SelectedEventHandler MenuSelected;

        private readonly string           r_Title;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }

        public string   Title
        {
            get
            {
                return r_Title;
            }
        }

        public void     OnMenuSelected()
        {
            MenuSelected?.Invoke();
        }
    }
}
