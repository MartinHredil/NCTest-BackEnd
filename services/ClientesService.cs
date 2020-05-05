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

    public IList<Cliente> GetClientes()
    {
        return clientes;
    }

    public Cliente GetCliente(int id)
    {
        return clientes.Find((item) => item.Id == id);
    }

    public Cliente CreateCliente(Cliente cliente)
    {
        cliente.Id = count;
        count++;
        clientes.Add(cliente);
        return cliente;
    }

    public Cliente EditCliente(Cliente cliente)
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

    public bool DeleteCliente(int id)
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