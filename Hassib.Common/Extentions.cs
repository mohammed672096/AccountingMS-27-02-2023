using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

 


using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Hassib.Common 
{

    /// <summary>
    /// Extension methods for <see cref="System.ComponentModel.BindingList{T}"/>.
    /// </summary>
    public static class BindingListExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="System.ComponentModel.BindingList{T}"/>,
        /// while only firing the <see cref="System.ComponentModel.BindingList{T}.ListChanged"/>-event once.
        /// </summary>
        /// <typeparam name="T">
        /// The type T of the values of the <see cref="System.ComponentModel.BindingList{T}"/>.
        /// </typeparam>
        /// <param name="bindingList">
        /// The <see cref="System.ComponentModel.BindingList{T}"/> to which the values shall be added.
        /// </param>
        /// <param name="collection">
        /// The collection whose elements should be added to the end of the <see cref="System.ComponentModel.BindingList{T}"/>.
        /// The collection itself cannot be null, but it can contain elements that are null,
        /// if type T is a reference type.
        /// </param>
        /// <exception cref="ArgumentNullException">values is null.</exception>
        public static void AddRange<T>(this System.ComponentModel.BindingList<T> bindingList, IEnumerable<T> collection)
        {
            // The given collection may not be null.
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            // Remember the current setting for RaiseListChangedEvents
            // (if it was already deactivated, we shouldn't activate it after adding!).
            var oldRaiseEventsValue = bindingList.RaiseListChangedEvents;

            // Try adding all of the elements to the binding list.
            try
            {
                bindingList.RaiseListChangedEvents = false;

                foreach (var value in collection)
                    bindingList.Add(value);
            }

            // Restore the old setting for RaiseListChangedEvents (even if there was an exception),
            // and fire the ListChanged-event once (if RaiseListChangedEvents is activated).
            finally
            {
                bindingList.RaiseListChangedEvents = oldRaiseEventsValue;

                if (bindingList.RaiseListChangedEvents)
                    bindingList.ResetBindings();
            }
        }
    }

    public static class Exteintions
    {
        public static void ChangeBackColorEditorWhenFocus(Color color, params BaseEdit[] baseEdit)
        {
            baseEdit.ForEach(x => {
                x.Properties.AppearanceFocused.BackColor = color;// 
                x.Properties.AppearanceFocused.Options.UseBackColor = true;
            });
        }
        public static void MaskSpinTwoDigit(params BaseSpinEdit[] baseSpinEdits)
        {
            baseSpinEdits.ForEach(x =>
            {
                x.Properties.MaskSettings.Set("mask", "F2");
                x.Properties.UseMaskAsDisplayFormat = true;
            });

        }
        public static BaseEdit FocusEditorByEnterKey(this BaseEdit baseEdit, BaseEdit NextBaseEdit)
        {
            if (baseEdit is MemoEdit) return NextBaseEdit;
            baseEdit.KeyDown += (ss, ee) =>
            {
                if (ee.KeyCode == Keys.Enter)
                {
                    baseEdit.DoValidate();
                    object value = baseEdit.EditValue;
                    NextBaseEdit?.Focus();
                    baseEdit.EditValue = value;
                }
            };
            return NextBaseEdit;
        }
        public static Control FindFocusedControl(this Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }


        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public static IEnumerable<DateTime> EachMounth(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddMonths(1))
                yield return day;
        }
        public static IEnumerable<DateTime> EachYear(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddYears(1))
                yield return day;
        }


        public static T DeepCopy<T>(this T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Context = new StreamingContext(StreamingContextStates.Clone);
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
        public static void CopyPropertiesTo<TSource, TTarget>(this TSource source, TTarget destination)
            where TSource : class
            where TTarget : class
        {
            // Iterate the Properties of the destination instance and  
            // populate them from their source counterparts  
            PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
            foreach (PropertyInfo destinationPi in destinationProperties)
            {
                PropertyInfo sourcePi = source.GetType().GetProperty(destinationPi.Name);
                //if(sourcePi.GetType() is  )
                //{

                //}
                destinationPi.SetValue(destination, sourcePi.GetValue(source, null), null);
            }
        }

        /// <summary>Serializes an object of type T in to an xml string</summary>
        /// <typeparam name="T">Any class type</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <returns>A string that represents Xml, empty otherwise</returns>
        public static string XmlSerialize<T>(this T obj) where T : class, new()
        {
            if (obj == null) throw new ArgumentNullException("obj");
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }


        /// <summary>Deserializes an xml string in to an object of Type T</summary>
        /// <typeparam name="T">Any class type</typeparam>
        /// <param name="xml">Xml as string to deserialize from</param>
        /// <returns>A new object of type T is successful, null if failed</returns>
        public static T XmlDeserialize<T>(this string xml) where T : class, new()
        {
            if (xml == null) throw new ArgumentNullException("xml");
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xml))
            {
                try { return (T)serializer.Deserialize(reader); }
                catch { return null; } // Could not be deserialized to this type.
            }
        }



        public static U ShallowConvert<T, U>(this T parent, U child)
        {
            foreach (PropertyInfo property in parent.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                   
                    property.SetValue(child, property.GetValue(parent, null), null);
                }
            }
            return child;
        }

        public static void BindToDataSource(this LookUpEdit edit, object dataSource, string IdColumnName = "ID", string DisplayColumnName = "Name")
        {

            BindToDataSource(edit.Properties, dataSource, IdColumnName, DisplayColumnName);
        }

        public static void BindToDataSource(this RepositoryItemLookUpEdit edit, object dataSource, string IdColumnName = "ID", string DisplayColumnName = "Name")
        {

            edit.DataSource = dataSource;
            edit.ValueMember = IdColumnName;
            edit.DisplayMember = DisplayColumnName;
            edit.Columns.Clear();
            edit.Columns.Add(new LookUpColumnInfo(IdColumnName));
            edit.Columns.Add(new LookUpColumnInfo(DisplayColumnName));
            edit.BestFitMode = BestFitMode.BestFitResizePopup;
            edit.ShowHeader = false;
            edit.NullText = "";
        }



        public static void SetColumnFixed(this GridView view, FixedStyle fixedStyle, params GridColumn[] columns)
        {
            foreach (var col in columns)
                col.Fixed = fixedStyle;
        }

        public static void SetAlternatingColors(this GridView view, Color EvenRowColor, Color OddRowColor)

        {
            view.Appearance.EvenRow.BackColor = EvenRowColor;
            view.OptionsView.EnableAppearanceEvenRow = true;
            view.Appearance.OddRow.BackColor = OddRowColor;
            view.OptionsView.EnableAppearanceOddRow = true;
            view.OptionsSelection.EnableAppearanceFocusedRow = false;
        }
        public static void SetAlternatingColors(this GridView view)
        {
            SetAlternatingColors(view, Color.LightYellow, Color.WhiteSmoke);
        }


        public static DateTime GetServerTime(this DbContext context)
        {

            DbConnection connection = context.Database.Connection;
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT GETDATE()";
            DateTime date = (DateTime)cmd.ExecuteScalar();
            connection.Close();
            return date;

        }
        public static string GetNextSequence(this string Number)
        {
            if (Number == string.Empty || Number == null)
                return "1";
            string str1 = "";
            foreach (char c in Number)
                str1 = !char.IsDigit(c) ? "" : str1 + c.ToString();
            if (str1 == string.Empty)
                return Number + "1";
            string str2 = (Convert.ToInt64(str1.Insert(0, "1")) + 1L).ToString();
            string str3 = str2[0] != '1' ? str2.Remove(0, 1).Insert(0, "1") : str2.Remove(0, 1);
            int startIndex = Number.LastIndexOf(str1);
            Number = Number.Remove(startIndex);
            Number = Number.Insert(startIndex, str3);
            return Number;
        }

    }


    public static class ControlsExtensions
    {
        public static void AddEditButton(this GridView view , EventHandler clickEvent)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit(); ;
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();


            repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.SvgImage =  Properties.Resources.actions_edit;
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1 )});
            repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            view.GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemButtonEdit1 });
            DevExpress.XtraGrid.Columns.GridColumn colEdit = new DevExpress.XtraGrid.Columns.GridColumn(); ;
            view.Columns.Add(colEdit);
            colEdit.Caption = "تعديل";
            colEdit.ColumnEdit = repositoryItemButtonEdit1;
            colEdit.MaxWidth = 55;
            colEdit.MinWidth = 35;
            colEdit.Name = "colEdit";
            colEdit.Visible = true;
            colEdit.VisibleIndex = 1;
            colEdit.Width = 35;
            if(clickEvent!=null )
            repositoryItemButtonEdit1.Click += clickEvent;
        }

     
        public static void RestoreGridLayoutIfFound(this Form frm, string CurrentUserID)
        {
            foreach (var item in frm.Controls)
            {
                if (item is LayoutControl layout)
                {
                    foreach (var controls in layout.Controls)
                    {
                        if (controls is GridControl control)
                        {
                            if (control.MainView is GridView)
                                (control.MainView as GridView).LoadGridLayout(frm, CurrentUserID);
                        }
                    }
                }
            }
        }
        public static void SaveGridLayoutIfFound(this Form frm, string CurrentUserID)
        {
            foreach (var item in frm.Controls)
            {
                if (item is LayoutControl layout)
                {
                    foreach (var controls in layout.Controls)
                    {
                        if (controls is GridControl control)
                        {
                            if(control.MainView is GridView)
                            (control.MainView as GridView).SaveGridLayout(frm, CurrentUserID);
                        }
                    }
                }
            }
        }

        public static string Path => Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Hassib\\XmlLayouts";
        public static void SaveGridLayout(this GridView grid, Form frm, string CurrentUserID)
        {
            grid.SaveGridLayout(frm.Name, CurrentUserID);
        }
        public static void SaveGridLayout(this GridView grid,string frmName, string CurrentUserID)
        {
            try
            {
                string path = Path;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string xmlFile = path + "\\" + frmName + "_" + CurrentUserID + "_" + grid.Name + ".xml";
                grid.SaveLayoutToXml(xmlFile);
            }
            catch
            {

            }
        }

        public static void LoadGridLayout(this GridView grid, Form frm, string CurrentUserID)
        {
            grid.LoadGridLayout(frm.Name, CurrentUserID);
        }

        public static void LoadGridLayout(this GridView grid, string frmName, string CurrentUserID)
        {
            try
            {
                string path = Path;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string xmlFile = path + "\\" + frmName + "_" + CurrentUserID + "_" + grid.Name + ".xml";
                grid.RestoreLayoutFromXml(xmlFile);
            }
            catch
            {

            }
        }



        public static void Flip(this LayoutControl layout)
        {
            layout.Items.ForEach(x =>
            {
                if (x.TextLocation == Locations.Right)
                    x.TextLocation = Locations.Left;
                else
                    x.TextLocation = Locations.Right;
            });
        }
        public static void AddClearButton(this PopupBaseEdit edit)
        {
            edit.Properties.Buttons.Clear();
            edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.DropDown), new EditorButton(ButtonPredefines.Clear) });
            edit.ButtonClick += (sender, e) =>
            {
                if (e.Button.GetType() != typeof(EditorButton))
                    return;
                if (e.Button.Kind == ButtonPredefines.Clear)
                {
                    ((BaseEdit)sender).EditValue = null;
                }
            };
        }
        public static void IntializeData(this LookUpEdit lkp, object dataSource)
        {
            lkp.IntializeData(dataSource, "Name", "ID");
        }
        public static void IntializeData(this LookUpEdit lkp, object dataSource, string displayMember, string valueMember)
        {
            lkp.Properties.DataSource = dataSource;
            lkp.Properties.DisplayMember = displayMember;
            lkp.Properties.ValueMember = valueMember;
            lkp.Properties.Columns.Clear();
            lkp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo()
            {
                FieldName = displayMember,
            });
            lkp.Properties.ShowHeader = false; 
            lkp.Properties.NullText = "";

        }


    }
}
