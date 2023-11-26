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
    public class MuonSachController : ApiController
    {
        [Route("api/muonSach/getallmuonsach")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllMuonSach()
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await db.MuonSaches.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("api/muonSach/insertorupdatemuonsach")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateMuonSach(MuonSach model)
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model.MuonSachId == default || model.MuonSachId == 0)
                {
                    db.MuonSaches.Add(model);
                    try
                    {
                        var res = await db.SaveChangesAsync();
                        // var result = await db.muonSachs.ToListAsync();
                        return Ok(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var muonSach = await db.MuonSaches.FindAsync(model.MuonSachId);
                    if (muonSach == null)
                    {
                        return NotFound();
                    }
                    muonSach.NguoiMuon = model.NguoiMuon;
                    muonSach.NgayMuon = DateTime.Now;
                    muonSach.TenSach = model.TenSach;
                    muonSach.MaSach = model.MaSach;
                    muonSach.DaTra = model.DaTra;
                    muonSach.NgayTra = model.NgayTra;
                    muonSach.ThoiHanMuon = model.ThoiHanMuon;
                    db.MuonSaches.AddOrUpdate(muonSach);
                    try
                    {
                        var res = await db.SaveChangesAsync();
                        return Ok(muonSach);
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