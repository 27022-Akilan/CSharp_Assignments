using System.Reflection;
using AssignmentSeventeen.Task1;

namespace AssignmentSeventeen
{
    public class MenuNaviagtor
    {
        public void NavigateMenu()
        {
            ExternalAssemblyDemo externalAssemblyDemo = new ExternalAssemblyDemo();
            Assembly assembly = externalAssemblyDemo.LoadAssembly();
            externalAssemblyDemo.InspectAssemblyTypes(assembly);
        }
    }
}
