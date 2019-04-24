using System;

// OJO: El namespace es más específico que Base.
namespace Recruiting.Application.Base.ViewModel
{
    public class ModifiableEntityViewModel
    {
        #region Scalar Properties

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        #endregion

    }
}
