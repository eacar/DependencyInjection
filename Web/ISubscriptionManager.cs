namespace Web
{

    public interface ISubscriptionManager
    {
        bool Subscribe(Subscriber subscriber);
        bool IsSubscriber(int id);
    }
    public interface ISubscriptionProvider
    {
        bool CreateList();
    }

    public class SubscriptionManager : ISubscriptionManager, ISubscriptionProvider
    {
        private Subscriber _subscriber;

        public bool Subscribe(Subscriber subscriber)
        {
            _subscriber = subscriber;
            //iş iş işiş
            return true;
        }

        public bool IsSubscriber(int id)
        {
            if (_subscriber.Id == id)
            {
                return true;
            }
            //iş iş işiş
            return false;
        }

        public bool CreateList()
        {
            return true;
        }
    }





    public class Subscriber
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
