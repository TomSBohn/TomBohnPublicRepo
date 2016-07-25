using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public static class OrderRepositoryFactory
    {
        public static IOrderRepo CreateOrderRepo()

        {
            var mode = ConfigurationManager.AppSettings["Mode"];

            //var mode = "TEST";
            IOrderRepo repository;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repository = new InMemoryRepo();
                    break;

                case "PROD":
                    repository = new FileRepository();
                    break;

                default:
                    throw new Exception("Not a model");
            }
            return repository;
        }


        public static IProductRepo CreateProductRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            IProductRepo repository;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repository = new InMemoryRepo();
                    break;

                case "PROD":
                    repository = new ProductRepo();
                    break;

                default:
                    throw new Exception("Not a model");
            }
            return repository;
        }

        public static IStateTaxInfoRepo CreateStateTaxInfoRepo()
        {

            string mode = ConfigurationManager.AppSettings["Mode"];
            IStateTaxInfoRepo repository;
            switch (mode.ToUpper())
            {
                case "TEST":
                    repository = new InMemoryRepo();
                    break;

                case "PROD":
                    repository = new StateTaxInfoRepo();
                    break;

                default:
                    throw new Exception("Not a model");
            }
            return repository;
        }
    }
}
