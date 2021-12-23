using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem
    {
        private readonly List<IActionListner> r_ActionListnerList;

        public ActionItem(string i_CurrentTitle) : base(i_CurrentTitle)
        {
            r_ActionListnerList = new List<IActionListner>();
        }

        public void AddListner(IActionListner i_CurrentActionListner)
        {
            r_ActionListnerList.Add(i_CurrentActionListner);
        }

        public void ActivateWhanActionOccured()
        {
            notifyAllListeners();
        }

        private void notifyAllListeners()
        {
            foreach(IActionListner cuurentLisetner in r_ActionListnerList)
            {
                cuurentLisetner.ReportAction();
            }
        }
    }
}
