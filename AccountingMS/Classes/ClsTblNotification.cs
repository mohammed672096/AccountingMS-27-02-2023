using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountingMS
{
    public class ClsTblNotification
    {
        accountingEntities db;

        public event EventHandler RaiseNotificationsChanged;

        public ClsTblNotification()
        {
            db = new accountingEntities();
        }

        private IQueryable<tblNotification> QueryData =>(Session.CurrentUser.id==1) ?
            db.tblNotifications.OrderBy(x => x.id).ThenBy(x => x.notDate).AsQueryable().AsNoTracking()
           : db.tblNotifications.Where(x => x.notBrnId == Session.CurBranch.brnId).OrderBy(x => x.id).ThenBy(x => x.notDate).AsQueryable().AsNoTracking();

        public IEnumerable<tblNotification> GetNotList => QueryData.AsQueryable().AsNoTracking().ToList();

        public IEnumerable<tblNotification> GetNotListSupByDate => QueryData.Where(x => x.notStatus == 1 && !x.notIsComplete && x.notDate <= DateTime.Now).AsQueryable().AsNoTracking().ToList();

        public int GetNotCountUnComplete => QueryData.Where(x => !x.notIsComplete).AsQueryable().AsNoTracking().Count();

        public int GetNotCountUnCompleteByDate => QueryData.Where(x => x.notStatus == 1 && !x.notIsComplete && x.notDate <= DateTime.Now).AsQueryable().AsNoTracking().Count();

        public IEnumerable<tblNotificationDetail> GetNotListDetail => QueryData.GroupBy(x => x.notSupId).Select(x => new tblNotificationDetail()
        {
            notSupId = x.Key,
            notNo = x.Select(x => x.notNo).FirstOrDefault(),
            notName = x.Select(x => x.notName).FirstOrDefault(),
            notDesc = x.Select(x => x.notDesc).FirstOrDefault(),
            notAmount = x.Select(x => x.notAmount).FirstOrDefault(),
            notAmountPaid = x.Sum(x => x.notAmountPaid),
            notAmountRemaning = (x.Select(x => x.notAmount).FirstOrDefault()
                      - x.Sum(x => x.notAmountPaid)),
            notDate = x.Select(x => x.notDate).FirstOrDefault(),
            notIsComplete = x.Select(x => x.notIsComplete).FirstOrDefault(),
            notStatus = x.Select(x => x.notStatus).FirstOrDefault()
        }).AsQueryable().AsNoTracking().ToList();

        private IEnumerable<tblNotification> GetNotListBySupId(int supId)
        {
            return QueryData.Where(x => x.notSupId == supId).ToList();
        }

        public tblNotification GetNotObjByStatusNdSupId(NotStatus notStatus, int notSupId)
        {
            return QueryData.Where(x => x.notStatus == (byte)notStatus && x.notSupId == notSupId).FirstOrDefault();
        }

        public tblNotification GetNotObjByStatusNdEntId(NotStatus notStatus, int notEntId)
        {
            return QueryData.Where(x => x.notStatus == (byte)notStatus && x.notEntId == notEntId).FirstOrDefault();
        }

        public bool IsNotFoundBySupId(NotStatus notStatus, int notSupId)
        {
            return QueryData.Any(x => x.notStatus == (byte)notStatus && x.notSupId == notSupId);
        }

        public bool IsNotFoundByEntId(NotStatus notStatus, int notEntId)
        {
            return QueryData.Any(x => x.notStatus == (byte)notStatus && x.notEntId == notEntId);
        }

        public void Add(int notSupId, int notNo, string notName, string notDesc, double? notAmount, DateTime notDate, NotStatus notStatus, int? notEntId = null, double? notAmountPaid = null)
        {
            db.tblNotifications.Add(new tblNotification()
            {
                notSupId = notSupId,
                notEntId = notEntId,
                notNo = notNo,
                notName = notName,
                notDesc = notDesc,
                notAmount = notAmount,
                notAmountPaid = notAmountPaid,
                notDate = notDate,
                notUsrId = Session.CurrentUser.id,
                notBrnId = Session.CurBranch.brnId,
                notIsComplete = false,
                notStatus = (byte)notStatus
            });

            SaveDB();
        }

        public void Attach(tblNotification tbNotification)
        {
            db.tblNotifications.Attach(tbNotification);
        }

        public void ResetChanges(tblNotification tbNotification)
        {
            db.Entry(tbNotification).State = EntityState.Unchanged;
        }

        public bool UpdateNotStatus(IEnumerable<tblNotificationDetail> tbNotificationDetailList, bool isCompleted)
        {
            if (tbNotificationDetailList?.Count() == 0) return true;

            tbNotificationDetailList?.ForEach(x =>
            {
                var tbNotList = GetNotListBySupId(x.notSupId);
                tbNotList?.ForEach(y =>
                {
                    Attach(y);
                    y.notIsComplete = isCompleted;
                });
            });

            return SaveDB();
        }

        public void Remove(tblNotification tbNotification)
        {
            Attach(tbNotification);
            db.tblNotifications.Remove(tbNotification);

            SaveDB();
        }

        protected internal bool SaveDB()
        {
            bool isSaved = ClsSaveDB.Save(db, LogHelper.GetLogger());
            db = new accountingEntities();

            this.RaiseNotificationsChanged?.Invoke(this, null);

            return isSaved;
        }
    }
}
