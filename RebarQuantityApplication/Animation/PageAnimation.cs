using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebarQuantityApplication
{
    /// <summary>
    /// styles of page animoations for appearing/disappearing
    /// </summary>
    
    public enum PageAnimation
    {
        /// <summary>
        /// No animation takes place
        /// </summary>
        None = 0,
        /// <summary>
        /// The page slides in and fades in from the right
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// The page slide out and fades out to the left
        /// </summary>
        SlideAndFadeOutToLeft =2,

    }
}
