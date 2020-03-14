using MyApplication.DomainModel;
using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.Infrastructure.Repositories.JsonFiles;
using System.Text.Json;

namespace MyApplication.Infrastructure.Repositories.JsonFiles
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(string fileDirectory) : base(fileDirectory)
        {
            
        }

        public new Customer Add(Customer entity)
        {
            var jsonCustomer = JsonSerializer.Serialize<Customer>(entity);

            WriteToJsonFile("Customer", entity.Id, JsonSerializer.Serialize<Customer>(entity));
            foreach (var  deliveryAddress in entity.DeliveryAddresses)
            {
                WriteToJsonFile("Customer_DeliveryAddress", entity.Id + "-" + deliveryAddress.Id, JsonSerializer.Serialize<DeliveryAddress>(deliveryAddress));
            }

            return entity;
        }

        private void WriteToJsonFile(string name, string id, string json)
        {
            System.IO.File.WriteAllText(_fileDirectory + @"\" + name +"_"+ id + ".txt", json);
        }
      

    }
}
