using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceContravariance
{
    class Animal { }
    class Cao : Animal { }
    delegate T Func1<out T>();
    delegate void Action1<in T>(T a);

    class Program
    {
        public static Cao CreateCaoInstance()
        {
            return new Cao();
        }

        public static void DisplayCaoInstance(Animal animal)
        {
            Console.WriteLine("Contravariance :" + animal);
        }
        static void Main(string[] args)
        {

            //Interface Covariance 
            IMessageRecieved<object> objMessageRX = new DataTX<string>();

            //Interface Contravariance
            IMessageSend<string> objMessageSend = new DataTX<object>();


            //Delegate Covariance 
            Func1<Cao> delegateCao = new Func1<Cao>(CreateCaoInstance);
            Cao objCao = delegateCao();
            Console.WriteLine("Convariance:" + objCao);
            Func1<Animal> delegateAnimal = delegateCao;
            Animal objAnimal = delegateAnimal();
            Console.WriteLine("Covariance:" + objAnimal);

            //Delegate Contravariance
            Action1<Animal> act1 = new Action1<Animal>(DisplayCaoInstance);
            act1(new Animal());
            Action1<Cao> cao1 = act1;
            cao1(new Cao());

            //Icomparer Contravariance
            BaseComparer<Manager> objComparer = new BaseComparer<Manager>();
            List<Manager> managerList = new List<Manager>();
            managerList.Add(new Manager("Damasceno", 1));
            managerList.Add(new Manager("Vitor", 2));
            managerList.Sort(objComparer);

            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee("Damasceno", 1));
            employeeList.Add(new Employee("Vitor", 2));

            //employeeList.Sort(objComparer);
            managerList.ForEach(e => Console.WriteLine(e.ID + " " + e.Name));

            Console.ReadKey();
        }
    }

    interface IMessageRecieved<out T>
    {
        T RecievedData();
    }
    interface IMessageSend<in T>
    {
        void SendData(T data);
    }

    class DataTX<T> : IMessageSend<T>, IMessageRecieved<T>
    {
        private T m_Data;

        #region IMessageSend<T> Members ( Implicit Implementation )
        void IMessageSend<T>.SendData(T data)
        {
            this.m_Data = data;
        }
        #endregion

        #region IMessageRecieved<T> Members ( Implicit Implementation )

        public T RecievedData()
        {
            return m_Data;
        }
        #endregion

        /*
        public virtual void SendData(T data)
        {
            this.m_Data = data;
        }
         */
    }
}
