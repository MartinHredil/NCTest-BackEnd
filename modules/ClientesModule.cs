using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;

namespace NeoComplexxTest_BackEnd.modules
{
    public class ClientesModule : NancyModule
    {
        private ClientesHandler clientesHandler;

        public class ClienteModel
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string address { get; set; }
        }

        public ClientesModule() : base("/clientes")
        {
            clientesHandler = ClientesHandler.Instance;

            Get("/", args => { return clientesHandler.getClientes(); });

            Get("/{id}", args =>
            {
                Cliente cliente = clientesHandler.getCliente(args.id);
                if (cliente != null)
                {
                    return cliente;
                }
                else
                {
                    return new Response { StatusCode = HttpStatusCode.NotFound };
                }
            });

            Post("/", args =>
            {
                var cliente = this.Bind<ClienteModel>();
                if (clientesHandler.createCliente(cliente.name, cliente.surname, cliente.address))
                {
                    return 200;
                }
                else
                {
                    return new Response { StatusCode = HttpStatusCode.InternalServerError };
                }
            });

            Put("/{id}", args =>
            {
                var cliente = this.Bind<ClienteModel>();
                if (clientesHandler.editCliente(args.id, cliente.name, cliente.surname, cliente.address))
                {
                    return 200;
                }
                else
                {
                    return new Response { StatusCode = HttpStatusCode.NotFound };
                }
            });

            Delete("/{id}", args =>
            {
                if(clientesHandler.deleteCliente(args.id)){
                    return 200;
                }
                else{
                    return new Response { StatusCode = HttpStatusCode.NotFound };
                }
            });
        }
    }
}