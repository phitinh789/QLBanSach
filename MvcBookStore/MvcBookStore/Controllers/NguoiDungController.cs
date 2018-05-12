using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore.Models;

namespace MvcBookStore.Controllers
{
    public class NguoiDungController : Controller
    {
        dbQLBanSachDataContext db = new dbQLBanSachDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKi()
        {
            //Them tim kiem bai tap ve nha
            //Them dang nhap dang xuat
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(FormCollection collection,KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var nhaplaimatkhau = collection["Nhaplaimatkhau"];
            var diachi = collection["DiaChi"];
            var email = collection["Email"];
            var dienthoai = collection["DienThoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy)}", collection["NgaySinh"]);
            if (String.IsNullOrEmpty(hoten))
                ViewData["Loi1"] = "Họ tên không được để trống";
            else if (String.IsNullOrEmpty(tendn))
                ViewData["Loi2"] = "Tên đăng nhập không được để trống";
            else if (String.IsNullOrEmpty(matkhau))
                ViewData["Loi3"] = "Phải Nhập mật khẩu";
            else if (String.IsNullOrEmpty(nhaplaimatkhau))
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            else if (String.IsNullOrEmpty(diachi))
                ViewData["Loi5"] = "Phải nhập địa chỉ";
            else if (String.IsNullOrEmpty(email))
                ViewData["Loi6"] = "Phải nhập email";
            else if (String.IsNullOrEmpty(dienthoai))
                ViewData["Loi7"] = "Phải nhập lại số điện thoại";
            else
            {
                kh.HoTenKH = hoten;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKi();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
       public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
                ViewData["Loi1"] = "Phải Nhập tên đăng nhập";
            else if(String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
               
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TenDN == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Đăng Nhập Thành Công";
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("DatHang", "GioHang");
                }
                else
                    ViewBag.ThongBao = "Tên Đăng nhâp hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "BookStore");
        }
    }
}