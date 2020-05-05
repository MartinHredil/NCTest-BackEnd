using System.Collections.Generic;
public interface IClientesService{
    IList<Cliente> getClientes();
    Cliente getCliente(int id);
    Cliente createCliente(Cliente cliente);
    Cliente editCliente(Cliente cliente);
    bool deleteCliente(int id);
}