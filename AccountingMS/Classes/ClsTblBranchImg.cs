using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AccountingMS
{
    class ClsTblBranchImg
    {
        List<tblBranchImg> tbBranchImgList;
        public ClsTblBranchImg()
        {
            InitData();
        }

        private void InitData()
        {
            using (accountingEntities db = new accountingEntities())
                this.tbBranchImgList = db.tblBranchImgs.AsNoTracking().ToList();
        }
        public Image GetBitmapLogImage()
        {
            try
            {
                var img = new ClsTblBranchImg().GetBranchImg(Session.CurBranch.brnId);
                if (img == null) return null;
                MemoryStream memoryStream = new MemoryStream(img);
                Bitmap bitmap = new Bitmap(memoryStream);
                return bitmap;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public byte[] GetBranchImg(short brnId) => this.tbBranchImgList?.FirstOrDefault(a => a.imgBrnId == brnId)?.imgBrn;
        public bool SaveImage(short brnId, byte[] imageBuffer)
        {
            using (accountingEntities db = new accountingEntities())
            {
                try
                {
                    if (!db.tblBranchImgs.Any(x => x.imgBrnId == brnId))
                        db.tblBranchImgs.Add(new tblBranchImg() { imgBrnId = brnId, imgBrn = imageBuffer });
                    else
                        db.tblBranchImgs.FirstOrDefault(x => x.imgBrnId == brnId).imgBrn = imageBuffer;
                    return db.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format((!MySetting.GetPrivateSetting.LangEng) ?
                        "عذرا حدث خطاء عند حفظ الصورة. \n" : "Sorry, there was an error saving the image. \n") + ex.Message);
                    return false;
                }
            }

        }
    }
}
