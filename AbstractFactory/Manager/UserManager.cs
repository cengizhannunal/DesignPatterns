using AbstractFactory.Abstract;

namespace AbstractFactoryMethod.Manager
{
    public class UserManager
    {
        private readonly CrossCuttingConcern _crossCuttingConcern;
        public UserManager(CrossCuttingConcern crossCuttingConcern)
        {
            _crossCuttingConcern = crossCuttingConcern;
        }

        public void GetAll()
        {
            _crossCuttingConcern.CreateCaching().Cache("my items");
            _crossCuttingConcern.CreateLogger().Log("my items");
        }
    }
}
