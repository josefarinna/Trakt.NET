namespace TraktNET
{
    public class BaseModule
    {
        protected readonly TraktContext _context;

        protected BaseModule(TraktContext context)
        {
            ArgumentValidator.ThrowIfNull(context);
            _context = context;
        }
    }
}
