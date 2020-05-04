using System.Collections.Generic;
public sealed class ClientesServiceImp : ClientesService
{
    private readonly static ClientesServiceImp instance = new ClientesServiceImp();
    private List<Cliente> clientes;
    private int count;

    private ClientesServiceImp()
    {
        count = 1;
        clientes = new List<Cliente>();
    }

    public static ClientesServiceImp Instance
    {
        get
        {
            return instance;
        }
    }

    public List<Cliente> getClientes()
    {
        return clientes;
    }

    public Cliente getCliente(int id)
    {
        return clientes.Find((item) => item.id == id);
    }

    public Cliente createCliente(Cliente cliente)
    {
        cliente.id = count;
        count++;
        clientes.Add(cliente);
        return cliente;
    }

    public Cliente editCliente(Cliente cliente)
    {
        int index = clientes.FindIndex((item) => item.id == cliente.id);
        if (index >= 0)
        {
            Cliente editar = new Cliente();
            editar.name=cliente.name;
            editar.surname=cliente.surname;
            editar.address=cliente.address;
            editar.id = cliente.id;
            clientes[index] = editar;
            return editar;
        }
        else{
            return null;
        }
    }

    public bool deleteCliente(int id)
    {
        int index = clientes.FindIndex((item) => item.id == id);
        if(index>=0){
            clientes.RemoveAt(index);
            return true;
        }
        else{
            return false;
        }
    }
}