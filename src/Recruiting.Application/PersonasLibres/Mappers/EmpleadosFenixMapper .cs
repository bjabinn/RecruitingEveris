using Recruiting.Application.Maestros.Enums;

namespace Recruiting.Application.PersonasLibres.Mappers
{
    public static class EmpleadosFenixMapper
    {
        #region Mapper

        public static string GetPropertiePath(string name)
        {
            string attributeName = null;

            switch (name)
            {
                case "NroEmpleado":
                    attributeName = "NroEmpleado";
                    break;
                case "Nombre":
                    attributeName = "Nombre";
                    break;
                case "Apellidos":
                    attributeName = "Apellidos";
                    break;
                case "Categoria":
                    attributeName = "Categoria";
                    break;
                case "Linea":
                    attributeName = "Linea";
                    break;
                case "Celda":
                    attributeName = "Celda";
                    break;               
            }

            return attributeName;
        }

        public static string ConvierteConnectionStringATuCentro(this string connectionString, int idCentro)
        {
            if (idCentro == (int)CentrosEnum.Sevilla)
            {
                connectionString = string.Format(connectionString, "UREP_SEV", "C7rMP8Quaw761zy");
            }
            if (idCentro == (int)CentrosEnum.Alicante)
            {
                connectionString = string.Format(connectionString, "UREP_ALI", "6r50avj85r07wIE");
            }
            if (idCentro == (int)CentrosEnum.Temuco)
            {
                connectionString = string.Format(connectionString, "UREP_TEM", "eKws216jk1CfPqC");
            }
            if (idCentro == (int)CentrosEnum.Tucuman)
            {
                connectionString = string.Format(connectionString, "UREP_TUC", "5Q593bBXBCs255s");
            }
            if (idCentro == (int)CentrosEnum.Murcia)
            {
                connectionString = string.Format(connectionString, "UREP_MUR", "a05fx4BHGRIj3es");
            }
            if (idCentro == (int)CentrosEnum.Tetuan)
            {
                connectionString = string.Format(connectionString, "UREP_TET", "9SJvjzmYgUFBYC9");
            }
            if (idCentro == (int)CentrosEnum.Uberlandia)
            {
                connectionString = string.Format(connectionString, "UREP_UDI", "tgCeXOD8t0qsX5A");
            }
            if (idCentro == (int)CentrosEnum.Lisboa)
            {
                connectionString = string.Format(connectionString, "UREP_LIS", "2Aj9ZeTu2mQMNPF");
            }
            if (idCentro == (int)CentrosEnum.Trujillo)
            {
                connectionString = string.Format(connectionString, "UREP_TRJ", "xFD5x6bwd9fTyYx");
            }
            return connectionString;
        }
       
       
        #endregion

    }
}
