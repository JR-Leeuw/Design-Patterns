using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd
{
    public class Invoker
    {
        private List<ICommand> orderList = new List<ICommand>();

        public void takeOrder(ICommand command)
        {
            orderList.Add(command);
        }

        public void placeOrders()
        {
            foreach (ICommand command in orderList)
            {
                command.Execute();
            }
            orderList.Clear();
        }
    }
}
