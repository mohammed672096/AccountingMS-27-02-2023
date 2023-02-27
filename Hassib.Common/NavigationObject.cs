using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Svg;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;

namespace Hassib.Common
{
     public class NavigationObject
    {

        public static int MaxID = 1;

        #region Constructors

        /// <summary>
        /// Initialize new Master Navigation Object
        /// </summary>
        /// <param name="Caption"> The caption that will be displayed </param>
        public NavigationObject(string Caption )
            : this(Caption, null, null, false , WindowActions.Show)
        {
           
        }

        /// <summary>
        /// Initialize new Slave Navigation Object 
        /// </summary>
        /// <param name="Caption"> The caption that will be displayed </param>
        /// <param name="parent"> the master navigation object to be contained withen </param>
        public NavigationObject(string Caption, NavigationObject parent, bool begainGroup = false ) 
            : this (Caption, parent, null, begainGroup , WindowActions.Show)
        {
            
        }
        /// <summary>
        /// Initialize new Final Navigation Object that containes a form 
        /// </summary>
        /// <param name="Caption"> The caption that will be displayed </param>
        /// <param name="parent"> the master navigation object to be contained withen </param>
        /// <param name="function"></param>
        /// <param name="actions">the allowed actions in that form </param>
        public NavigationObject(string Caption, NavigationObject parent, Func<XtraForm> function, bool begainGroup,   WindowActions actions)
        {
            if (parent != null)
            {
                ParentID = parent.ID;
                BackColor = parent.BackColor;
            }
            ViewActions = actions;
            DisplayCaption = Caption;
            ConstructFormFunction = function;
            BegainGroup = begainGroup;
            this.ID = MaxID++;
        }
        #endregion



        #region Propertys
        public WindowActions ViewActions { get; set; }
        public bool CanAdd { get; set; }
        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool CanOpen { get; set; }
        public bool CanPrint { get; set; }
        public bool CanShow { get; set; }
        public  Func<XtraForm> ConstructFormFunction;
        internal  XtraForm _form;

        public bool HasFormContractor => ConstructFormFunction != null;
        public virtual  XtraForm Form
        {
            get
            {
                if ((_form == null || _form .IsDisposed )  && ConstructFormFunction != null)
                {
                  //  if(MainViews.HomeForm.IsFormInitialized == true )
                    _form =  ConstructFormFunction();
                }
                return _form;
            }
        }
        public int ID { get; set; }
        public int? ParentID { get; set; }

        public string DisplayCaption { get; set; }
        public string Description { get; set; }
        public string ToolTip { get; set; }

        
       SvgImage _svgImage;
        public SvgImage SvgImage
        {
            get
            {
                //if (_svgImage == null)
                //    return Form?.IconOptions.SvgImage;
                  return _svgImage;

            }
            set
            {
                _svgImage = value;
            }
        }

        Image _iconImage;
        public Image IconImage
        {
            get
            {
                if (SvgImage != null)
                {
                    SvgBitmap bm = new SvgBitmap(SvgImage);
                    var r = new Rectangle(0, 0, 25, 25);
                    var palette = SvgPaletteHelper.GetSvgPalette(UserLookAndFeel.Default,
                        DevExpress.Utils.Drawing.ObjectState.Normal);
                    if (_iconImage == null)
                        _iconImage = bm.Render(palette, 50);
                    return bm.Render(palette, 50);
                }
                else if (_iconImage != null)
                    return _iconImage;
                else
                {
                    return Form?.IconOptions.LargeImage;
                }
            }
            set
            {
                _iconImage = value;
            }

        }
        Color _backColor;
        public Color BackColor
        {
            get
            {
                //if (_backColor == null && IconImage != null)
                //{
                //    Bitmap bmp = new Bitmap(IconImage);
                //    int r = 0;
                //    int g = 0;
                //    int b = 0;

                //    int total = 0;

                //    for (int x = 0; x < bmp.Width; x++)
                //    {
                //        for (int y = 0; y < bmp.Height; y++)
                //        {
                //            Color clr = bmp.GetPixel(x, y);

                //            r += clr.R;
                //            g += clr.G;
                //            b += clr.B;

                //            total++;
                //        }
                //    }

                //    //Calculate average
                //    r /= total;
                //    g /= total;
                //    b /= total;

                //    _backColor = Color.FromArgb(r, g, b);
                //}
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }

        public string ScreenName { get => Form?.Name; }
        public bool BegainGroup { get; set; }
        #endregion


    }
}
