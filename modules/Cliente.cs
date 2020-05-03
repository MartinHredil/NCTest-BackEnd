public class Cliente
{
    public string name;
    public string surname;
    public string address;
    public int id;

    public Cliente(string name, string surname, string address)
    {
        this.name = name;
        this.surname = surname;
        this.address = address;
    }

    public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getSurname()
    {
        return surname;
    }

    public void setSurname(string surname)
    {
        this.surname = surname;
    }

    public string getAddress()
    {
        return address;
    }

    public void setAddress(string address)
    {
        this.address = address;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public int getId()
    {
        return id;
    }
}
