using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;

namespace AzureTable
{
    class Program
    {
        private static string connection_string = "DefaultEndpointsProtocol=https;AccountName=chstoragewepayuomdev;AccountKey=A0Rkjpz94SRrUOqaZykXXlKRrd8P5q/KbNOpnRwnPg8NnOWVaiZYgNPlyMM/xgi3n7gx1QTd1wMvzxTId44dVw==;EndpointSuffix=core.windows.net";
        private static string table_name = "Customer";
        private static string partition_key = "Chicago";
        private static string row_key = "C2";
        static void Main(string[] args)
        {
            Console.WriteLine("Operation Started!");
            CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);

            CloudTableClient _client = _account.CreateCloudTableClient();

            CloudTable _table = _client.GetTableReference(table_name);
            //_table.CreateIfNotExists();

            //Customer _customer = new Customer("UserA", "Chicago", "C1");
            //TableOperation _operation = TableOperation.Insert(_customer);
            //TableResult _result = _table.Execute(_operation);
            //Console.WriteLine("Entity is added");

            //List<Customer> _customers = new List<Customer>()
            //{
            //    new Customer("UserB", "Chicago", "C2"),
            //    new Customer("UserC", "Chicago", "C3"),
            //    new Customer("UserD", "Chicago", "C4"),
            //};

            //TableBatchOperation _operation = new TableBatchOperation();
            //foreach (Customer _customer in _customers)
            //    _operation.Insert(_customer);
            //TableBatchResult _result = _table.ExecuteBatch(_operation);

            //TableOperation _operation = TableOperation.Retrieve<Customer>(partition_key, row_key);
            //TableResult _result = _table.Execute(_operation);
            //Customer _customer = _result.Result as Customer;

            //Console.WriteLine($"The customer name is {_customer.customername}");
            //Console.WriteLine($"The customer city is {_customer.PartitionKey}");
            //Console.WriteLine($"The customer id is {_customer.RowKey}");

            //Customer _customer = new Customer("UserE", partition_key, row_key);
            //TableOperation _operation = TableOperation.InsertOrMerge(_customer);
            //TableResult _result = _table.Execute(_operation);
            //Console.WriteLine("Customer information is updated");

            TableOperation _operation = TableOperation.Retrieve<Customer>(partition_key, row_key);
            TableResult _result = _table.Execute(_operation);
            Customer _customer = _result.Result as Customer;
            TableOperation _delete_operation = TableOperation.Delete(_customer);
            TableResult _delete_result = _table.Execute(_delete_operation);
            Console.WriteLine("Customer information is deleted");

            Console.ReadKey();
        }
    }
}
