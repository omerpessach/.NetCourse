using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsControlsAndDialogs
{
    public enum eStudentLevel
    {
        Failed,
        Regular,
        Excellent
    }

    public class Student
    {
        private string m_FirstName;
        public string FirstName
        {
            get { return m_FirstName; }
            set
            {
                if (m_FirstName != value)
                {
                    m_FirstName = value;
                }
            }
        }

        private string m_LastName;
        public string LastName
        {
            get { return m_LastName; }
            set
            {
                if (m_LastName != value)
                {
                    m_LastName = value;
                }
            }
        }

        private string m_Phone;
        public string Phone
        {
            get { return m_Phone; }
            set
            {
                if (m_Phone != value)
                {
                    m_Phone = value;
                }
            }
        }

        private int m_Age;
        public int Age
        {
            get { return m_Age; }
            set
            {
                if (m_Age != value)
                {
                    m_Age = value;
                }
            }
        }

        private eStudentLevel m_Level;
        public eStudentLevel Level
        {
            get { return m_Level; }
            set
            {
                if (m_Level != value)
                {
                    m_Level = value;
                }
            }
        }
    }
}
