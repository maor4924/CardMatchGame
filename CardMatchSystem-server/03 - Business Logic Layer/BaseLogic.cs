using System;

namespace CardMatch
{
    public class BaseLogic : IDisposable
    {
        protected CardMatchDBEntities DB=new CardMatchDBEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
