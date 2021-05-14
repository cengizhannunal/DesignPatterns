using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository(new SqlDbProvider());

            productRepository.Save();

            Console.ReadLine();
        }
    }

    public interface IDbContext
    {
        public void OpenConnection();
        public void CloseConnection();

    }

    //Bridge
    public abstract class DbContext : IDbContext
    {
        readonly IDbContext _dbContext;

        protected DbContext(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void CloseConnection()
        {
            _dbContext.CloseConnection();
        }

        public virtual void OpenConnection()
        {
            _dbContext.OpenConnection();
        }
    }

    public class SqlDbProvider : IDbContext
    {
        public void CloseConnection()
        {
            Console.WriteLine("Sql close");
        }

        public void OpenConnection()
        {
            Console.WriteLine("Sql open");
        }
    }

    public class OracleProvider : IDbContext
    {
        public void CloseConnection()
        {
            Console.WriteLine("Oracle close");
        }

        public void OpenConnection()
        {
            Console.WriteLine("Oracle open");
        }
    }


    public class ProductRepository : DbContext
    {
        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        public void Save()
        {
            OpenConnection();

            //save
            Console.WriteLine("Ürün eklendi.");

            CloseConnection();
        }
    }
}
