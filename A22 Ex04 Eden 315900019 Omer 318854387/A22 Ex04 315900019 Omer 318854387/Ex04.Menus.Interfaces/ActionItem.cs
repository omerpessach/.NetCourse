using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem
    {
        private readonly List<IActionListner> r_ActionListners = new List<IActionListner>();

        public ActionItem(string i_Title) : base(i_Title)
        {
        }

        public void  AddListner(IActionListner i_ActionListner)
        {
            r_ActionListners.Add(i_ActionListner);
        }

        public void  ActivateWhanActionOccured()
        {
            notifyAllListeners();
        }

        private void notifyAllListeners()
        {
            foreach(IActionListner cuurentLisetner in r_ActionListners)
            {
                cuurentLisetner.ReportAction();
            }
        }
    }
}
