using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class MedicinebillRepository:IMedicineBillRepository
    {
        // Data fields
        private readonly CMSDBContext _context;

        // default constructor
        public MedicinebillRepository(CMSDBContext context)
        {
            _context = context;
        }

        #region Get all medicine bills
        public async Task<List<MedicineBill>> GetAllMedicineBills()
        {
            if (_context != null)
            {
                return await _context.MedicineBill.Include(p => p.Prescription).Include(a => a.Appointment).ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add medicine bill

        public async Task<int> AddToMedicineBill(MedicineBill medcinebill)
        {
            if (_context != null)
            {
                await _context.MedicineBill.AddAsync(medcinebill);
                await _context.SaveChangesAsync(); // commit transaction
                return medcinebill.MbillId;
            }
            return 0;
            //throw new NotImplementedException();
        }
        #endregion
        #region get medicinebill by id
        public async Task<ActionResult<MedicineBill>> GetMedicineBillById(int? id)
        {
            if (_context != null)
            {
                var bill = await _context.MedicineBill.FindAsync(id);
                return bill;
            }
            return null;
        }
        #endregion

        public async Task<List<MedicineBill>> GetMedicineBillByPresId(int? PresId)
        {
            if (_context != null)
            {
                return await (from MB in _context.MedicineBill
                            where MB.PrescriptionId == PresId
                            select new MedicineBill
                            {
                                MbillId = MB.MbillId,
                                PrescriptionId = MB.PrescriptionId,
                                AppointmentId = MB.AppointmentId,
                                MedicinePrice = MB.MedicinePrice,
                                UpdatedDate = MB.UpdatedDate,

                            }).ToListAsync();
            }
            return null;
        }
        
    }
}
