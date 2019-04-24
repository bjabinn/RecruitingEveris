
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "Al ser un archivo propio de Swagger no se realizarán cambios del código", Scope = "member", Target = "~M:RecruitingWeb.SwaggerConfig.Register")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be \"commented out\"", Justification = "Al ser un archivo propio de Swagger no se realizarán cambios del código", Scope = "member", Target = "~M:RecruitingWeb.SwaggerConfig.Register")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3928:Parameter names used into ArgumentException constructors should match an existing one ", Justification = "Este archivo viene por defecto del componente DataTables, no deben modificarse los parámetros", Scope = "member", Target = "~M:RecruitingWeb.Components.DataTable.ServerSide.DataTablesBinder.ResolveNameValueCollection(System.Web.HttpRequestBase)~System.Collections.Specialized.NameValueCollection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S2344:Enumeration type names should not have \"Flags\" or \"Enum\" suffixes", Justification = "El enum es un sufijo que debe ponerse en los enumerables para que sea más escalable a la hora de codificar")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables", Justification = "Para estandarizar y evitar confusiones se deben declarar los repositorios y servicios al inicio e inicializarse en el constructor")]

