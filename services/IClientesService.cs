using System.Collections.Generic;
public interface IClientesService{
    IList<Cliente> GetClientes();
    Cliente GetCliente(int id);
    Cliente CreateCliente(Cliente cliente);
    Cliente EditCliente(Cliente cliente);
    bool DeleteCliente(int id);
}