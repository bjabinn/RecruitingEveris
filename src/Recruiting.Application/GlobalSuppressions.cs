
// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S2344:Enumeration type names should not have \"Flags\" or \"Enum\" suffixes", Justification = "El enum es un sufijo que debe ponerse en los enumerables para que sea más escalable a la hora de codificar")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables", Justification = "Para estandarizar y evitar confusiones se deben declarar los repositorios y servicios al inicio e inicializarse en el constructor")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S2971:\"IEnumerable\" LINQs should be simplified", Justification = "Es necesario transformar algunas IQueryable a IEnumerable para optimizar el rendimiento de las operaciones linq considerablemente")]

