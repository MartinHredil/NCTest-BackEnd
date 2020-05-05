using Nancy;
using Nancy.TinyIoc;
public class Bootstrap : DefaultNancyBootstrapper
{
    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    {
        container.Register<IClientesService, ClientesService>().AsSingleton();

        base.ConfigureApplicationContainer(container);
    }
}