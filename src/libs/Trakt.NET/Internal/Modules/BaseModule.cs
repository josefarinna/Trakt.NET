namespace TraktNET
{
    public class BaseModule
    {
        internal readonly TraktContext _context;

        internal BaseModule(TraktContext context)
        {
            ArgumentValidator.ThrowIfNull(context);
            _context = context;
        }
    }
}
