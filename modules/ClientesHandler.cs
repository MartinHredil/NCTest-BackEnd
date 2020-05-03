using System.Collections.Generic;
public sealed class ClientesHandler
{
    private readonly static ClientesHandler instance = new ClientesHandler();
    private Cliente[] clientes;
    private List<int> freeSpace;
    private int size;

    private ClientesHandler()
    {
        size = 100;
        clientes = new Cliente[size];
        freeSpace = new List<int>();
        for (int i = 0; i < size; i++)
        {
            clientes[i] = null;
            freeSpace.Add(i);
        }
    }

    public static ClientesHandler Instance
    {
        get
        {
            return instance;
        }
    }

    public List<Cliente> getClientes()
    {
        List<Cliente> toReturn = new List<Cliente>();
        for (int i = 0; i < size; i++)
        {
            if (clientes[i] != null)
            {
                toReturn.Add(clientes[i]);
            }
        }
        return toReturn;
    }

    public Cliente getCliente(int id)
    {
        int arrId = id - 1;
        Cliente toReturn = null;
        if (arrId >= 0 && arrId < size)
        {
            toReturn = clientes[arrId];
        }
        return toReturn;
    }

    public bool deleteCliente(int id)
    {
        bool toReturn = false;
        int arrId = id - 1;
        if (arrId >= 0 && arrId < size && clientes[arrId]!=null)
        {
            clientes[arrId] = null;
            freeSpace.Add(arrId);
            toReturn = true;
        }

        return toReturn;
    }

    public bool editCliente(int id, string name, string surname, string address)
    {
        bool toReturn = false;
        int arrId = id - 1;
        if (arrId >= 0 && arrId < size && clientes[arrId] != null)
        {
            clientes[arrId].setName(name);
            clientes[arrId].setSurname(surname);
            clientes[arrId].setAddress(address);
            toReturn=true;
        }
        return toReturn;
    }

    public bool createCliente(string name, string surname, string address)
    {
        bool toReturn = false;
        if (freeSpace.Count > 0)
        {
            int indice = freeSpace[0];
            freeSpace.RemoveAt(0);
            clientes[indice] = new Cliente(name, surname, address);
            clientes[indice].setId(indice + 1);
            return true;
        }
        return toReturn;
    }
}