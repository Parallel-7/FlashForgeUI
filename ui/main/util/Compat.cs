using System;

namespace FlashForgeUI.ui.main.util
{
    // Handle compatibility with different firmware versions and other cases
    public class Compat
    {
        
        private static readonly Version ver313 = new Version(3, 1, 3);
        
        // Check for firmware 3.13.3+
        public static bool Is313OrAbove(Version current)
        {
            try
            {
                return current >= ver313;
            }
            catch
            {
                // todo error handling
                return false;
            }
        }
    }
}