using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace AccountingMS
{
    public class FilterHelper
    {
        private GridView _view;

        public FilterHelper(GridView view)
        {
            _view = view;
            _view.MasterRowExpanded += _view_MasterRowExpanded;
            _view.CustomRowFilter += _view_CustomRowFilter;
            _view.ColumnFilterChanged += _view_ColumnFilterChanged;
        }

        private void _view_ColumnFilterChanged(object sender, EventArgs e)
        {
            string filter = _view.FindFilterText;
            string criteria = "";
            for (int i = 0; i < _view.DataRowCount; i++)
            {
                int handle = _view.GetVisibleRowHandle(i);
                int relationCount = _view.GetRelationCount(handle);
                for (int r = 0; r < relationCount; r++)
                {
                    if (_view.GetMasterRowExpandedEx(handle, r))
                    {
                        GridView view = (GridView)_view.GetDetailView(handle, 0);
                        if (string.IsNullOrEmpty(filter))
                        {
                            view.ActiveFilterCriteria = null;
                        }
                        else
                        {
                            for (int c = 0; c < view.Columns.Count; c++)
                            {
                                if (view.Columns[c].ColumnType == typeof(string))
                                {
                                    if (c != 0)
                                    {
                                        criteria += " Or " + view.Columns[c].FieldName + " like '" + filter + "%'";
                                    }
                                    else
                                    {
                                        criteria = view.Columns[c].FieldName + " like '" + filter + "%'";
                                    }
                                }
                            }
                            view.ActiveFilterCriteria = CriteriaOperator.Parse(criteria);
                        }
                    }
                }
            }
        }


        private void _view_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            string filter = view.FindFilterText;
            if (string.IsNullOrEmpty(filter))
            {
                return;
            }
            BaseGridController controller = view.DataController;
            IList source = (IList)view.DataSource;
            PropertyDescriptorCollection pdc = null;
            if (view.DataSource is ITypedList)
            {
                pdc = (view.DataSource as ITypedList).GetItemProperties(null);
            }
            else
            {
                pdc = TypeDescriptor.GetProperties(((object)source).GetType().GetProperty("Item").PropertyType);
            }
            ExpressionEvaluator ev = new ExpressionEvaluator(pdc, GetCriteriaFromPDC(pdc, filter), false);
            e.Visible = (!IsEmptyDetail(e.ListSourceRow, controller)) || ev.Fit(source[e.ListSourceRow]);
            e.Handled = true;
        }

        private void _view_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView parentView = sender as GridView;
            GridView view = (GridView)parentView.GetDetailView(e.RowHandle, e.RelationIndex);
            string filter = parentView.FindFilterText;
            string criteria = "";
            for (int i = 0; i < view.Columns.Count; i++)
            {
                if (view.Columns[i].ColumnType == typeof(string))
                {
                    if (i != 0)
                    {
                        criteria += " Or " + view.Columns[i].FieldName + " like '" + filter + "%'";
                    }
                    else
                    {
                        criteria = view.Columns[i].FieldName + " like '" + filter + "%'";
                    }
                }

            }
            view.ActiveFilterCriteria = CriteriaOperator.Parse(criteria);
        }

        private CriteriaOperator GetCriteriaFromPDC(PropertyDescriptorCollection pdc, string filter)
        {
            string criteria = "";
            for (int i = 0; i < pdc.Count; i++)
            {
                if (pdc[i].PropertyType == typeof(string))
                {
                    if (i != 0)
                    {
                        criteria += " Or " + pdc[i].Name + " like '" + filter + "%'";
                    }
                    else
                    {
                        criteria = pdc[i].Name + " like '" + filter + "%'";
                    }
                }
            }
            return CriteriaOperator.Parse(criteria);
        }

        private bool IsEmptyDetail(int listSourceRow, BaseGridController controller)
        {
            string filter = _view.FindFilterText;
            IList detail = (IList)controller.GetDetailList(listSourceRow, 0);
            PropertyDescriptorCollection pdc = null;
            if (detail is ITypedList)
            {
                pdc = (detail as ITypedList).GetItemProperties(null);
            }
            else
            {
                pdc = TypeDescriptor.GetProperties(((object)detail).GetType().GetProperty("Item").PropertyType);
            }
            if (string.IsNullOrEmpty(filter))
            {
                return false;
            }
            ExpressionEvaluator detailEvaluator = new ExpressionEvaluator(pdc, GetCriteriaFromPDC(pdc, filter), false);
            foreach (object o in detail)
            {
                DataRowView row = (DataRowView)o;
                if (detailEvaluator.Fit(row))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
