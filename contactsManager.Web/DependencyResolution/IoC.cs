using contactsManager.Domain;
using contactsManager.Web.Infrastructure;
using StructureMap;
namespace contactsManager.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IContactDataSource>().HttpContextScoped().Use<ContactDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}