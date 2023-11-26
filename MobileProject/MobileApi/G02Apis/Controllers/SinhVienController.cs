using G02Apis.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace G02Apis.Controllers
{
    public class SinhVienController : ApiController
    {
        [Route("api/sinhvien/getallsinhvien")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllSinhVien()
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await db.SinhViens.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("api/bieumau/insertorupdateloaiVB")]
        [HttpPost]
        public async Task<IHttpActionResult> InsertOrUpdateloaiVB(LoaiVB model)
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model.Id == default || model.Id == 0)
                {
                    db.LoaiVBs.Add(model);
                    try
                    {
                        var res = await db.SaveChangesAsync();
                        // var result = await db.loaiVBs.ToListAsync();
                        return Ok(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var loaiVB = await db.LoaiVBs.FindAsync(model.Id);
                    if (loaiVB == null)
                    {
                        return NotFound();
                    }
                    loaiVB.Ten = model.Ten;
                    loaiVB.MoTa = model.MoTa;
                    loaiVB.IsActive = true;
                    loaiVB.ThoiGianXuLy = model.ThoiGianXuLy;
                    loaiVB.QuyTrinh = model.QuyTrinh;
                    loaiVB.NguoiTao = model.NguoiTao;
                    loaiVB.NgayTao = model.NgayTao;
                    db.LoaiVBs.AddOrUpdate(loaiVB);
                    try
                    {
                        var res = await db.SaveChangesAsync();
                        return Ok(loaiVB);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}