using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollClientAPITestProject.Utilities
{
    public class TestData
    {
        public static object ValidData()
        {           
            return new
            {
                name = "Apple MacBook Pro 17 Test 10",
                data = new
                {
                    year = 2020,
                    price = 2000.99,
                    CPU_model = "Intel Core i9",
                    Hard_disk_size = "1 TB"
                }

            };
        }

        public static object PutData()
        {
            return new
            {
                name = "Apple MacBook Pro 17 Test 11",
                data = new
                {
                    year = 2021,
                    price = 2049.99,
                    CPU_model = "Intel Core i9",
                    Hard_disk_size = "1 TB",
                    color = "silver"
                }

            };
        }
        public static object PatchData()
        {
            return new
            {
                name = "Apple MacBook Pro 16 (Updated Name)"
            };
        }
    }
}
