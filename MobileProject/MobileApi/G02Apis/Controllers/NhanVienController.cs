using G02Apis.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace G02Apis.Controllers
{
    public class NhanVienController : ApiController
    {
        [Route("api/nhanvien/insertorupdatenhanvien")]
        [HttpPost]
        public async Task<IHttpActionResult> InsertOrUpdateNhanVien(S_NhanVien model)
        {
            var db = new SoHoaEntities();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.NhanVienID == 0)
            {
                db.S_NhanVien.Add(model);

                try
                {
                    var res = await db.SaveChangesAsync();
                    var result = db.S_NhanVien.ToList();

                    return Ok(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
            }
            else
            {
                S_NhanVien nhanVien = await db.S_NhanVien.FindAsync(model.NhanVienID);
                if (nhanVien == null)
                {
                    return NotFound();
                }
                nhanVien.TenNhanVien = model.TenNhanVien;
                nhanVien.AnhDaiDien = model.AnhDaiDien;
                nhanVien.Email = model.Email;
                nhanVien.GioiTinh = model.GioiTinh;
                nhanVien.NguyenQuan = model.NguyenQuan;
                nhanVien.SoCMT = model.SoCMT;
                nhanVien.NgayCap = model.NgayCap;
                nhanVien.NgaySinh = model.NgaySinh;
                nhanVien.NoiCap = model.NoiCap;
                nhanVien.SoDienThoai = model.SoDienThoai;
                nhanVien.Email = model.Email;
                db.S_NhanVien.AddOrUpdate(nhanVien);
                try
                {
                    var res = await db.SaveChangesAsync();

                    return Ok(nhanVien);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }

            }
        }
    }
}
