using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassib.Common 
{
    public  class ReportNavigationObject : NavigationObject
    {

        /// <summary>
        /// Initialize new Final Navigation Object that containes a form 
        /// </summary>
        /// <param name="Caption"> The caption that will be displayed </param>
        /// <param name="parent"> the master navigation object to be contained withen </param>
        /// <param name="function"></param>
        /// <param name="actions">the allowed actions in that form </param>
        public ReportNavigationObject(string Caption, NavigationObject parent, Func<XtraForm> function, bool begainGroup,string descreption=null  )
        :base(Caption, parent, function, begainGroup, (WindowActions.Show | WindowActions.Open))
        {
            Description = descreption;
        }
        public ReportNavigationObject(string Caption ): base(Caption )
        {
        }
        public override XtraForm Form 
        {
            get
            {
                if (ConstructFormFunction != null)
                    _form = ConstructFormFunction();
                return _form;

            }
        }

    }
}
