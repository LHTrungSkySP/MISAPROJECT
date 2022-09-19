namespace MISA.WEB07.LHTRUNG.GD.DTO.Exceptions
{
    public class ValidateException : Exception
    {
        string? MsgErrorValidate = null;
        public ValidateException(string msg)
        {
            this.MsgErrorValidate = msg;
        }

        public override string Message
        {
            get
            {
                return MsgErrorValidate;
            }
        }
    }
}
