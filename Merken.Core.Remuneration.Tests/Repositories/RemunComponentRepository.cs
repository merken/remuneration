using Merken.Core.Remuneration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merken.Core.Remuneration.Common;
using System.Composition.Hosting;
using System.Reflection;
using System.Composition;
using System.IO;
using System.Runtime.Loader;
using Merken.Core.Common.Util;

namespace Merken.Core.Remuneration.Tests.Repositories
{
    public class RemunComponentRepository : IRemunCalculationRepository
    {
        public IList<IRemunCalculationComponent> GetRemunCalculationComponents()
        {
            var assemblies = new List<Assembly>();

            //Get the bin folder for this execution domain
            string executionPath = AppContext.BaseDirectory;
            

            foreach (string assemblyPath in Directory.GetFiles(executionPath, "*.dll"))
            {
                //Aggregate all the assemblies from bin folder
                var assembly = new AssemblyLoader(executionPath).LoadFromAssemblyPath(assemblyPath);
                assemblies.Add(assembly);
            }

            var configuration = new ContainerConfiguration()
                    .WithAssemblies(assemblies);

            //Return all exports for IRemunCalculationComponent
            using (var container = configuration.CreateContainer())
            {
                return container.GetExports<IRemunCalculationComponent>().ToList();
            }
        }
    }
}
