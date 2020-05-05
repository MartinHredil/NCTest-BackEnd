using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using Nancy.TinyIoc;

namespace NeoComplexxTest_BackEnd.modules
{
    public class ClientesModule : NancyModule
    {
        public ClientesModule(IClientesService clientesService) : base("/clientes")
        {

            Get("/", args => { return clientesService.GetClientes(); });

            Get("/{id}", args =>
            {
                Cliente cliente = clientesService.GetCliente(args.id);
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
                var cliente = this.Bind<Cliente>();
                if (cliente.Name == null || cliente.Surname == null || cliente.Address == null)
                {
                    return new Response { StatusCode = HttpStatusCode.Forbidden };
                }
                else
                {
                    return clientesService.CreateCliente(cliente);
                }
            });

            Put("/{id}", args =>
            {
                var cliente = this.Bind<Cliente>();
                cliente.Id = args.id;
                if (cliente.Name == null || cliente.Surname == null || cliente.Address == null)
                {
                    return new Response { StatusCode = HttpStatusCode.Forbidden };
                }
                else
                {
                    Cliente edited = clientesService.EditCliente(cliente);
                    if (edited == null)
                    {
                        return new Response { StatusCode = HttpStatusCode.NotFound };
                    }
                    else
                    {
                        return edited;
                    }
                }
            });

            Delete("/{id}", args =>
            {
                if (clientesService.DeleteCliente(args.id))
                {
                    return 204;
                }
                else
                {
                    return new Response { StatusCode = HttpStatusCode.NotFound };
                }
            });
        }
    }
}