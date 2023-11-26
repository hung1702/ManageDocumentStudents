using G02Apis.Applications.DTOModel;
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
    public class BieuMauController : ApiController
    {
        [Route("api/bieumau/getallloaibieumau")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllLoaiBieuMau()
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await db.LoaiVBs.ToListAsync();
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


        [Route("api/bieumau/getallbieumau")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllBieuMau()
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var vanBans = await db.VanBans.ToListAsync();
                var result = vanBans.Select(x => new BieuMauModel()
                {
                    Id = x.Id,
                    SinhVienId= x.SinhVienId,
                    MaSinhVien = x.MaSinhVien,
                    NamThu= x.NamThu,
                    SDT = x.SDT,
                    KhoaHoc = x.KhoaHoc,
                    QueQuan = x.QueQuan,
                    CMND =  x.CMND,
                    NoiDung= x.NoiDung,
                    LyDo =  x.LyDo,
                    DaXacMinh= x.DaXacMinh,
                    IsApproved= x.IsApproved,
                    IsPending= x.IsPending,
                    IsSolved= x.IsSolved,
                    NgayTao= x.NgayTao,
                    NguoiTao= x.NguoiTao,
                    LoaiVBId = x.LoaiVB.Id,
                    LoaiVB = x.LoaiVB,
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("api/bieumau/createbieumau")]
        [HttpGet]
        public async Task<IHttpActionResult> CreateBieuMau(BieuMauModel model)
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(model.LoaiVBId == default)
                    return BadRequest("bieu mau can co loai bieu mau: LoaiVBId");

                var loaiVanBan = await db.LoaiVBs.FirstOrDefaultAsync(x => x.Id == model.LoaiVBId);
                if(loaiVanBan == default)
                    return BadRequest("Loai Van ban not found");

                var sinhVien = await db.SinhViens.FirstOrDefaultAsync(x => x.Id == model.SinhVienId);
                var vanBan = new VanBan()
                {
                    SinhVienId = model.SinhVienId,
                    MaSinhVien = model.MaSinhVien,
                    SinhVien = sinhVien,
                    NamThu = model.NamThu,
                    SDT = model.SDT,
                    KhoaHoc = model.KhoaHoc,
                    QueQuan = model.QueQuan,
                    CMND = model.CMND,
                    NoiDung = model.NoiDung,
                    LyDo = model.LyDo,
                    DaXacMinh = model.DaXacMinh,
                    IsPending = true,
                    NguoiTao = model.NguoiTao,
                    NgayTao = DateTime.Now,
                    LoaiVBId = model.LoaiVBId,
                    LoaiVB = loaiVanBan,
                };
                db.VanBans.AddOrUpdate(vanBan);
                try
                {
                    var res = await db.SaveChangesAsync();
                    return Ok(vanBan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}