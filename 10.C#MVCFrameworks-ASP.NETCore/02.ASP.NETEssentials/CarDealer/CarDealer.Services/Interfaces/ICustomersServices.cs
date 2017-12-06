namespace CarDealer.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface ICustomersServices
    {
        ICollection<CustomerModel> OrderedCustomers(OrderType order);

        CustomersById CustomersById(string id);

        void Create(string name, DateTime birthDay, bool isYoungDriver);

        CustomerModel ById(int id);

        void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);

        bool Exist(int id);
    }
}
