using PMISBussinessLayer.Entities;
using System.Collections.Generic;

namespace PMISBussinessLayer.Repositories
{
    public interface IClientRepository
    {
        public List<Client> GetAllClients();
        public void InsertClient(Client client);
        public void UpdateClient(Client client);
        public void DeleteClient(Client client);
        public Client GetClientById(int clientid);
    }
}
