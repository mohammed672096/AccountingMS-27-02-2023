using DevExpress.Data;
using DevExpress.Data.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AccountingMS.Classes
{
    public static class Utils
    {
        public static Color ToColor(this uint argb)
        {
            return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                                  (byte)((argb & 0xff0000) >> 0x10),
                                  (byte)((argb & 0xff00) >> 8),
                                  (byte)(argb & 0xff));
        }
        public static Color ColorFromHexa(uint argb)
        {
            return argb.ToColor();
        }
        public static Color ColorFromHexa(string hexCode)
        {

            return System.Drawing.ColorTranslator.FromHtml(hexCode);
        }
        public static void RestoreGridLayout(this GridView grid, Form frm)
        {
            try
            {

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\AccountingMS\\XmlLayouts";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string xmlFile = path + "\\" + frm.Name + "_" + grid.Name + ".xml";
                if (System.IO.File.Exists(xmlFile))
                {
                    grid.RestoreLayoutFromXml(xmlFile);
                }

            }
            catch
            {
            }
        }
        public static void RestoreGridLayout(this GridView grid, string frmName)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\AccountingMS\\XmlLayouts";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                string xmlFile = path + "\\" + frmName + "_" + grid.Name + ".xml";
                if (System.IO.File.Exists(xmlFile)) grid.RestoreLayoutFromXml(xmlFile);
            }
            catch
            {
            }
        }
        public static void SaveGridLayout(this GridView grid, Form frm)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\AccountingMS\\XmlLayouts";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string xmlFile = path + "\\" + frm.Name + "_" + grid.Name + ".xml";
                //(grid.MainView as GridView).ActiveFilter.Clear();
                grid.SaveLayoutToXml(xmlFile);
            }
            catch
            {
            }
        }
        public static void SaveGridLayout(this GridView grid, string frmName)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\AccountingMS\\XmlLayouts";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                string xmlFile = path + "\\" + frmName + "_" + grid.Name + ".xml";
                grid.SaveLayoutToXml(xmlFile);
            }
            catch
            {
            }
        }
        public static void ResetAppearance(this Form frm)
        {
            frm.Controls.ResetAppearance();


        }
        public static void ResetAppearance(this System.Windows.Forms.Control.ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                switch (controls[i].GetType().ToString())
                {
                    case "DevExpress.XtraGrid.GridControl":
                        foreach (BaseView view in ((GridControl)controls[i]).ViewCollection)
                            view.Appearance.Reset();
                        break;
                    case "DevExpress.XtraNavBar.NavBarControl":
                        ((NavBarControl)controls[i]).Appearance.Reset();
                        break;
                    //case "DevExpress.XtraVerticalGrid.VGridControl":
                    //    ((VGridControl)controls[i]).Appearance.Reset();
                    //    break;
                    case "DevExpress.XtraTreeList.TreeList":
                        ((TreeList)controls[i]).Appearance.Reset();
                        break;
                    default:
                        ResetAppearance(controls[i].Controls);
                        break;
                }
            }
        }

        //public static IEnumerable<tblSupplyMain> GetSelectedRowsAsync(this GridView view)
        public static IEnumerable GetSelectedRowsAsync(this GridView view)
        {
            if (view.DataSource is AsyncListWrapper)
                return ((AsyncListWrapper)view.DataSource).GetSelectedRowsAsync(view);

            ClsXtraMssgBox.ShowError("PassedCondition");
            throw new NotImplementedException();
        }

        //public static IEnumerable<tblSupplyMain> GetSelectedRowsAsync(this AsyncListWrapper dataSource, GridView view)
        public static IEnumerable GetSelectedRowsAsync(this AsyncListWrapper dataSource, GridView view)
        {
            var pageSize = 512;

            for (int i = 0; i < dataSource.Count; i++)
            {
                while (dataSource.Controller.IsBusy)
                {
                    Thread.Sleep(5);
                    Application.DoEvents();
                }
                if (!view.IsRowSelected(i)) continue;
                var row = dataSource.Controller.GetListSourceRow(i);
                while (row is NotLoadedObject)
                {
                    var count = Math.Min(dataSource.Count - i, pageSize);
                    dataSource.Controller.LoadRows(i, count);
                    Application.DoEvents();
                    while (dataSource.Controller.IsBusy)
                    {
                        Thread.Sleep(5);
                        Application.DoEvents();
                    }
                    row = dataSource.Controller.GetListSourceRow(i);
                }
                yield return row;
                //yield return row as tblSupplyMain;
            }
        }
    }
}
