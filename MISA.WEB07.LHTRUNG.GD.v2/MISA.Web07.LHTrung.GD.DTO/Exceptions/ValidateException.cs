using MISA.WEB07.LHTRUNG.GD.DTO.EntityUtilities;

namespace MISA.WEB07.LHTRUNG.GD.DTO.Exceptions
{
    public class ValidateException : Exception
    {
        public ErrorResult? errorResult { set; get; }
        public ValidateException(ErrorResult _errorResult)
        {
            this.errorResult = _errorResult;
        }
    }
}
