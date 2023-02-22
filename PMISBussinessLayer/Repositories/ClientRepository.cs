using PMISBussinessLayer.Data;
using PMISBussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBussinessLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext context;

        public ClientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteClient(Client client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return context.Clients.ToList();
        }

        public Client GetClientById(int clientid)
        {
            return context.Clients.SingleOrDefault(q => q.Id == clientid);
        }

        public void InsertClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();

        }

        public void UpdateClient(Client client)
        {
            context.Clients.Update(client);
            context.SaveChanges();
        }

    }
}
