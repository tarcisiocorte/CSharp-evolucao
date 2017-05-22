using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CovarianceContravariance
{

    public class Employee
    {
        private string m_Name;
        private int m_ID;

        public Employee(string name, int id)
        {
            m_Name = name;
            m_ID = id;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
    }

    public class Manager:Employee
    {
        public Manager(string name, int id) : base(name, id) { }                      
    }

    public class BaseComparer<T>: IComparer<T> where T : Employee
    {       
            public int Compare(T x, T y)
            {
                return (x.ID < y.ID ? 0 : 1);
            }                                      
    }      
}
