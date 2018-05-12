using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcBookStore.Models;

namespace MvcBookStore.Models
{
    public class GioHang
    {
        dbQLBanSachDataContext db = new dbQLBanSachDataContext();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public Double dDonGia { get; set; }
        public int iSoLuong { get; set; }

        public Double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int Masach)
        {
            iMaSach = Masach;
            SACH sach = db.SACHes.Single(n => n.Masach == iMaSach);
            sTenSach = sach.Tensach;
            sAnhBia = sach.Hinhminhhoa;
            dDonGia = double.Parse(sach.Dongia.ToString());
            iSoLuong = 1;
        }
    }
}