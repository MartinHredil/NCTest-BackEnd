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
        public class Bootstrap : DefaultNancyBootstrapper
        {
            protected override void ConfigureApplicationContainer(TinyIoCContainer container)
            {
                container.Register<ClientesService>(ClientesServiceImp.Instance);

                base.ConfigureApplicationContainer(container);
            }
        }

        public ClientesModule(ClientesService clientesService) : base("/clientes")
        {

            Get("/", args => { return clientesService.getClientes(); });

            Get("/{id}", args =>
            {
                Cliente cliente = clientesService.getCliente(args.id);
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
                if (cliente.name == null || cliente.surname == null || cliente.address == null)
                {
                    return new Response { StatusCode = HttpStatusCode.Forbidden };
                }
                else
                {
                    return clientesService.createCliente(cliente);
                }
            });

            Put("/{id}", args =>
            {
                var cliente = this.Bind<Cliente>();
                cliente.id = args.id;
                if (cliente.name == null || cliente.surname == null || cliente.address == null)
                {
                    return new Response { StatusCode = HttpStatusCode.Forbidden };
                }
                else
                {
                    Cliente edited = clientesService.editCliente(cliente);
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
                if (clientesService.deleteCliente(args.id))
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