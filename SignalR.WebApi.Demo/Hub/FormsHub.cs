using SignalR.WebApi.Demo.Data;
using System.Collections.Generic;
using System.Linq;

namespace SignalR.WebApi.Demo.Hub
{
    public class FormsHub : Microsoft.AspNet.SignalR.Hub
    {
        public static object _lock = new object();
        public static List<Form> dataList = new List<Form>();

        public void RefreshData(Form form)
        {
            lock (_lock)
            {

                // your logic here
                if (form != null)
                {
                    Clients.All.refreshData(form);
                }

            }
        }
    }
}