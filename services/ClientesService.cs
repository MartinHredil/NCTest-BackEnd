using System.Collections.Generic;
public class ClientesService : IClientesService
{
    private List<Cliente> clientes;
    private int count;

    public ClientesService()
    {
        count = 1;
        clientes = new List<Cliente>();
    }

    public IList<Cliente> getClientes()
    {
        return clientes;
    }

    public Cliente getCliente(int id)
    {
        return clientes.Find((item) => item.Id == id);
    }

    public Cliente createCliente(Cliente cliente)
    {
        cliente.Id = count;
        count++;
        clientes.Add(cliente);
        return cliente;
    }

    public Cliente editCliente(Cliente cliente)
    {
        int index = clientes.FindIndex((item) => item.Id == cliente.Id);
        if (index >= 0)
        {
            Cliente editar = new Cliente();
            editar.Name=cliente.Name;
            editar.Surname=cliente.Surname;
            editar.Address=cliente.Address;
            editar.Id = cliente.Id;
            clientes[index] = editar;
            return editar;
        }
        else{
            return null;
        }
    }

    public bool deleteCliente(int id)
    {
        int index = clientes.FindIndex((item) => item.Id == id);
        if(index>=0){
            clientes.RemoveAt(index);
            return true;
        }
        else{
            return false;
        }
    }
}