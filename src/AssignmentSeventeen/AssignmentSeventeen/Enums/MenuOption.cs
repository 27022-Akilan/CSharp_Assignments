namespace AssignmentSeventeen.Enums
{
    /// <summary>
    /// Represents the menu options for navigating.
    /// </summary>
    public enum MenuOption
    {
        /// <summary>
        /// Option for analyzing external assembly.
        /// </summary>
        AnalyzeAssembly = 1,

        /// <summary>
        /// Option for inspecting  a dynamic object.
        /// </summary>
        DynamicObjectInspector,

        /// <summary>
        /// Option for invoking the method.
        /// </summary>
        DynamicMethodInvoker,

        /// <summary>
        /// Option for dynamically building a type.
        /// </summary>
        DynamicTypeBuilder,

        /// <summary>
        /// Option for inspecting plugin.
        /// </summary>
        PluginInspection,

        /// <summary>
        /// Option for Mocking a type.
        /// </summary>
        MockFramework,

        /// <summary>
        /// Option for Serialization.
        /// </summary>
        Serialization,

        /// <summary>
        /// Option for exiting the application.
        /// </summary>
        Exit,
    }
}
