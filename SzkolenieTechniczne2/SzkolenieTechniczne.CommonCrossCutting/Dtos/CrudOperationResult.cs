

namespace SzkolenieTechniczne.CommonCrossCutting.Dtos
{
    public class CrudOperationResult<TDto>
    {
        public CrudOperationResultStatus Status { get; set; }

        public TDto? Result { get; set; }
    }
}
