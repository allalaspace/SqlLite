using System;
using System.Linq;
using System.Collections.Generic;

namespace CoreSqLite
{
    class Program
    {
        static void Main(string[] args)
        {

            var sqlLiteUpdateRepository = new SqlLiteUpdateRepository();

            IEnumerable<MyEntity> Entities = new List<MyEntity> { new MyEntity { MyEntityNum = 1, MyEntityDate = DateTime.Now, MyEntityLibelle = "First Registre" },
                                                                  new MyEntity { MyEntityNum = 2, MyEntityDate = DateTime.Now, MyEntityLibelle = "Second Registre" },
                                                                  new MyEntity { MyEntityNum = 3, MyEntityDate = DateTime.Now, MyEntityLibelle = "third Registre" }};

            sqlLiteUpdateRepository.InsertBsd(Entities);

            Console.WriteLine("Hello Sqlite");
            Console.ReadLine();
        }
    }
}
