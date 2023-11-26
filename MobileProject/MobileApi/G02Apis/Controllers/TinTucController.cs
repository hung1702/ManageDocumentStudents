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
    public class TinTucController : ApiController
    {
        [Route("api/tintuc/getalltintuc")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllTinTuc()
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await db.TinTucs.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("api/tintuc/insertorupdatetintuc")]
        [HttpPost]
        public async Task<IHttpActionResult> InsertOrUpdateTinTuc(TinTuc model)
        {
            try
            {
                var db = new SoHoaEntities();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model.TinTucId == default || model.TinTucId == 0)
                {
                    db.TinTucs.Add(model);
                    try
                    {
                        var res = await db.SaveChangesAsync();
                        // var result = await db.TinTucs.ToListAsync();
                        return Ok(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    var tinTuc = await db.TinTucs.FindAsync(model.TinTucId);
                    if (tinTuc == null)
                    {
                        return NotFound();
                    }
                    tinTuc.Ten = model.Ten;
                    tinTuc.NgayTao = DateTime.Now;
                    tinTuc.NguoiTao = model.NguoiTao;
                    tinTuc.NoiDungMo = model.NoiDungMo;
                    tinTuc.NoiDungThan = model.NoiDungThan;
                    tinTuc.NoiDungKet = model.NoiDungKet;
                    tinTuc.TieuDeMo = model.TieuDeMo;
                    tinTuc.TieuDeThan = model.TieuDeThan;
                    tinTuc.TieuDeKet = model.TieuDeKet;
                    tinTuc.AnhMo = model.AnhMo;
                    tinTuc.AnhThan = model.AnhThan;
                    tinTuc.AnhKet = model.AnhKet;
                    db.TinTucs.AddOrUpdate(tinTuc);
                    try
                    {
                        var res = await db.SaveChangesAsync();
                        return Ok(tinTuc);
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