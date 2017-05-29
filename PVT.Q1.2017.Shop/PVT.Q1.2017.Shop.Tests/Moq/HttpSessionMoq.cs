using Shop.Common.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace PVT.Q1._2017.Shop.Tests.Moq
{
    public class HttpSessionMock : HttpSessionStateBase
    {
        Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();
        public HttpSessionMock ()
        {
            m_SessionStorage.Add("IsModifiedOrdersCount", true);
            m_SessionStorage.Add("OrdersCount", 4);
            m_SessionStorage.Add("UserCurrency", new CurrencyViewModel());
        }

        public override object this[string name]
        {
            get { return m_SessionStorage[name]; }
            set { var testData = value; }
        }
    }
}